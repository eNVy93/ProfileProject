using CSVParser;
using Microsoft.EntityFrameworkCore;
using ProfileProjectV2.Model;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;

namespace ProfileProjectV2.Services
{
    public class SwedbankStatementService : IBankStatementService<SwedbankStatement>
    {
        public AppDbContext _dbContext { get; set; }

        public SwedbankStatementService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SwedbankStatement> ParseBankStatementCSVToList(IFormFile file)
        {
            // TODO exception handling
            try
            {
                if (file == null || file.Length == 0)
                {
                    return null;
                }
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    return CSVParserService.ParseCsvToList<SwedbankStatement>(memoryStream);
                }
            }
            catch
            {
                // throw exceptions?
                return null;
            }
        }

        public List<SwedbankStatement> GetStatementListForMonth(int month, IFormFile file)
        {
            List<SwedbankStatement> statementList = ParseBankStatementCSVToList(file);
            // TODO exception handling
            if (statementList == null)
            {
                return null;
            }

            return statementList.Where(s => s.Date != DateTime.MinValue && s.Date.Month == month).ToList();
        }

        public void InsertBankStatementList(List<SwedbankStatement> listToInsert)
        {
            _dbContext.SwedbankStatements.AddRange(listToInsert);
            _dbContext.SaveChangesAsync();
        }

        public List<SwedbankStatement> GetAll()
        {
            var result = _dbContext.SwedbankStatements.ToList();
            return result;
        }

        public virtual async Task<PagedResponseOffset<SwedbankStatement>> GetWithOffsetPagination(int pageNumber, int pageSize)
        {
            // TODO pasigilinti i DTO ir mappinimus
            var totalRecords = await _dbContext.SwedbankStatements.AsNoTracking().CountAsync();

            var entities = await _dbContext.SwedbankStatements.AsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
            .ToListAsync();

            var pagedResponse = new PagedResponseOffset<SwedbankStatement>(entities, pageNumber, pageSize, totalRecords);

            return pagedResponse;
        }
    }
}
