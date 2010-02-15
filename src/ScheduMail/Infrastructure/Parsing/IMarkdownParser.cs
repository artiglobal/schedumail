using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduMail.Infrastructure.Parsing {
  public interface IMarkdownParser {
    string Transform(string text);
  }
}
