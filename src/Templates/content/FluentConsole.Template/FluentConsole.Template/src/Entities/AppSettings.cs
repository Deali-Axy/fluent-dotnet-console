﻿using System.Collections.Generic;

namespace FluentConsole.Template.Entities;

public class AppSettings {
    public string Name { get; set; }
    public bool Boolean { get; set; }
    public List<string> DemoList { get; set; } = new();
}