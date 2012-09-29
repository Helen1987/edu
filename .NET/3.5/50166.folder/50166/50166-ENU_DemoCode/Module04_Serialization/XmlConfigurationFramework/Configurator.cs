using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace XmlConfigurationFramework
{
    /// <summary>
    /// Represents the application's configuration file (note: this is not the same
    /// app.config file that is supported by the .NET built-in configuration framework).
    /// </summary>
    public class ApplicationConfiguration
    {
        public const string DefaultPath = "myApp.config";

        public static ApplicationConfiguration Load()
        {
            return Load(DefaultPath);
        }

        public static ApplicationConfiguration Load(string path)
        {
            return Configurator<ApplicationConfiguration>.Load(path);
        }

        public void Save()
        {
            Save(DefaultPath);
        }

        public void Save(string path)
        {
            Configurator<ApplicationConfiguration>.Save(this, path);
        }

        public ApplicationConfiguration()
        {
            Sections = new XmlSerializableDictionary<string, string>();
        }

        public XmlSerializableDictionary<string, string> Sections { get; set; }

        public void AddSection<TConfiguration>(string name, string path, TConfiguration config) where TConfiguration : class, new()
        {
            Sections.Add(name, path);
            Configurator<TConfiguration>.Save(config, path);
        }

        public TConfiguration GetSection<TConfiguration>(string name) where TConfiguration : class, new()
        {
            return Configurator<TConfiguration>.Load(Sections[name]);
        }
    }

    /// <summary>
    /// Represents a key-value collection of database connection strings.
    /// </summary>
    public class ConnectionStrings
    {
        public ConnectionStrings()
        {
            Connections = new XmlSerializableDictionary<string, string>();
        }

        public XmlSerializableDictionary<string, string> Connections { get; set; }
    }

    /// <summary>
    /// Represents a list of users allowed to use the application.
    /// </summary>
    public class AllowedUsers
    {
        public AllowedUsers()
        {
            Users = new List<string>();
        }

        public List<string> Users { get; set; }
    }

    /// <summary>
    /// Serializes a type to a file and from a file using XmlSerializer.  Used to serialize
    /// and deserialize configuration sections in the demo scenario.
    /// </summary>
    /// <typeparam name="TConfiguration">The type to serialize.</typeparam>
    public class Configurator<TConfiguration> where TConfiguration : class, new()
    {
        private static XmlSerializer _serializer = new XmlSerializer(typeof(TConfiguration));

        public static TConfiguration Load(string path)
        {
            if (!File.Exists(path))
            {
                return new TConfiguration();
            }

            using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                return (TConfiguration)_serializer.Deserialize(stream);
            }
        }

        public static void Save(TConfiguration config, string path)
        {
            using (FileStream stream = File.Create(path))
            {
                _serializer.Serialize(stream, config);
            }
        }
    }
}
