using Microsoft.Extensions.DependencyInjection;

namespace Enter.Ui.Abstractions;

public interface IEntConfiguration
{
    public IServiceCollection Services { get; set; }
}