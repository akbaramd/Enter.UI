using Enter.UI.Abstractions.Components.TreeView;
using Enter.UI.Components;

namespace Enter.Dashboard.Model;

public class Roles 
{
    public Guid Id { get; set; }
    public string Text { get; set; }


    public string Value { get; set; }
    public IEnumerable<Roles> Childrens { get; set; }
    public Guid ParentId { get; set; }
}