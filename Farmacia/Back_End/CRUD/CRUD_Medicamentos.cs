using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.ConexaoBanco;

namespace Farmacia.Back_End.CRUD
{
    public class CRUD_Medicamentos
    {


        public void Inserir_Medicamento(string nome, string descricao, string tipo, double preco, int estoque_atual, DateTime data_validade)
        {
            using (var con = new Conexao())
            {
                data_validade = data_validade.ToUniversalTime();
                con.Medicamentos.Add(new Medicamentos
                {
                    nome = nome,
                    descricao = descricao,
                    tipo = tipo,
                    preco = preco,
                    estoque_atual = estoque_atual,
                    data_validade = data_validade
                });
                con.SaveChanges();
                Console.WriteLine("Medicamento inserido com sucesso!");
            }
        }

        public List<Medicamentos> Consultar_Medicamento(int id)
        {
            try
            {
                using (var con = new Conexao())
                {
                    var med = con.Medicamentos
                                    .Where(v => v.id == id)  // Filtra pelas med do medicamento com o id fornecido
                                    .ToList();  // Retorna a lista de med

                    return med;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Medicamentos>();  // Retorna uma lista vazia em caso de erro
            }
        }

        public List<Medicamentos> ConsultarMedicamentosId(int id)
        {
            using (var con = new Conexao())
            {
                var medicamentos = con.Medicamentos
                                    .Where(v => v.id == id)  // Filtra pelas med do medicamento com o id fornecido
                                    .ToList();
                return medicamentos;

            }
        }

        public void Listar_Medicamentos1()
        {
            using (var con = new Conexao())
            {
                var medicamentos = con.Medicamentos.ToList();
                foreach (var medicamento in medicamentos)
                {
                    Console.WriteLine($"ID: {medicamento.id}, Nome: {medicamento.nome}, Preço: {medicamento.preco}");
                }
            }
        }


        public List<Medicamentos> Listar_MedicamentosValidade()
        {
            using (var con = new Conexao())
            {
                var medicamentos = con.Medicamentos.OrderBy(m => m.data_validade).ToList();
                return medicamentos;
            }
        }


        public void Deletar_Medicamento(int id)
        {
            using (var con = new Conexao())
            {
                var medicamento = con.Medicamentos.Find(id);
                if (medicamento != null)
                {
                    con.Medicamentos.Remove(medicamento);
                    con.SaveChanges();
                    Console.WriteLine("Medicamento deletado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento não encontrado!");
                }
            }
        }

        public void Atualizar_Medicamento(int id, string nome, string descricao, string tipo, double preco, int estoque_atual, DateTime data_validade)
        {
            using (var con = new Conexao())
            {
                data_validade = data_validade.ToUniversalTime();
                var medicamento = con.Medicamentos.Find(id);
                if (medicamento != null)
                {
                    medicamento.nome = nome;
                    medicamento.descricao = descricao;
                    medicamento.tipo = tipo;
                    medicamento.preco = preco;
                    medicamento.estoque_atual = estoque_atual;
                    medicamento.data_validade = data_validade;
                    con.SaveChanges();
                    Console.WriteLine("Medicamento atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Medicamento não encontrado!");
                }
            }
        }
    }
}
