﻿namespace Enter.UI.Abstractions.Core;

public abstract class EntSelectItem<TValue> 
{
    public TValue Value  { get; set; }
    public string Text  { get; set; }
    public string? Icon  { get; set; }

    public bool Selected { get; set; }
    public IEnumerable<EntSelectItem<TValue>>? Childrens { get; set; }
}