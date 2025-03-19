using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmacia.Back_End.Models
{
    [Table("vendas")]
    public class Vendas
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("cliente_nome")]
        public string cliente_nome { get; set; } = string.Empty;

        [Column("medicamento_id")]
        public int medicamento_id { get; set; }

        [Column("quantidade")]
        public int quantidade { get; set; }

        [Column("data_venda")]
        public DateTime data_venda { get; set; }

        [Column("valor_total")]
        public decimal valor_total { get; set; }

        [Column("atendente_id")]
        public int atendente_id { get; set; }




        [ForeignKey("atendente_id")]
        public Usuarios arthur { get; set; }
        

        [ForeignKey("medicamento_id")]
        public Medicamentos medicamento { get; set; }  

    }
}