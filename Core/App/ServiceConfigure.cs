using DotnetExample.Core.Contexts;
using DotnetExample.Core.Services;

namespace DotnetExample.Core.App;

class CorsPolicyEnum
{
    public static readonly string DevCorsPolicy = "DevCorsPolicy";
    public static readonly string ProdCorsPolicy = "ProdCorsPolicy";
}

class ServiceConfigure
{
    private readonly IServiceCollection _Services;

    public ServiceConfigure(IServiceCollection Services)
    {
        _Services = Services;
    }

    public void Configure()
    {
        // Add services to the container.

        _Services.AddControllers();
        _Services.AddDbContext<DatabaseContext>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _Services.AddEndpointsApiExplorer();
        _Services.AddSwaggerGen();

        ConfigureCors();
        ConfigureMapper();
        AddAppService();
    }

    private void ConfigureCors()
    {
        _Services.AddCors(
            options =>
            {
                // dev policy
                options.AddPolicy(name: CorsPolicyEnum.DevCorsPolicy, policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });

                // prod policy
                options.AddPolicy(name: CorsPolicyEnum.ProdCorsPolicy, policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.SetIsOriginAllowed(origin => true);
                    policy.AllowCredentials();
                });
            }
        );
    }

    private void ConfigureMapper()
    {
        new MapperConfigure(_Services).Configure();
    }

    private void AddAppService()
    {
        _Services.AddScoped<IPostService, PostService>();

    }
}