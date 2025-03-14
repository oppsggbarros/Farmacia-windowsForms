using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.ConexaoBanco;

namespace Farmacia.Back_End.Services
{
    public class MedicamentoService
    {
        public List<Medicamentos> ListarBaixoEstoque(int nivelMinimo)
        {
            using (var con = new Conexao())
            {
                return con.Medicamentos
                          .Where(m => m.estoque_atual < nivelMinimo).ToList();
            }
        }
    }
}
