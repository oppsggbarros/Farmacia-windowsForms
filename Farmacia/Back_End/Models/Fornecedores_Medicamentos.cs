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
        public int Id { get; set; }
        [Column("medicamento_id")]
        public int Medicamento_Id { get; set; }
        [Column("fornecedor_id")]
        public int Fornecedor_Id { get; set; }
        [ForeignKey("medicamento_id")]
        public Medicamentos Medicamentos { get; set; }
        [ForeignKey("fornecedor_id")]
        public Fornecedores Fornecedores { get; set; }
        [Column("quantidade")]
        public int Quantidade { get; set; }
        [Column("data_entrega")]
        public DateTime Data_Entrega { get; set; }
    }
}