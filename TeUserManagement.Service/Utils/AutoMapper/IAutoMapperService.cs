namespace TeUserManagement.Service.Utils.AutoMapper
{
    public interface IAutoMapperService
    {
        public TargetModel MapObjects<SourceModel, TargetModel>(SourceModel sourceObject);
    }
}
