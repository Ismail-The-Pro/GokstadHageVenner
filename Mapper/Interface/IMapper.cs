namespace GokstadHageVenner.Mapper.Interface
{
    public interface IMapper<TModel, TDto>
    {
        TDto MapToDTO(TModel model);

        TModel MapToModel(TDto dto, Models.Entity.Arrangement arrangement);

    }
}
