using Microsoft.Extensions.DependencyInjection;

namespace Enter.Ui.Cores;

public interface IEntConfiguration
{
    public IServiceCollection Services { get; set; }
}