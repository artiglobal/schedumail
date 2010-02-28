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
      /// Renders the specified data.
      /// </summary>
      /// <typeparam name="TEMPLATEDATA">The type of the EMPLATEDATA.</typeparam>
      /// <param name="data">The data instance.</param>
      /// <param name="templateName">Name of the template.</param>
      /// <param name="templateBody">The template body.</param>
      /// <returns>Parsed data instance.</returns>
    string Render<TEMPLATEDATA>(TEMPLATEDATA data, string templateName, string templateBody); 
  }
}
