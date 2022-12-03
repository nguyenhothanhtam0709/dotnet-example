using AutoMapper;
using DotnetExample.Core.App.Mapper;

namespace DotnetExample.Core.App;

class MapperConfigure
{
    private readonly IServiceCollection _Services;

    public MapperConfigure(IServiceCollection Services)
    {
        _Services = Services;
    }
    public void Configure()
    {
        var autoMapperConfig = new AutoMapper.MapperConfiguration(mc =>
        {
            mc.AddProfile(new PostMappingProfile());
        });

        IMapper mapper = autoMapperConfig.CreateMapper();
        _Services.AddSingleton(mapper);
    }
}