using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SerializationTypes
{
    /// <summary>
    /// This demo demonstrates various flavors of .NET serialization, including
    /// standard serialization, customizing serialization with the [NonSerialized]
    /// attribute, customing serialization with serialization/deserialization callbacks
    /// and customizing serialization using the ISerializable interface.
    /// 
    /// Throughout the demos, the serialization output files are produced in the
    /// application's working directory.  For convenience purposes, they have also
    /// been copied and included in this project's directory, and can be viewed in
    /// the Visual Studio Solution Explorer.
    /// </summary>
    class SerializingTypes
    {
        static void Main(string[] args)
        {
            SimpleSerialization();
            RemovingFieldsFromSerialization();
            SerializationCallbacks();
            CustomSerialization();
        }

        private static void SimpleSerialization()
        {
            User joe = new User("Joe", "123456");
            Console.WriteLine("Before serialization: " + joe);

            //Serialize the user to a binary file.  In the process,
            //we are also serializing the password, which is easy to
            //inspect by loading the binary data file.  (There is no
            //encryption or compression in the process.)
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create("joe.serialized");
            formatter.Serialize(file, joe);
            file.Close();

            ReputationDB.ChangeReputation("Joe", 2);

            Thread.Sleep(2000);

            //Deserialize the user from the binary file.
            file = File.Open("joe.serialized", FileMode.Open);
            joe = (User)formatter.Deserialize(file);
            file.Close();

            //Note: the properties of the user have not changed
            //even though the reputation database has been updated.
            Console.WriteLine("After deserialization: " + joe);
        }

        private static void RemovingFieldsFromSerialization()
        {
            ReputationDB.ChangeReputation("Joe", 15);

            User2 joe = new User2("Joe", "123456");
            Console.WriteLine("Before serialization: " + joe);

            //Serialize the user to a binary file.  This time, the
            //password is not serialized to the file, which is easy
            //to see by inspecting it.
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create("joe2.serialized");
            formatter.Serialize(file, joe);
            file.Close();

            ReputationDB.ChangeReputation("Joe", 2);

            Thread.Sleep(2000);

            //Deserialize the user from the binary file.
            file = File.Open("joe2.serialized", FileMode.Open);
            joe = (User2)formatter.Deserialize(file);
            file.Close();

            //Note: the properties of the user have not changed
            //even though the reputation database has been updated.
            Console.WriteLine("After deserialization: " + joe);
        }

        private static void SerializationCallbacks()
        {
            ReputationDB.ChangeReputation("Joe", 15);

            User3 joe = new User3("Joe", "123456");
            Console.WriteLine("Before serialization: " + joe);

            //Serialize the user to a binary file.
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create("joe3.serialized");
            formatter.Serialize(file, joe);
            file.Close();

            ReputationDB.ChangeReputation("Joe", 2);

            Thread.Sleep(2000);

            //Deserialize the user from the binary file.
            file = File.Open("joe3.serialized", FileMode.Open);
            joe = (User3)formatter.Deserialize(file);
            file.Close();

            //Note: the properties of the user have changed thanks
            //to the deserialization callback!
            Console.WriteLine("After deserialization: " + joe);
        }

        private static void CustomSerialization()
        {
            ReputationDB.ChangeReputation("Joe", 15);

            User4 joe = new User4("Joe", "123456");
            Console.WriteLine("Before serialization: " + joe);

            //Serialize the user to a binary file.  Inspect the
            //binary file to make sure that the password was not
            //serialized in plain text.
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create("joe4.serialized");
            formatter.Serialize(file, joe);
            file.Close();

            ReputationDB.ChangeReputation("Joe", 2);

            Thread.Sleep(2000);

            //Deserialize the user from the binary file.
            file = File.Open("joe4.serialized", FileMode.Open);
            joe = (User4)formatter.Deserialize(file);
            file.Close();

            //Note: the properties of the user have changed thanks
            //to the deserialization constructor!
            Console.WriteLine("After deserialization: " + joe);
        }
    }

    /// <summary>
    /// Maintains a reputation index for users.
    /// </summary>
    class ReputationDB
    {
        private static Dictionary<string, int> _reputation = new Dictionary<string, int>();

        static ReputationDB()
        {
            _reputation["Joe"] = 15;
            _reputation["Mike"] = 12;
        }

        public static void ChangeReputation(string user, int reputation)
        {
            _reputation[user] = reputation;
        }

        public static int ReputationForUser(string user)
        {
            return _reputation[user];
        }
    }

    /// <summary>
    /// Represents a user logged on to the system.  The user class
    /// is marked with the [Serializable] attribute, indicating to the
    /// serialization runtime that instances of the User class can be
    /// serialized and deserialized.  (Remember that serialization is
    /// an opt-in mechanism.)
    /// </summary>
    [Serializable]
    class User
    {
        private string _name;
        private string _password;
        private DateTime _loginTime;
        private int _reputation;

        public User(string name, string password)
        {
            _name = name;
            _password = password;
            _loginTime = DateTime.Now;
            _reputation = ReputationDB.ReputationForUser(name);
        }

        public string Name { get { return _name; } }
        public int Reputation { get { return _reputation; } }
        public DateTime LoginTime { get { return _loginTime; } }

        public override string ToString()
        {
            return String.Format("{0}: {1}, logged on since {2}, password: {3}",
                _name, _reputation, _loginTime, _password);
        }
    }

    /// <summary>
    /// Revised version of the user class.  Does not serialize the password
    /// for security reasons, so that sensitive information is not persisted
    /// outside the program's memory.
    /// </summary>
    [Serializable]
    class User2
    {
        private string _name;
        [NonSerialized]
        private string _password;
        private DateTime _loginTime;
        private int _reputation;

        public User2(string name, string password)
        {
            _name = name;
            _password = password;
            _loginTime = DateTime.Now;
            _reputation = ReputationDB.ReputationForUser(name);
        }

        public string Name { get { return _name; } }
        public int Reputation { get { return _reputation; } }
        public DateTime LoginTime { get { return _loginTime; } }

        public override string ToString()
        {
            return String.Format("{0}: {1}, logged on since {2}, password: {3}",
                _name, _reputation, _loginTime, _password);
        }
    }

    /// <summary>
    /// Another revised version of the user class, which demonstrates the
    /// use of serialization callbacks for controlling what happens after
    /// serialization.  Only the [OnDeserialized] callback is actually used -
    /// the rest of the callbacks are provided for demonstration purposes.
    /// </summary>
    [Serializable]
    class User3
    {
        /// <summary>
        /// Only the user name is serialized.  The rest of the fields
        /// are dynamically restored when deserialization completes.
        /// The password is not serialized at all for security reasons.
        /// </summary>
        private string _name;
        [NonSerialized]
        private string _password;
        [NonSerialized]
        private DateTime _loginTime;
        [NonSerialized]
        private int _reputation;

        /// <summary>
        /// This method is called immediately after deserialization
        /// completes, and ensures that the user's reputation and
        /// login time are refreshed to reflect the present.
        /// </summary>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Console.WriteLine("[OnDeserialized] callback: User3 object has been deserialized");
            InitData();
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            Console.WriteLine("[OnDeserializing] callback: User3 object is deserializing");
        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            Console.WriteLine("[OnSerialized] callback: User3 object has been serialized");
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            Console.WriteLine("[OnSerializing] callback: User3 object is serializing");
        }

        public User3(string name, string password)
        {
            _name = name;
            _password = password;
            InitData();
        }

        private void InitData()
        {
            _loginTime = DateTime.Now;
            _reputation = ReputationDB.ReputationForUser(_name);
        }

        public string Name { get { return _name; } }
        public int Reputation { get { return _reputation; } }
        public DateTime LoginTime { get { return _loginTime; } }

        public override string ToString()
        {
            return String.Format("{0}: {1}, logged on since {2}, password: {3}",
                _name, _reputation, _loginTime, _password);
        }
    }

    /// <summary>
    /// The final version of the user class, incorporating custom serialization
    /// to "securely" store the password using XOR-encryption and to restore all
    /// volatile fields after the object is deserialized.
    /// 
    /// Note that even though this class implements ISerializable to control its
    /// serialization, it must still be marked with the [Serializable] attribute,
    /// or an exception will be thrown at runtime when attempting to serializing
    /// an instance of this class.
    /// </summary>
    [Serializable]
    class User4 : ISerializable
    {
        private string _name;
        private string _password;
        private DateTime _loginTime;
        private int _reputation;

        /// <summary>
        /// Performs simple XOR encryption on the specified string using the
        /// specified character key.  Note that this is not strong encryption
        /// and it is demonstrated here for demo purposes only.
        /// </summary>
        /// <param name="str">The string to encrypt or decrypt.</param>
        /// <param name="key">The encryption key.</param>
        /// <returns>The encrypted or decrypted string.</returns>
        private static string EncryptDecrypt(string str, char key)
        {
            string result = String.Empty;
            for (int i = 0; i < str.Length; ++i)
                result += (char)(str[i] ^ key);
            return result;
        }

        /// <summary>
        /// Called by the serialization runtime when the object is being serialized.
        /// Use the 'info' parameter to record all data that needs to be serialized.
        /// </summary>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", _name);
            info.AddValue("Password", EncryptDecrypt(_password, 'X'));
        }

        /// <summary>
        /// Called by the serialization runtime when the object is being deserialized.
        /// You cannot rely on the standard constructor to be called - but this constructor
        /// will be called.  Note that this constructor could also be made private because
        /// the serialization runtime is not constrained by accessibility modifiers.
        /// </summary>
        protected User4(SerializationInfo info, StreamingContext context)
        {
            _name = info.GetString("Name");
            _password = EncryptDecrypt(info.GetString("Password"), 'X');
            InitData();
        }

        public User4(string name, string password)
        {
            _name = name;
            _password = password;
            InitData();
        }

        private void InitData()
        {
            _loginTime = DateTime.Now;
            _reputation = ReputationDB.ReputationForUser(_name);
        }

        public string Name { get { return _name; } }
        public int Reputation { get { return _reputation; } }
        public DateTime LoginTime { get { return _loginTime; } }

        public override string ToString()
        {
            return String.Format("{0}: {1}, logged on since {2}, password: {3}",
                _name, _reputation, _loginTime, _password);
        }
    }
}
