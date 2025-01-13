namespace ProfileProjectV2.Model
{
    public record PagedResponseOffsetDto<T>(
        int PageNumber, 
        int PageSiez, 
        int TotalPages, 
        int TotalRecords, 
        List<T> Data
    );
}
