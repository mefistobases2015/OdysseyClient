using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace OdysseyAplication
{
    class XmlObjects
    {
    }

    [Serializable()]
    [XmlRoot("Settings")]
    public class Settings
    {

        [XmlElement("DatabaseSettings")]
        public DatabaseSettings databaseSettings { set; get; }

        [XmlElement("BlobManagerSettings")]
        public BlobManagerSettings blobManagerSettings { set; get; }

    }

    [Serializable()]
    public class DatabaseSettings
    {
        [XmlAttribute("databaseName")]
        public string databaseName { set; get; }
        [XmlAttribute("isDatabase")]
        public bool isDatabase { set; get; }
    }

    [Serializable()]
    public class BlobManagerSettings
    {
        [XmlAttribute("accountName")]
        public string accountName { set; get; }

        [XmlAttribute("accountKey")]
        public string accountKey { set; get; }

        [XmlAttribute("musicUrl")]
        public string musicUrl { set; get; }

        [XmlAttribute("dwnlMusicPath")]
        public string downloadMusicPath { set; get; }

    }

}
