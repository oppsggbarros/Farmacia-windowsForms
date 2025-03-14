using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmacia.Back_End.Models
{
    [Table("fornecedores_medicamentos")]
    public class Fornecedores_Medicamentos
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        [Column("medicamento_id")]
        public int medicamento_id { get; set; }
        [Column("fornecedor_id")]
        public int fornecedor_id { get; set; }
        [ForeignKey("medicamento_id")]
        public Medicamentos medicamento { get; set; }
        [ForeignKey("fornecedor_id")]
        public Fornecedores fornecedor { get; set; }
        [Column("quantidade")]
        public int quantidade { get; set; }
        [Column("data_entrega")]
        public DateTime data_entrega { get; set; }
    }
}