using Microsoft.Data.SqlClient;
using ProjetoVendas.Data;
using ProjetoVendas.Models;
using ProjetoVendas.Screens.LoginScreen;
using ProjetoVendas.Screens.MenuScreen;

try
{
    var login = new Login();

    using var context = new VendasDataContext();
    login.LoginOuRegistrar();
    Menu.menu();
}
catch(SqlException e)
{
    System.Console.WriteLine(e.Message);
}
catch(Exception e)
{
    System.Console.WriteLine(e.Message);
}