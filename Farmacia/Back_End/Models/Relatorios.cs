using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmacia.Back_End.Models
{
    [Table("relatorios")]
    public class Relatorios
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("descricao")]
        public string descricao { get; set; }
        [Column("data_geracao")]
        public DateTime data_geracao { get; set; }
        [Column("usuario_id")]
        public int usuario_id { get; set; }
        [ForeignKey("usuario_id")]
        public Usuarios Usuarios { get; set; }
    }
}