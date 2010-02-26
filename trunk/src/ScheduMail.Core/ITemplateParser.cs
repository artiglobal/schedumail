using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduMail.Core.Facade 
{
  /// <summary>
  /// Facade for managing / parsing ScheduMail templates
  /// </summary>
  public interface ITemplateParser 
  {
    /// <summary>
    /// Renders a template given a template and data
    /// </summary>
    /// <param name="data">Object instance used for data context when template is parsed</param>
    /// <param name="templateName">A unique name for the template.</param>
    /// <param name="templateBody">Template content to be parsed by template parser.</param>
    /// <returns>Parsed template</returns>
    string Render<TEMPLATEDATA>(TEMPLATEDATA data, string templateName, string templateBody); 
  }
}
