using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;

namespace SerializationFramework
{
    /// <summary>
    /// Represents a sample object which requires custom serialization.
    /// The _password field should be encrypted before it is serialized;
    /// the _cookiesAndHistory field should be encrypted and compressed;
    /// the _loginTime field should not be serialized, but a deserialization
    /// callback takes care of its initialization; the _username field is
    /// serialized in the default form.
    /// </summary>
    [Serializable]
    class User : ISerializable
    {
        [Serialization(SerializationOptions.Encrypt)]
        private string _password;

        [Serialization(SerializationOptions.Encrypt | SerializationOptions.Compress)]
        private string _cookiesAndHistory;

        [Serialization(SerializationOptions.Omit, DynamicDeserializationBehavior.InvokeCallback)]
        private DateTime _loginTime;

        [Serialization(SerializationOptions.Default)]
        private string _username;

        [DeserializationCallback("_loginTime")]
        private void RefreshLoginTime()
        {
            _loginTime = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("{0}:{1} logged on at {2} with cookies (10 first characters): {3}",
                _username, _password, _loginTime,
                _cookiesAndHistory == null ? "(null)" : _cookiesAndHistory.Substring(0, Math.Min(10, _cookiesAndHistory.Length)));
        }

        public User(string username, string password, string cookiesAndHistory)
        {
            _loginTime = DateTime.Now;
            _username = username;
            _password = password;
            _cookiesAndHistory = cookiesAndHistory;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            SerializationHelper.Serialize(this, info);
        }

        protected User(SerializationInfo info, StreamingContext context)
        {
            SerializationHelper.Deserialize(this, info);
        }
    }

    /// <summary>
    /// Demonstrates the use of the serialization framework presented in this lab
    /// by serializing an instance of the User class to a MemoryStream and deserializing
    /// it from the MemoryStream.
    /// Ensure that the user information is restored after serialization, and that the
    /// login time field reflects the current time.
    /// </summary>
    class SerializationMain
    {
        static void Main(string[] args)
        {
            User user = new User("joe", "password1", String.Concat(Enumerable.Range(0, 1000).Select(i => i.ToString()).ToArray()));
            Console.WriteLine(user);

            Thread.Sleep(3000); //So that the login time will be updated

            MemoryStream stream = new MemoryStream();
            SerializationHelper.Serialize(user, stream);
            stream.Position = 0;
            Console.WriteLine(SerializationHelper.Deserialize<User>(stream));
        }
    }
}
