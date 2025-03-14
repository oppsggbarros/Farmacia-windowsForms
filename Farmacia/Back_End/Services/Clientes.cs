using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmacia.Back_End.Models;

namespace Farmacia.Back_End.Services
{
    public class Clientes
    {
        public class ClienteService
        {
            private List<Vendas> vendas;

            public ClienteService(List<Vendas> vendas)
            {
                this.vendas = vendas;
            }

            public string ClienteMaisComprouUltimoMes()
            {
                DateTime primeiroDiaMesPassado = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                DateTime ultimoDiaMesPassado = primeiroDiaMesPassado.AddMonths(1).AddDays(-1);

                var comprasNoMes = vendas
                    .Where(v => v.data_venda >= primeiroDiaMesPassado && v.data_venda <= ultimoDiaMesPassado)
                    .GroupBy(v => v.cliente_nome)
                    .OrderByDescending(g => g.Sum(v => v.quantidade))
                    .FirstOrDefault();

                return comprasNoMes?.Key ?? "Nenhum cliente fez compras no último mês";
            }
        }
    }
}