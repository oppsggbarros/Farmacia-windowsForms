using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmacia.Back_End.Models
{
    [Table("Estoques")]
    public class Estoques
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("medicamento_id")]
        public int medicamento_id { get; set; }
        
        [Column("quantidade")]
        public int quantidade { get; set; }
        
        [Column("ultima_atualizacao")]
        public DateTime ultima_atualizacao { get; set; }
        [ForeignKey("medicamento_id")]
        [Column("medicamento_id")]
        public Medicamentos medicamento { get; set; }

    }
}