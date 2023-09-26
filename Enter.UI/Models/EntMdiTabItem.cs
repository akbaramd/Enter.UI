﻿using Enter.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Models
{
    public class EntMdiTabItem
    {
        public Guid Key { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Title { get; set; }
        public EntIcon Icon { get; set; }
        public Type ComponentType { get; set; }
        public Dictionary<string, object>? ComponentParameters { get; set; }
    }
}
