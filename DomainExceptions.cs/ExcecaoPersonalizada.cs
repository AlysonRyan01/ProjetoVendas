namespace ProjetoVendas.DomainException
{
    public class ExcecaoPersonalizada : Exception
    {
        public ExcecaoPersonalizada(string message)
            : base(message)
        {
        }
    }
}