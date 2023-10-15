using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enter.UI.Components
{
    public interface IEntTreeView<TType>
    {
        public string? Icon { get; set; }
        public bool Checked { get; set; }
        public List<TType> Childrens { get; set; }
    }
}
