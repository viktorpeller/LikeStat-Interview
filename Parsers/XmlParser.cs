namespace Peller.Interview.CSharp.LikeStatistics.Parsers
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    internal class XmlParser
    {
        private static readonly string ItemTitle = "Person";

        private string path;
        private XmlReader xmlReader;
        private XmlSerializer xmlSerializer;

        internal XmlParser(string path)
        {
            this.path = path;
        }

        internal void StartParse()
        {
            this.xmlReader = XmlReader.Create(this.path);
            this.xmlReader.MoveToContent();
            this.xmlReader.ReadToDescendant(XmlParser.ItemTitle);

            this.xmlSerializer = new XmlSerializer(typeof(Person));
        }

        internal void FinishParse()
        {
            this.xmlReader.Close();
        }

        internal Person GetNextPerson()
        {
            return this.xmlSerializer.Deserialize(this.xmlReader) as Person;
        }
    }
}
