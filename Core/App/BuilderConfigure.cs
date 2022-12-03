namespace DotnetExample.Core.App;
public class BuilderConfigure
{
    private readonly WebApplicationBuilder _builder;

    public BuilderConfigure(WebApplicationBuilder builder)
    {
        _builder = builder;
    }

    public void Configure()
    {
        ConfigureServices();
    }

    private void ConfigureServices()
    {
        new ServiceConfigure(_builder.Services).Configure();
    }
}