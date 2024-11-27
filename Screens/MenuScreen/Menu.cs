using ProjetoVendas.Data;
using ProjetoVendas.Models;
using ProjetoVendas.Screens.CatalogoScreen;
using ProjetoVendas.Screens.ProdutoScreen;

namespace ProjetoVendas.Screens.MenuScreen
{
    public static class Menu
    {
        public static void menu()
        {
            var adicionarProduto = new AdicionarProduto();
            var catalogo = new Catalogo();
            System.Console.WriteLine("1 - Ver catalogo");
            System.Console.WriteLine("2 - Ver carrinho");
            System.Console.WriteLine("3 - finalizar compra (carrinho)");
            int opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    catalogo.CatalogoProdutos();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    adicionarProduto.adicionar();
                    break;
            }
        }
    }
}