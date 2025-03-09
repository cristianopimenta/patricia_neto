namespace web.Controller.Interface
{
    public interface IAuthorizeService
    {
        Task Login(string token);
        Task Logout();
    }
}
