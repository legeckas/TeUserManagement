using AutoMapper;

namespace TeUserManagement.Service.Utils.AutoMapper
{
    public class AutoMapperService : IAutoMapperService
    {
        private IMapper _mapperInstance;

        public AutoMapperService()
        {
            _mapperInstance = new Mapper(AutoMapperMappings.GetMapperConfig());
        }

        public TargetModel MapObjects<SourceModel, TargetModel>(SourceModel sourceObject)
        {
            return _mapperInstance.Map<SourceModel, TargetModel>(sourceObject);
        }
    }
}
