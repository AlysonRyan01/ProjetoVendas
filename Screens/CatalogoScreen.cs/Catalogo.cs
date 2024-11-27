using Microsoft.EntityFrameworkCore;
using ProjetoVendas.Clientee;
using ProjetoVendas.Data;
using ProjetoVendas.Models;
using ProjetoVendas.Screens.MenuScreen;

namespace ProjetoVendas.Screens.CatalogoScreen
{
    public class Catalogo
    {
        VendasDataContext context = new VendasDataContext();
        
        public void CatalogoProdutos()
        {
            var produtos = context
                            .Produtos
                            .AsNoTracking()
                            .Include(p => p.ProdutoImagens)
                            .ToList();

            foreach(var produto in produtos)
            {
                System.Console.WriteLine("----------------------------------");
                System.Console.WriteLine($"ID: {produto.Id}");
                System.Console.WriteLine($"Produto: {produto.Titulo}");
                foreach(var imagensProduto in produto.ProdutoImagens)
                {
                    System.Console.WriteLine(imagensProduto.ImagemUrl);
                }
                System.Console.WriteLine("----------------------------------");
                System.Console.WriteLine();
                System.Console.WriteLine();

                AdicionarProdutoAoCarrinho();
            }
        }

        public void AdicionarProdutoAoCarrinho()
        {
            System.Console.WriteLine("Deseja adicionar algum produto ao carrinho? ");
            System.Console.WriteLine("1 - sim");
            System.Console.WriteLine("2 - nao");
            int opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    ValidarProduto();
                    break;
                default:
                    Menu.menu();
                    break;
            }
        }

        private void ValidarProduto()
        {
            while(true)
            {
                var clienteStatico = ClienteAtual.Cliente;
                var clienteId = clienteStatico.Id;
                var cliente = context.Clientes
                .Include(c => c.Carrinho)
                .ThenInclude(c => c.Produtos)
                .FirstOrDefault(x=> x.Id == clienteId);

                System.Console.WriteLine("Qual e o ID do produto: ");
                int produtoId = int.Parse(Console.ReadLine());
                if(produtoId <= 0)
                {
                    System.Console.WriteLine("Erro. Digite um ID de produto existente");
                    System.Console.WriteLine("1 - Tentar novamente");
                    System.Console.WriteLine("2 - Voltar ao catalogo");
                    int opcao = int.Parse(Console.ReadLine());
                    if(opcao == 1)
                        continue;
                    
                    CatalogoProdutos();                   
                }

                var produto = context
                    .Produtos
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == produtoId);

                if(produto == null)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Erro. ID de produto nao encontrado.");
                    System.Console.WriteLine();
                    System.Console.WriteLine("1 - Tentar novamente");
                    System.Console.WriteLine("2 - Voltar ao catalogo");
                    int opcao = int.Parse(Console.ReadLine());
                    if(opcao == 1)
                        continue;
                    
                    CatalogoProdutos();
                }
         
                var carrinho = cliente.Carrinho;

                var produtoNoCarrinho = carrinho.Produtos.FirstOrDefault(p => p.Id == produto.Id);

                if(produtoNoCarrinho != null)
                {
                    System.Console.WriteLine("Erro. Este produto ja esta no seu carrinho.");
                    System.Console.WriteLine();
                    System.Console.WriteLine("1 - Tentar novamente");
                    System.Console.WriteLine("2 - Voltar ao Catalogo");
                    int opcao = int.Parse(Console.ReadLine());
                    if(opcao == 1)
                        continue;
                    
                    CatalogoProdutos();
                }

                System.Console.WriteLine($"Deseja adicionar o produto {produto.Titulo} ao seu carrinho? ");
                System.Console.WriteLine("1 - Sim");
                System.Console.WriteLine("2 - Nao, voltar ao catalogo");
                int opcaoo = int.Parse(Console.ReadLine());
                if(opcaoo != 1)
                    CatalogoProdutos();
                
                
                cliente.Carrinho.Produtos.Add(produto);
                cliente.Carrinho.ValorTotal += produto.Preco;
                context.SaveChanges();
                System.Console.WriteLine();
                System.Console.WriteLine("Produto adicionado com sucesso ao seu carrinho!");
                System.Console.WriteLine();
                System.Console.WriteLine("Deseja adicionar mais algum produto no seu carrinho?");
                System.Console.WriteLine("1 - Sim");
                System.Console.WriteLine("2 - Nao");
                System.Console.WriteLine();
                int opcao3 = int.Parse(Console.ReadLine());
                if(opcao3 != 1)
                    Menu.menu();
                
                CatalogoProdutos();
            }

        }
    }
}