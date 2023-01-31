using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gestran.Models
{
    public class Endereco
    {
        [JsonIgnore, Key]
        public int Id { get; set; }

        [JsonIgnore, Required]
        public int FornecedorId { get; set; }

        [Required]
        public string CEP { get; set; }
        
        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }
        
        public string Complemento { get; set; }

        [Required] 
        public string Cidade { get; set; }

        [Required, StringLength(2, MinimumLength = 2)]
        public string Estado { get; set; }

        [Required] 
        public string Pais { get; set; }

        [JsonIgnore]
        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
