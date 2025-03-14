using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.ConexaoBanco;

namespace Farmacia.Back_End.Services
{
    public class VendasService
    {

        public List<Vendas> ListarVendasPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            using (var con = new Conexao())
            {
                return con.Vendas.Where(v => v.data_venda >= dataInicio && v.data_venda <= dataFim).ToList();
            }
        }
    }
}