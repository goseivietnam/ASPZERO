using AutoMapper;
using MyFisrtProjectASPNETZERO.Tasks;

namespace MyFisrtProjectASPNETZERO
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CreateTaskInput,Task>();
        }
    }
}
