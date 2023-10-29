using Microsoft.Extensions.DependencyInjection;

namespace Enter.UI.Abstractions;

public interface IEntConfiguration
{
    public IServiceCollection Services { get; set; }
}