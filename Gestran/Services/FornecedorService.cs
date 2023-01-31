using Gestran.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net;

namespace Gestran.Services
{
    public class FornecedorService : BaseService<Fornecedor>, IFornecedorService
    {
        public FornecedorService(GestranDbContext gestranDbContext) : base(gestranDbContext)
        {
        }

        public async Task<CustomResponse> CadastrarAsync(Fornecedor fornecedor)
        {
            var response = new CustomResponse();

            if (await Any(x => x.CNPJ == fornecedor.CNPJ))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add("O CNPJ informado já foi cadastrado");
            }

            if (!Validadores.CNPJValido(fornecedor.CNPJ))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add("O CNPJ informado é inválido");
            }

            if (!Validadores.SomenteNumeros(fornecedor.Telefone))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add("Informe somente números para o campo telefone");
            }

            if (fornecedor.Telefone.Length is not 11)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add("O telefone deve conter 11 dígitos");
            }

            if (!response.HasError)
            {
                await Add(fornecedor);

                response.Data = fornecedor;
            }

            return response;
        }

        public async Task<CustomResponse> EditarAsync(Fornecedor fornecedor)
        {
            var response = new CustomResponse();

            if (await Any(x => x.Id != fornecedor.Id && x.CNPJ == fornecedor.CNPJ))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add("O CNPJ informado já foi cadastrado");
            }

            if (!Validadores.CNPJValido(fornecedor.CNPJ))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add("O CNPJ informado é inválido");
            }

            if (!Validadores.SomenteNumeros(fornecedor.Telefone))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add("Informe somente números para o campo telefone");
            }

            if (fornecedor.Telefone.Length is not 11)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors.Add("O telefone deve conter 11 dígitos");
            }

            if (!response.HasError)
            {
                fornecedor.Enderecos = null;

                await Update(fornecedor);

                response.Data = fornecedor;
            }

            return response;
        }

        public async Task<CustomResponse> FiltrarAsync(string nome, string cnpj, string cidade)
        {
            IQueryable<Fornecedor> fornecedores = _gestranDbContext.Fornecedores
                .Include(x => x.Enderecos)
                .Where(f => string.IsNullOrEmpty(nome) || f.Nome.ToLower().Contains(nome.ToLower()))
                .Where(f => string.IsNullOrEmpty(cnpj) || f.CNPJ.Contains(cnpj))
                .Where(f => string.IsNullOrEmpty(cidade) || (f.Enderecos.Any(e => e.Cidade.ToLower().Contains(cidade.ToLower()))));


            var response = new CustomResponse()
            {
                Data = await fornecedores.ToListAsync()
            };

            return response;
        }

        public async Task<CustomResponse> ListarAsync()
        {
            var response = new CustomResponse
            {
                Data = await All()
            };

            return response;
        }

        public async Task<CustomResponse> ObterAsync(int id)
        {
            var fornecedor = await First(id);

            var response = new CustomResponse
            {
                Data = fornecedor
            };

            if (fornecedor is null)
            {
                response.Status = "Não encontrado";
                response.StatusCode = HttpStatusCode.NotFound;
            }

            return response;
        }

        public async Task<CustomResponse> RemoverAsync(int id)
        {
            var response = new CustomResponse();

            var fornecedor = await First(id);

            if (fornecedor is not null)
                await Delete(fornecedor);

            if (fornecedor is null)
            {
                response.Status = "Não encontrado";
                response.StatusCode = HttpStatusCode.NotFound;
            }

            return response;
        }
    }
}
