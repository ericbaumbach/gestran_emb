using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestran.Controllers
{
    [Route("api/fornecedores")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet("obter")]
        public async Task<CustomResponse> ObterAsync(int id)
        {
            return await _fornecedorService.ObterAsync(id);
        }

        [HttpGet("listar")]
        public async Task<CustomResponse> ListarAsync(string nome = null, string cnpj = null, string cidade = null)
        {
            return await _fornecedorService.FiltrarAsync(nome, cnpj, cidade);
        }

        [HttpPost("cadastrar")]
        public async Task<CustomResponse> CadastrarAsync(Fornecedor fornecedor)
        {
            return await _fornecedorService.CadastrarAsync(fornecedor);
        }

        [HttpPost("editar")]
        public async Task<CustomResponse> EditarAsync(Fornecedor fornecedor)
        {
            return await _fornecedorService.EditarAsync(fornecedor);
        }

        [HttpGet("remover")]
        public async Task<CustomResponse> RemoverAsync(int id)
        {
            return await _fornecedorService.RemoverAsync(id);
        }
    }
}
