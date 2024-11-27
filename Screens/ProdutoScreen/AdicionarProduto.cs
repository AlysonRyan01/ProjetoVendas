using System.Globalization;
using Microsoft.VisualBasic;
using ProjetoVendas.Data;
using ProjetoVendas.Models;
using ProjetoVendas.Screens.MenuScreen;

namespace ProjetoVendas.Screens.ProdutoScreen
{
    public class AdicionarProduto
    {
        VendasDataContext context = new VendasDataContext();

        public void adicionar()
        {
            var produto = ValidarProduto();
            if(produto == null)
                Menu.menu();
            
            context.Produtos.Add(produto);
            context.SaveChanges();
            Console.Clear();
            Menu.menu();
        }

        private Produto ValidarProduto()
        {
            var produto = new Produto();
            string titulo = "";
            string tipoProduto = "";
            string marca = "";
            string modelo = "";
            string serie = "";
            decimal preco = 0.00m;
            string garantia = "";

            while(true)
            {
                System.Console.WriteLine("Digite o titulo do produto: ");
                titulo = Console.ReadLine();
                if(titulo.Length <= 4)
                {
                    System.Console.WriteLine("Erro. Digite um titulo maior.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        return null;

                    continue;
                }
                break;
            }

            while(true)
            {
                System.Console.WriteLine("Digite o tipo de produto: ");
                tipoProduto = Console.ReadLine();
                if(tipoProduto.Length <= 1)
                {
                    System.Console.WriteLine("Erro. Digite um tipo de produto existente.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        return null;

                    continue;
                }
                break;
            }

            while(true)
            {
                System.Console.WriteLine("Digite a marca do produto: ");
                marca = Console.ReadLine();
                if(marca.Length <= 1)
                {
                    System.Console.WriteLine("Erro. Digite uma marca existente.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        return null;

                    continue;
                }
                break;
            }

            while(true)
            {
                System.Console.WriteLine("Digite o modelo do produto: ");
                modelo = Console.ReadLine();
                if(marca.Length <= 1)
                {
                    System.Console.WriteLine("Erro. Digite um modelo existente.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        return null;

                    continue;
                }
                break;
            }

            while(true)
            {
                System.Console.WriteLine("Digite a serie do produto: ");
                serie = Console.ReadLine();
                if(serie.Length <= 1)
                {
                    System.Console.WriteLine("Erro. Digite uma serie existente.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        return null;

                    continue;
                }
                break;
            }

            while(true)
            {
                System.Console.WriteLine("Digite o preco do produto: ");
                preco = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if(preco <= 0.00m)
                {
                    System.Console.WriteLine("Erro. Digite um preco maior que 0.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        return null;

                    continue;
                }
                break;
            }

            while(true)
            {
                System.Console.WriteLine("Digite a garantia do produto: ");
                garantia = Console.ReadLine();
                if(garantia.Length <= 0)
                {
                    System.Console.WriteLine("Erro. Digite uma garantia.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        return null;

                    continue;
                }
                break;
            }

            while(true)
            {
                System.Console.WriteLine("Quantas imagens voce vai adicionar: ");
                int imagens = int.Parse(Console.ReadLine());
                if(imagens < 1)
                {
                    System.Console.WriteLine("Erro. Adicione ao menos 1 imagem.");
                    System.Console.WriteLine("1 - voltar ao menu");
                    System.Console.WriteLine("2 - Tentar novamente");
                    int opcao = int.Parse(Console.ReadLine());

                    if(opcao == 1) 
                        return null;

                    continue;
                }
                for(int i = 0; i < imagens; i++)
                {
                    var produtoImagens = new ProdutoImagens();
                    System.Console.WriteLine("Qual imagem: ");
                    string imagemUrl = Console.ReadLine();
                    produtoImagens.ImagemUrl = imagemUrl;
                    produto.ProdutoImagens.Add(produtoImagens);
                }
                break;
            }
            produto.Titulo = titulo;
            produto.TipoProduto = tipoProduto;
            produto.Marca = marca;
            produto.Modelo = modelo;
            produto.Serie = serie;
            produto.Preco = preco;
            produto.Garantia = garantia;

            return produto;
        } 
    }
}