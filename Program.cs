using ProjetoVendas.Data;
using ProjetoVendas.Models;
using ProjetoVendas.Screens.LoginScreen;

try
{
    using var context = new VendasDataContext();
    Login.LoginOuRegistrar(context);
}
catch(Exception e)
{
    System.Console.WriteLine(e.Message);
}