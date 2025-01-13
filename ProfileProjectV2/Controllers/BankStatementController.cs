using AutoMapper;
using CSVParser;
using Microsoft.AspNetCore.Mvc;
using ProfileProjectV2.Model;
using ProfileProjectV2.Services;

namespace ProfileProjectV2.Controllers
{
    // Next session finish up controller
    // Configure application. Run WebApi
    [ApiController]
    [Route("api/bankstatement")]
    public class BankStatementController : ControllerBase
    {
        public IBankStatementService<SwedbankStatement> _bankStatementService;
        private readonly IMapper _mapper;
        public BankStatementController(IBankStatementService<SwedbankStatement> bankStatementService, IMapper mapper)
        {
            _bankStatementService = bankStatementService;
            _mapper = mapper;
        }

        // GET: api/users
        [HttpPost]
        [Route("upload_swedbank_list")]
        public ActionResult UploadSwedbankStatementList(IFormFile file)
        {

            List<SwedbankStatement> statementList = _bankStatementService.ParseBankStatementCSVToList(file);
            if (statementList == null)
            {
                return Problem("Failed to parse swedbank statements from file provided", statusCode: 500);
            }
            _bankStatementService.InsertBankStatementList(statementList);
            return Created("upload_swedbank_list", statementList);
        }

        [HttpGet]
        [Route("get_all_swedbank")]
        public ActionResult GetAllSwedbankStatements()
        {
            return Ok(_bankStatementService.GetAll());
        }

        [HttpGet]
        [Route("get_all_paged")]
        public async Task<IActionResult> GetAllSwedbankStatements(int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest($"{nameof(pageNumber)} and {nameof(pageSize)} size must be greater than 0.");

            var pagedProducts =
                await _bankStatementService.GetWithOffsetPagination(pageNumber, pageSize);

            var pagedProductsDto =
                _mapper.Map<PagedResponseOffsetDto<SwedbankStatement>>(pagedProducts);

            return Ok(pagedProductsDto);
        }
    }
}