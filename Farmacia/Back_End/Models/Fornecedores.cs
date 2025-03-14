using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmacia.Back_End.Models
{
    [Table("fornecedores")]
    public class Fornecedores
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("nome")]
        public string nome { get; set; } = string.Empty;
        [Column("cnpj")]
        public string cnpj { get; set; } = string.Empty;
        [Column("telefone")]
        public string telefone { get; set; } = string.Empty;
        [Column("endereco")]
        public string endereco { get; set; } = string.Empty;

    }
}