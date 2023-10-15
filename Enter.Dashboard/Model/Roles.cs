using Enter.UI.Components;

namespace Enter.Dashboard.Model;

public class Roles : IEntTreeView<Roles>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Value { get; set; }
    public string? Icon { get; set; }
    public List<Roles> Childrens { get; set; }
    public bool Checked { get;set; }
}