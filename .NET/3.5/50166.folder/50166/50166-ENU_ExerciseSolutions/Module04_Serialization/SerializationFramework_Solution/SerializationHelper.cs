using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace SerializationFramework
{
    /// <summary>
    /// Performs custom serialization and deserialization with the constraints
    /// of the [Serialization] and [DeserializationCallback] attributes.
    /// </summary>
    public static class SerializationHelper
    {
        [ThreadStatic]
        private static BinaryFormatter _formatter;

        [ThreadStatic]
        private static ICryptoTransform _encryptor;
        [ThreadStatic]
        private static ICryptoTransform _decryptor;

        private static readonly byte[] Key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private static readonly byte[] IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        private static void InitEncryption()
        {
            if (_encryptor == null || _decryptor == null)
            {
                RijndaelManaged algorithm = new RijndaelManaged();
                algorithm.IV = IV;
                algorithm.Key = Key;
                _encryptor = algorithm.CreateEncryptor();
                _decryptor = algorithm.CreateDecryptor();
            }
        }

        private static byte[] Encrypt(byte[] data)
        {
            InitEncryption();

            MemoryStream stream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(stream, _encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.Close();
            return stream.ToArray();
        }

        private static byte[] Decrypt(byte[] data)
        {
            InitEncryption();

            List<byte> result = new List<byte>();
            MemoryStream stream = new MemoryStream(data);
            using (CryptoStream cryptoStream = new CryptoStream(stream, _decryptor, CryptoStreamMode.Read))
            {
                int bytesRead;
                byte[] buffer = new byte[4096];
                while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    result.AddRange(buffer.Take(bytesRead));
                }

                return result.ToArray();
            }
        }

        private static byte[] Compress(byte[] data)
        {
            MemoryStream stream = new MemoryStream();
            GZipStream zipStream = new GZipStream(stream, CompressionMode.Compress);
            zipStream.Write(data, 0, data.Length);
            zipStream.Close();
            return stream.ToArray();
        }

        private static byte[] Decompress(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data, false);
            stream.Position = 0;
            GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress);

            List<byte> result = new List<byte>();

            int bytesRead;
            byte[] buffer = new byte[4096];
            while ((bytesRead = zipStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                result.AddRange(buffer.Take(bytesRead));
            }

            return result.ToArray();
        }

        /// <summary>
        /// Serializes the specified instance.  Fields marked with SerializationOptions.Omit
        /// are not emitted into the serialization information; fields marked with
        /// SerializationOptions.Compress are compressed before they are stored; fields marked
        /// with SerializationOptions.Encrypt are encrypted before they are stored; fields 
        /// marked with SerializationOptions.Default are directly emitted into the serialization
        /// information store.
        /// </summary>
        public static void Serialize<T>(T instance, SerializationInfo info)
        {
            foreach (FieldInfo field in instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                SerializationAttribute[] attrs = (SerializationAttribute[])field.GetCustomAttributes(typeof(SerializationAttribute), true);
                if (attrs.Length != 0 && attrs[0].SerializationOptions != SerializationOptions.Default)
                {
                    if ((attrs[0].SerializationOptions & SerializationOptions.Omit) != 0)
                    {
                        continue;   //Skip this field
                    }

                    byte[] serialized = Serialize(field.GetValue(instance));
                    if ((attrs[0].SerializationOptions & SerializationOptions.Compress) != 0)
                    {
                        serialized = Compress(serialized);
                    }
                    if ((attrs[0].SerializationOptions & SerializationOptions.Encrypt) != 0)
                    {
                        serialized = Encrypt(serialized);
                    }

                    info.AddValue(field.Name, serialized);
                }
                else
                {
                    info.AddValue(field.Name, field.GetValue(instance));
                }
            }
        }

        /// <summary>
        /// Deserializes the specified instance.  Fields marked with SerializationOptions.Omit
        /// are dynamically recreated with a default value or using the deserialization callback;
        /// fields marked with SerializationOptions.Compress are decompressed after retrieval;
        /// fields marked with SerializationOptions.Encrypt are decrypted after retrieval; fields 
        /// marked with SerializationOptions.Default are directly retrieved from the serialization
        /// information store.
        /// </summary>
        public static void Deserialize<T>(T instance, SerializationInfo info)
        {
            foreach (FieldInfo field in instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                SerializationAttribute[] attrs = (SerializationAttribute[])field.GetCustomAttributes(typeof(SerializationAttribute), true);
                if (attrs.Length != 0 && attrs[0].SerializationOptions != SerializationOptions.Default)
                {
                    if ((attrs[0].SerializationOptions & SerializationOptions.Omit) != 0)
                    {
                        if (attrs[0].DynamicDeserializationBehavior == DynamicDeserializationBehavior.InvokeCallback)
                        {
                            MethodInfo callback =
                                (from method in instance.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                 let cbs = (DeserializationCallbackAttribute[])method.GetCustomAttributes(typeof(DeserializationCallbackAttribute), false)
                                 where cbs.Length == 1 && cbs[0].FieldName == field.Name
                                 select method).SingleOrDefault();
                            if (callback == null)
                            {
                                throw new InvalidOperationException("No callback registered for field " + field.Name + " although it is marked " +
                                    "with DynamicDeserializationBehavior.InvokeCallback.");
                            }
                            callback.Invoke(instance, null);
                        }
                        continue;
                    }

                    byte[] deserialized = (byte[])info.GetValue(field.Name, typeof(byte[]));
                    if ((attrs[0].SerializationOptions & SerializationOptions.Encrypt) != 0)
                    {
                        deserialized = Decrypt(deserialized);
                    }
                    if ((attrs[0].SerializationOptions & SerializationOptions.Compress) != 0)
                    {
                        deserialized = Decompress(deserialized);
                    }

                    field.SetValue(instance, Deserialize(field.FieldType, deserialized));
                }
                else
                {
                    field.SetValue(instance, info.GetValue(field.Name, field.FieldType));
                }
            }
        }

        public static byte[] Serialize<T>(T instance)
        {
            MemoryStream stream = new MemoryStream();
            Serialize(instance, stream);
            return stream.ToArray();
        }

        private static T Deserialize<T>(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            return Deserialize<T>(stream);
        }

        private static object Deserialize(Type type, byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            return Deserialize(stream);
        }

        public static void Serialize<T>(T instance, Stream stream)
        {
            if (_formatter == null)
            {
                _formatter = new BinaryFormatter();
            }

            _formatter.Serialize(stream, instance);
        }

        private static object Deserialize(Stream stream)
        {
            if (_formatter == null)
            {
                _formatter = new BinaryFormatter();
            }

            return _formatter.Deserialize(stream);
        }

        public static T Deserialize<T>(Stream stream)
        {
            if (_formatter == null)
            {
                _formatter = new BinaryFormatter();
            }

            return (T)_formatter.Deserialize(stream);
        }
    }
}
