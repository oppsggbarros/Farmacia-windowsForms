using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmacia.Back_End.Models
{
    [Table("medicamentos")]
    public class Medicamentos
    {
        //[Key]
        [Column("id")]
        public int id { get; set; }
        [Column("nome")]
        public string nome { get; set; }
        [Column("descricao")]
        public string descricao { get; set; }
        [Column("tipo")]
        public string tipo { get; set; }
        [Column("preco")]
        public double preco { get; set; }
        [Column("estoque_atual")]
        public int estoque_atual { get; set; }
        [Column("data_validade")]
        public DateTime data_validade { get; set; }

    }
}