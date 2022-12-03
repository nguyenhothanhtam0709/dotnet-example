namespace DotnetExample.Core.App;

public class AppConfigure
{
    private readonly WebApplication _app;

    public AppConfigure(WebApplication app)
    {
        _app = app;
    }

    public void Configure()
    {
        ConfigureSwagger();

        ConfigureCors();

        _app.UseHttpsRedirection();

        _app.UseAuthorization();

        _app.MapControllers();
    }

    private void ConfigureSwagger()
    {
        // Configure the HTTP request pipeline.
        if (_app.Environment.IsDevelopment())
        {
            _app.UseSwagger();
            _app.UseSwaggerUI();
        }
    }

    private void ConfigureCors()
    {
        _app.UseCors(CorsPolicyEnum.DevCorsPolicy);
    }
}