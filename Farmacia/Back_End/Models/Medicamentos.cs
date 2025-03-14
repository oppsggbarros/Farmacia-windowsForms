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
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("tipo")]
        public string Tipo { get; set; }
        [Column("preco")]
        public double Preco { get; set; }
        [Column("estoque_atual")]
        public int EstoqueAtual { get; set; }
        [Column("data_validade")]
        public DateTime DataValidade { get; set; }

    }
}