using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Spark;
using System.Text.RegularExpressions;

namespace ScheduMail.TemplateParsers.Spark 
{
  /// <summary>
  /// Base class of all spark user template
  /// </summary>
  public abstract class TemplateBase : AbstractSparkView 
  {
    /// <summary>
    /// The generated code will use ViewData.Eval("propertyname") if 
    /// the template is using the viewdata element
    /// </summary>
    public ViewDataDictionary ViewData { get; set; } 
    protected object _data;

    public object Data 
    {
      get 
      {
        return _data;
      }
    }

    public TemplateBase() 
    {
      ViewData = new ViewDataDictionary();
    }

    public void SetContext(object data) 
    {
      _data = data;
      var name = data.GetType().Name;
      ViewData[name] = data;
    }

    public string H(object objectToEncode) 
    {
      return HttpUtility.HtmlEncode(objectToEncode.ToString());
    }

    public class ViewDataDictionary : Dictionary<string, object> 
    {
      public object Eval(string key) 
      {
        return this[key];
      }
    }
  }

  /// <summary>
  /// Base class of all spark user template
  /// </summary>
  public abstract class TemplateBase<TEMPLATEDATA> : TemplateBase
  {
    public new TEMPLATEDATA Data 
    {
      get 
      {
        return (TEMPLATEDATA)base.Data;
      }
    }
  }

}
