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
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;
        [Column("cnpj")]
        public string Cnpj { get; set; } = string.Empty;
        [Column("telefone")]
        public string Telefone { get; set; } = string.Empty;
        [Column("endereco")]
        public string Endereco { get; set; } = string.Empty;

    }
}