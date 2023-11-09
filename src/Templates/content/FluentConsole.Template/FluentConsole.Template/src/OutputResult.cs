using System.Collections.Generic;

namespace FluentConsole.Template; 

public class OutputResult {
    public string Result { get; set; }
    public IEnumerable<string> Messages { get; set; }
}