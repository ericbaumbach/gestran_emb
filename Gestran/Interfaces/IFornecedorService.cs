using Gestran.Helpers;
using System.Net;

namespace Gestran.Interfaces
{
    public interface IFornecedorService
    {
        Task<CustomResponse> CadastrarAsync(Fornecedor fornecedor);
        Task<CustomResponse> EditarAsync(Fornecedor fornecedor);
        Task<CustomResponse> ListarAsync();
        Task<CustomResponse> FiltrarAsync(string nome, string cnpj, string cidade);
        Task<CustomResponse> ObterAsync(int id);
        Task<CustomResponse> RemoverAsync(int id);
    }
}
