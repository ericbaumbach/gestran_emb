using System.ComponentModel.DataAnnotations;

namespace Gestran.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}