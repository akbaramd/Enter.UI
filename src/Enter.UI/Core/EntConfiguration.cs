using Enter.UI.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Enter.UI.Core;

public class EntConfiguration : IEntConfiguration
{
    public IServiceCollection Services { get; set; } = default!;
}