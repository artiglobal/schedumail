using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spark;

namespace ScheduMail.Spark.TemplateParser 
{
  /// <summary>
  /// Base class of all spark user template
  /// </summary>
  public abstract class TemplateBase : AbstractSparkView 
  {
    protected object _data;

    public object Data 
    {
      get 
      {
        return _data;
      }
    }

    public void SetContext(object data) 
    {
      _data = data;
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
