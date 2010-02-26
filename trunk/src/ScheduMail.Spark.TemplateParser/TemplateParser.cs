using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spark;
using Spark.FileSystem;
using ScheduMail.Core.Facade;

namespace ScheduMail.Spark.TemplateParser 
{

  public class TemplateParser : ITemplateParser
  {
    ISparkViewEngine _templateEngine;
    InMemoryViewFolder _viewFolder;

    public TemplateParser() : this(null,null)
    {

    }

    public TemplateParser(string[] assemblies, string[] namespaces) 
    {
      _viewFolder =  new InMemoryViewFolder();

      var settings = new SparkSettings();
      settings.SetPageBaseType(typeof(TemplateBase));

      foreach (var assembly in assemblies)
	    {
		    settings.AddAssembly(assembly);
	    }
      foreach (var item in namespaces)
	    {
    		 settings.AddNamespace(item);
	    }

      _templateEngine = new SparkViewEngine()
                            {
                              Settings = settings,
                              ViewFolder = _viewFolder,
                            };
    }

    private void AddTemplate(string templateName, string templateBody) 
    {
      if (!_viewFolder.HasView(templateName)) 
      {
        _viewFolder.Add(templateName, templateBody);
      }
    }

    public string Render<TEMPLATEDATA>(TEMPLATEDATA data, string templateName, string templateBody) 
    {
      AddTemplate(templateName, templateBody);

      var descriptor = new SparkViewDescriptor().AddTemplate(templateName);
      var template = (TemplateBase)_templateEngine.CreateInstance(descriptor);
      template.SetContext(data);

      var result = new StringBuilder();
      var writer = new System.IO.StringWriter(result);

      try 
	    {	        
    		template.RenderView(writer);
	    }
	    catch (Exception)
	    {
		    throw;
	    }
      finally
      {
        writer.Dispose();
        _templateEngine.ReleaseInstance(template);
      }

      return result.ToString();
    }

  }
}
