using System;
using ProjetoVendas.DomainException;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Data;
using ProjetoVendas.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;
using ProjetoVendas.Clientee;

namespace ProjetoVendas.Screens.LoginScreen
{
    public class Login
    {
        VendasDataContext context = new VendasDataContext();

        public void LoginOuRegistrar()
        {   
            Console.Clear();
            System.Console.WriteLine("BEM VINDO A NOSSA LOJA!");
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Fazer login");
            System.Console.WriteLine("2 - Se registrar");
            System.Console.WriteLine();
            int opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    FazerLogin();
                    break;
                case 2:
                    FazerRegistro();
                    break;
                default:
                    System.Console.WriteLine("Erro. Digite um numero entre 1 e 2");
                    break;
            }
            
        }

        private void FazerLogin()
        {
            Console.Clear();
            var cliente = new Cliente();
            var autorizado = false;
            while(!autorizado)
            {
                System.Console.Write("Digite seu Email: ");
                string email = Console.ReadLine().ToUpper();
                System.Console.WriteLine();
                if(email.Length > 200)
                {
                    Console.WriteLine("Erro. Digite um email corretamente.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                }

                cliente = context.Clientes.AsNoTracking().FirstOrDefault(x => x.Email == email);
                if (cliente == null){
                    Console.WriteLine("Erro. Email nao localizado no banco de dados.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                }

                System.Console.Write("Digite sua senha: ");
                string senha = Console.ReadLine();
                System.Console.WriteLine();
                if(cliente.Senha != senha)
                {
                    System.Console.WriteLine("Erro. Senha incorreta.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                } 
                
                autorizado = true;
            }
            
            System.Console.WriteLine("Cliente localizado com sucesso!");
            Console.Clear();
            ClienteAtual.Cliente = cliente;
        }

        private void FazerRegistro()
        {
            Console.Clear();
            Cliente cliente = null;
            var autorizado = false;
            while(!autorizado)
            {
                System.Console.Write("Digite seu nome: ");
                string nome = Console.ReadLine().ToUpper();
                System.Console.WriteLine();
                if(nome.Length > 120 || nome.Length < 3)
                {
                    System.Console.WriteLine("Erro. Digite um nome menor que 120 caracteres");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                }

                System.Console.Write("Digite seu CPF:");
                string cpf = Console.ReadLine();
                cpf = Regex.Replace(cpf, @"\D", "");
                System.Console.WriteLine();
                if(cpf.Length != 11)
                {
                    System.Console.WriteLine("Erro.Digite um cpf valido.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                }

                System.Console.Write("Digite seu endereco completo: ");
                string endereco = Console.ReadLine().ToUpper();
                System.Console.WriteLine();
                if(endereco.Length > 280 || endereco.Length < 6)
                {
                    System.Console.WriteLine("Erro. Digite uma senha menor que 20 caracteres.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                }

                System.Console.Write("Digite seu telefone: ");
                string fone = Console.ReadLine();
                fone = Regex.Replace(fone, @"\D", "");
                System.Console.WriteLine();
                if(fone.Length > 12 || fone.Length < 5)
                {
                    System.Console.WriteLine("Erro. Digite um telefone correto.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                }

                System.Console.Write("Digite seu email: ");
                string email = Console.ReadLine().ToUpper();
                System.Console.WriteLine();
                if(email.Length > 200 || email.Length < 5)
                {
                    System.Console.WriteLine("Erro. Digite um email valido");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                }

                System.Console.Write("Digite uma senha para sua conta: ");
                string senha = Console.ReadLine();
                System.Console.WriteLine();
                if(senha.Length > 20 || senha.Length < 3)
                {
                    System.Console.WriteLine("Erro. Digite uma senha menor que 20 caracteres.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        LoginOuRegistrar();

                    continue;
                }

                cliente = new Cliente
                {
                    Nome = nome,
                    Cpf = cpf,
                    Fone = fone,
                    Email = email,
                    Senha = senha,
                    Endereco = endereco,
                    Carrinho = new Carrinho()
                };

                autorizado = true;
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
            Console.Clear();
            FazerLogin();
        }
    }
}