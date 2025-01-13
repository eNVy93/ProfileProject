using CSVParser;
using ProfileProjectV2.Model;

namespace ProfileProjectV2.Services
{
    public interface IBankStatementService<T>
    {
        List<T> GetAll();
        Task<PagedResponseOffset<T>> GetWithOffsetPagination(int pageNumber, int pageSize);
        void InsertBankStatementList(List<T> listToInsert);
        List<T> ParseBankStatementCSVToList(IFormFile file);
    }
}