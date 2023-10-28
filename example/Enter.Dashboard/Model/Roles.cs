using Enter.UI.Components;

namespace Enter.Dashboard.Model;

public class Roles  : IEntTreeViewItem<Roles,string>
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public string? Icon { get; set; }
    public string Value { get; set; }
    public IEnumerable<Roles> Childrens { get; set; }
    public Guid ParentId { get; set; }
}