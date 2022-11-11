using System.Xml;

public partial class Program
{
    public class XmlDocProcessor
    { 
        private string DocName { get; }
        private XmlDocument Doc = new XmlDocument();

        public XmlDocProcessor(string docName)
        {
            DocName = docName;
            LoadDoc();
        }

        private void LoadDoc()
        {
            Doc.Load(DocName);
        }

        public XmlNodeList GetNodeListOfElement(string elementName)
        {
            return Doc.GetElementsByTagName(elementName); ;
        }
    }

}