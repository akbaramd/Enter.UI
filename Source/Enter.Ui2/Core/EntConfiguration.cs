using Enter.Ui.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Enter.Ui.Core;

public class EntConfiguration : IEntConfiguration
{
    public IServiceCollection Services { get; set; } = default!;
}