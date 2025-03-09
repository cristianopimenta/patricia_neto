using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web.Controller.Services.Financeiro;

namespace web.Controller.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConciliacaoBancariaController : ControllerBase
    {
        private readonly ConciliacaoBancariaService _conciliacaoService;

        public ConciliacaoBancariaController(ConciliacaoBancariaService conciliacaoService)
        {
            _conciliacaoService = conciliacaoService;
        }

        [HttpPost("importar")]
        public async Task<IActionResult> ImportarXls([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo inválido.");

            var conciliacoes = await _conciliacaoService.ImportarXls(file);
            return Ok(conciliacoes);
        }

        [HttpGet("exportar")]
        public async Task<IActionResult> ExportarXls()
        {
            var file = await _conciliacaoService.ExportarXls();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ConciliacaoBancaria.xlsx");
        }
    }
}

