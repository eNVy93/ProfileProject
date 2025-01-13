namespace ProfileProjectV2.Model
{
    using AutoMapper;
    using CSVParser;

    public class PagedResponseMapperProfile : Profile
    {
        public PagedResponseMapperProfile()
        {
            CreateMap(typeof(PagedResponseOffset<>), typeof(PagedResponseOffsetDto<>));
        }
    }
}
