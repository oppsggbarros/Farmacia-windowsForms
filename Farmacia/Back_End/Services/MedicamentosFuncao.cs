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
     private double Funcao_Preco_Medicamento(int codigoMedicamento, int quantidade)
        {
            using (var contexto = new Conexao())
            {
                var medicamento = contexto.Medicamentos.FirstOrDefault(m => m.id == codigoMedicamento);

                if (medicamento == null)
                {
                    MessageBox.Show("Medicamento não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }

                return medicamento.preco;
            }
        }
}
