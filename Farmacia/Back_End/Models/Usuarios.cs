using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmacia.Back_End.Models
{
    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("nome")]
        public string nome { get; set; }
        [Column("cargo")]
        public string cargo { get; set; }
        [Column("cpf")]
        public string cpf { get; set; }
        [Column("senha")]
        public string senha { get; set; }
    }
}