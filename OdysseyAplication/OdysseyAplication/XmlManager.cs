using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace OdysseyAplication
{
    /// <summary>
    /// Esta clase se va a conecta con archivos xml para tomar settings sobre 
    /// las clases
    /// </summary>
    static class XmlManager
    {
        /// <summary>
        /// Constante de la direccion del archivo xml
        /// </summary>
        private const string XML_PATH = "../../../Settings.xml";

        /// <summary>
        /// 
        /// </summary>
        static private Settings settings = readSettings();

        /// <summary>
        /// Obtiene los valores del archivo xml
        /// </summary>
        /// <returns>
        /// Un objeto settings que tiene la información para 
        /// subir musica y descargarla, para crear la base de 
        /// datos y demás información que es bueno almacenar 
        /// de forma permanente.
        /// </returns>
        static private Settings readSettings()
        {
            //Stream a archivo xml
            StreamReader reader = new StreamReader(XML_PATH);
            //inica Serializer
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            //crea el objeto settings con los valores del xml
            Settings settings = (Settings)serializer.Deserialize(reader);
            //cierra el lector del archivo
            reader.Close();
            //retorna los settings
            return settings;
        }

        /// <summary>
        /// Escribe las nuevas opciones
        /// </summary>
        /// <param name="newSettings">
        /// Objeto Settings nuevo que esta actualizado y 
        /// va a ser escrito.
        /// </param>
        static private void writeSettings(Settings newSettings)
        {
            try
            {
                //se crea serializador
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                //
                TextWriter txtWrt = new StringWriter();
                //Crea el string del nuevo settings
                serializer.Serialize(txtWrt, newSettings);
                //Limpia buffers
                txtWrt.Flush();
                //Obtiene el string del objeto en xml
                string xmlObj = txtWrt.ToString().Trim();
                //Cierra el lector de strings
                txtWrt.Close();
                //Le da formato XML
                XmlDocument doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                doc.LoadXml(xmlObj);
                //se obtiene el string despues de ser analizado
                xmlObj = doc.OuterXml;

                using (StreamWriter writer  = new StreamWriter("Settings.xml", false))
                {
                    writer.Write(xmlObj.Trim());
                    writer.Flush();
                    writer.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


        /// <summary>
        /// Verifica que haya una base de datos local
        /// </summary>
        /// <returns>
        /// bool que es true si todo salió bien y false si no. 
        /// </returns>
        static private  bool isDatabase()
        {
            
            return settings.databaseSettings.isDatabase;

        }

        /// <summary>
        /// Despes de crear una base de datos establece en 
        /// el xml los nuevos valores.
        /// </summary>
        static public void databaseCreated()
        {
            settings.databaseSettings.isDatabase = true;

            writeSettings(settings);

            settings = readSettings();
        }

        /// <summary>
        /// Retorna el nombre de la base de datos
        /// </summary>
        /// <returns>
        /// string que es el nombre que se le debe de dar a la base de datos.
        /// </returns>
        static public string getDatabaseName()
        {
            return settings.databaseSettings.databaseName;
        }

        /// <summary>
        /// Obtiene el nombre de usuario para acceder
        /// al blob
        /// </summary>
        /// <returns>
        /// string con el nombre de usuario.
        /// </returns>
        static public string getBlobUserAccount()
        {
            return settings.blobManagerSettings.accountName;
        }

        /// <summary>
        /// Obtiene la llave 
        /// </summary>
        /// <returns>
        /// string que obtiene el llave para 
        /// conectarse al blob
        /// </returns>
        static public string getBlobKeyAccount()
        {
            return settings.blobManagerSettings.accountKey;
        }

        /// <summary>
        /// Obtiene el url para decargar musica
        /// </summary>
        /// <returns>
        /// string con el url para conectarse.
        /// </returns>
        static public string getMusicUrl()
        {
            return settings.blobManagerSettings.musicUrl;
        }
    }
}
