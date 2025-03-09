namespace web.Controller.Interface
{
    public interface IConta
    {
        int Id { get; }
        DateTime? DataVencimento { get; }
        decimal Valor { get; }
    }   
}
