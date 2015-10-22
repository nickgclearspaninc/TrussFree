using System;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComponentFileReader.FileClasses.KxrComponent
{
    public partial class KxrComponent : Component
    {
        public KxrComponent(string contents) : base()
        {
            var temp = new XmlDocument();
            temp.LoadXml(contents);

            this.JsonContents = JObject.Parse(JsonConvert.SerializeXmlNode(temp));
        }

        public XmlDocument GetXML()
        {
            XmlDocument documentToReturn = (XmlDocument)JsonConvert.DeserializeXmlNode(this.JsonContents.ToString());

            return documentToReturn;
        }
    }
}
