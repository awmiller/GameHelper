using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHelper.Storage
{
    /// <summary>
    /// Helper class for making an inflatable object use a loose XML style
    /// </summary>
    public class XmlNode : IInflationNode
    {
        /// <summary>
        /// the name of the tag used in the bracket
        /// </summary>
        public string TagName { private set; get; }

        /// <summary>
        /// Information which this tag encapsulates.
        /// </summary>
        public string Content = null;

        /// <summary>
        /// Basic constructor must handle at least the tag name
        /// </summary>
        /// <param name="tagName">Name of this node's tag</param>
        public XmlNode(string tagName)
        {
            TagName = tagName;
            Childeren = new List<XmlNode>();
            Decorations = new Dictionary<string, string>();
        }

        /// <summary>
        /// Content descriptive constructor enforces rules about content vs. childeren
        /// </summary>
        /// <param name="tagName">Name of this node's tag</param>
        public XmlNode(string tagName, string content)
        {
            TagName = tagName;
            Content = content;
            Childeren = null;
        }

        /// <summary>
        /// Local storage of heirarchial childeren nodes
        /// </summary>
        public List<XmlNode> Childeren;

        /// <summary>
        /// Add a node to this tag's heirarchial childeren.
        /// </summary>
        /// <param name="xnode">another XML node</param>
        /// <returns>this node for chaining</returns>
        public XmlNode Attach(XmlNode xnode)
        {
            this.Childeren.Add(xnode);
            return this;
        }

        /// <summary>
        /// Decorations are string key/value pairs defined in the tag's opening bracket.
        /// </summary>
        public Dictionary<string, string> Decorations;

        /// <summary>
        /// Add a decoration, an attribute that goes inside the header tag.
        /// </summary>
        /// <param name="key">attribute name</param>
        /// <param name="value">attribute value</param>
        public void Decorate(string key,string value)
        {
            Decorations.Add(key,value);
        }

        /// <summary>
        /// Create the string XML tag from this instance's data.
        /// </summary>
        /// <remarks>Heirarchially creates </remarks>
        /// <returns>string description of this class</returns>
        public override string ToString()
        {
            StringBuilder tag = new StringBuilder();

            //bring together decorators
            String[] decor = Decorations.Select(a => String.Format(" {0}=\"{1}\"", a.Key, a.Value)).ToArray();

            //Join them to the tag name
            tag.AppendLine(String.Format("<{0}>{2}", String.Join(TagName, decor)));

            //Add contents
            tag.AppendLine(Content);

            //fill in childeren
            tag.Append(Childeren.Select<XmlNode, string>(a => a.ToString()));

            //make sure we start on the next line
            tag.Append(Environment.NewLine);

            //close the tag
            tag.AppendLine(String.Format("</{0}>", TagName));

            return tag.ToString();
        }
    }
}
