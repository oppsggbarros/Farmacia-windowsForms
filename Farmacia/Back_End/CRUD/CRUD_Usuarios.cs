using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Farmacia.Back_End.Models;
using Farmacia.Back_End.ConexaoBanco;

namespace Farmacia.Back_End.CRUD
{
    public class CRUD_Usuarios
    {

        public void Inserir_Usuario(string nome, string cargo, string cpf, string senha)
        {
            try
            {
                using (var con = new Conexao())
                {
                    con.Usuarios.Add(new Usuarios
                    {
                        nome = nome,
                        cargo = cargo,
                        cpf = cpf,
                        senha = senha
                    });

                    con.SaveChanges();
                    Console.WriteLine("Usuário registrado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Detalhes do erro interno: " + ex.InnerException.Message);
            }
        }


        public List<Usuarios> Listar_Usuarios()
        {
            try
            {

                using (var con = new Conexao())
                {
                    return con.Usuarios.ToList();
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
                return new List<Usuarios>();
            }
        }


        public void Atualizar_Usuario(string nome, string cargo, string cpf, string senha)
        {
            try
            {

                using (var con = new Conexao())
                {
                    var usuario = con.Usuarios.FirstOrDefault(u => u.cpf == cpf);
                    if (usuario != null)
                    {
                        if (!string.IsNullOrWhiteSpace(nome))
                        {
                            usuario.nome = nome;
                        }

                        if (!string.IsNullOrWhiteSpace(cargo))
                        {
                            usuario.cargo = cargo;
                        }

                        if (!string.IsNullOrWhiteSpace(cpf))
                        {
                            usuario.cpf = cpf;
                        }

                        if (!string.IsNullOrWhiteSpace(senha))
                        {
                            usuario.senha = senha;
                        }

                        con.SaveChanges();
                        Console.WriteLine("Usuário atualizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Usuário não encontrado!");
                    }
                }

            }

            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        public void Excluir_Usuario(int id)
        {
            try
            {
                using (var con = new Conexao())
                {
                    var usuario = con.Usuarios.Find(id);
                    if (usuario != null)
                    {
                        con.Usuarios.Remove(usuario);
                        con.SaveChanges();
                        Console.WriteLine("Usuário excluído com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Usuário não encontrado!");
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void Mostrar_Usuarios()
        {
            var usuarios = Listar_Usuarios();
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.id}, Nome: {usuario.nome}, Cargo: {usuario.cargo}, CPF: {usuario.cpf}");
            }
        }
    }
}

