using System.Collections.Generic;
using System.Text;

namespace restlessmedia.Module.Meta
{
  /// <summary>
  /// Class used for passing queries for meta data associated with other objects.
  /// </summary>
  /// <example>Add(CategoryId (int), Value (object))</example>
  public class MetaQuery : Dictionary<int, object>
  {
    public MetaQuery()
    {
      Page = 1;
      MaxPerPage = 10;
    }

    public int Page { get; set; }

    public int MaxPerPage { get; set; }

    /// <summary>
    /// Returns the xml query for searching on meta values <q><c id="123" value="test"></c></q>
    /// </summary>
    /// <param name="metaValues"></param>
    /// <returns></returns>
    public string GetXmlString()
    {
      if (this.Count == 0)
      {
        return null;
      }

      StringBuilder xml = new StringBuilder("<q>");
      foreach (KeyValuePair<int, object> pair in this)
      {
        xml.AppendFormat("<c id=\"{0}\" v=\"{1}\" />", pair.Key, pair.Value);
      }
      xml.Append("</q>");

      return xml.ToString();
    }
  }
}
