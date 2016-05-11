using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace AppoimentManager.Core.Serialization
{
    public class XmlSerialization : IDisposable
    {
        public XmlSerialization()
        {

        }

        public static TObject LoadFromFile<TObject>(string fullPath)
           where TObject : new()
        {
            Type type = typeof(TObject);
            TObject @return = new TObject();

            XmlSerializer serializer = null;
            serializer = new XmlSerializer(type);

            if (File.Exists(fullPath))
            {
                using (Stream stream = File.OpenRead(fullPath))
                {
                    @return = (TObject)serializer.Deserialize(stream);
                }
            }
            else
            {
                throw new FileNotFoundException();
            }

            return @return;
        }

        public static TObject LoadFromFileWithIvalidCharacters<TObject>(string fullPath)
            where TObject : new()
        {
            Type type = typeof(TObject);
            TObject @return = new TObject();

            XmlSerializer serializer = null;
            serializer = new XmlSerializer(type);

            if (File.Exists(fullPath))
            {
                using (TextReader stream = new StreamReader(fullPath))
                {
                    using (XmlTextReader xmlReader = new XmlTextReader(stream))
                    {
                        @return = (TObject)serializer.Deserialize(xmlReader);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }

            return @return;
        }

        public static TObject LoadFromStream<TObject>(Stream stream)
          where TObject : new()
        {
            Type type = typeof(TObject);
            TObject @return = new TObject();

            XmlSerializer serializer = null;
            serializer = new XmlSerializer(type);

            if (stream != null)
            {
                @return = (TObject)serializer.Deserialize(stream);
            }
            else
            {
                throw new IOException();
            }

            return @return;
        }

        public static bool SaveToFile<TObject>(string destination, TObject objectToSerialize)
           where TObject : new()
        {
            using (Stream stream = File.Open(destination, FileMode.Create))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
                    serializer.Serialize(stream, objectToSerialize);
                }
                catch (InvalidOperationException ex)
                {
                    //logger.Debug(ex.Message, ex);
                    return false;
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message, ex);
                    return false;
                }
            }

            return true;
        }

        //public static bool SaveToFile<TObject>(string destination, TObject objectToSerialize, bool useEncryption,
        //    IXMLCryptoTransformProvider cryptoTransformProvider)
        //  where TObject : new()
        //{
        //    XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());

        //    using (MemoryStream mem = new MemoryStream())
        //    {
        //        serializer.Serialize(mem, objectToSerialize);

        //        byte[] transformed = Transform(mem, cryptoTransformProvider.GetEncryptor(useEncryption));

        //        if (File.Exists(destination))
        //        {
        //            File.Delete(destination);
        //        }

        //        using (FileStream fs = File.Create(destination))
        //        using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
        //        {
        //            string _test1 = Encoding.ASCII.GetString(transformed);
        //            string _test2 = Encoding.Default.GetString(transformed);
        //            string _test3 = Encoding.UTF8.GetString(transformed);

        //            sw.Write(useEncryption ? Convert.ToBase64String(transformed) : Encoding.UTF8.GetString(transformed));

        //            sw.Flush();
        //        }
        //    }

        //    return true;
        //}

        public static string GetStringFromObject<TObject>(TObject objectToSerialize)
            where TObject : new()
        {
            XmlDocument doc = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(objectToSerialize.GetType());
            MemoryStream stream = new MemoryStream();
            try
            {
                serializer.Serialize(stream, objectToSerialize);
                stream.Position = 0;
                doc.Load(stream);
                return doc.InnerXml;
            }
            catch
            {
                throw;
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }
        }

        public static TObject GetObjectFromString<TObject>(string xmlOfAnObject, Type type)
            where TObject : new()
        {
            TObject result = new TObject();
            StringReader read = new StringReader(xmlOfAnObject);
            XmlSerializer serializer = new XmlSerializer(type);
            XmlReader reader = new XmlTextReader(read);
            try
            {
                result = (TObject)serializer.Deserialize(reader);
                return result;
            }
            catch (Exception ex)
            {
                //logger.Error(ex.Message, ex);
                throw;
            }
            finally
            {
                reader.Close();
                read.Close();
                read.Dispose();
            }
        }

        public static TObject GetObjectFromString<TObject>(string xmlOfAnObject)
            where TObject : new()
        {
            return GetObjectFromString<TObject>(xmlOfAnObject, typeof(TObject));
        }

        private bool _fileHashPrefixEnabled = false;
        public bool FileHashPrefixEnabled
        {
            get
            {
                return _fileHashPrefixEnabled;
            }
            set
            {
                _fileHashPrefixEnabled = value;
            }
        }

        public Stream Read(string filePath)
        {
            Stream stream = new FileStream(filePath, FileMode.Open);
            return stream;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //private static MemoryStream TransformMS(MemoryStream toTransform, ICryptoTransform transformation)
        //{
        //    return new MemoryStream(Transform(toTransform, transformation));
        //}

        //private static byte[] Transform(MemoryStream toTransform, ICryptoTransform transformation)
        //{
        //    using (MemoryStream transformed = new MemoryStream())
        //    using (CryptoStream cs = new CryptoStream(transformed, transformation, CryptoStreamMode.Write))
        //    {
        //        byte[] plain = toTransform.ToArray();
        //        cs.Write(plain, 0, plain.Length);
        //        cs.FlushFinalBlock();
        //        return transformed.ToArray();
        //    }
        //}
    }
}
