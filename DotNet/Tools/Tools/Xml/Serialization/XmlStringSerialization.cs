using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Tools.Xml.Serialization
{
    /// <summary>
    /// Handles serialization of object to xml and deserialization of xml to objects.
    /// </summary>
    /// <typeparam name="Type">The type of the xml.</typeparam>
    public class XmlStringSerialization<DataType>
    {
        /// <summary>
        /// Serializes the specified object to serialize.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public string Serialize(DataType objectToSerialize)
        {
            string xml;
            var serializer = new XmlSerializer(typeof(DataType));

            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream))
                    serializer.Serialize(writer, objectToSerialize);

                stream.Position = 0;

                using (var reader = new StreamReader(stream, Encoding.UTF8))
                    xml = reader.ReadToEnd();
            }

            return xml;
        }

        /// <summary>
        /// Deserializes the specified XML to deserialize.
        /// </summary>
        /// <param name="xmlToDeserialize">The XML to deserialize.</param>
        /// <returns></returns>
        public DataType Deserialize(string xmlToDeserialize)
        {
            DataType deserializedObject;
            var serializer = new XmlSerializer(typeof(DataType));

            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(xmlToDeserialize);
                writer.Flush();
                stream.Position = 0;

                deserializedObject = (DataType)serializer.Deserialize(stream);
            }

            return deserializedObject;
        }
    }
}

/* Copyright 2021 Timothy Beckett
 * * * * * * * * * * * * * * * * */
