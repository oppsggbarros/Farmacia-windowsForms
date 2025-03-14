using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.ConexaoBanco;

namespace Farmacia.Back_End.Services
{
    public class UsuariosService
    {
        public Usuarios GetClienteTopCompradorUltimoMes()
        {
            var umMesAtras = DateTime.Now.AddMonths(-1);

            
            using (var con = new Conexao())
            {
                var clienteId = con.Vendas
                    .Where(v => v.data_venda >= umMesAtras)
                    .GroupBy(v => v.atendente_id)
                    .OrderByDescending(g => g.Sum(v => v.quantidade))
                    .Select(g => g.Key)
                    .FirstOrDefault(); 

                var cliente = con.Usuarios.FirstOrDefault(u => u.id == clienteId);

                return cliente;
            }
        }
    }
}
