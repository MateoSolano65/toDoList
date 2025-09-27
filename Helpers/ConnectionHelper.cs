namespace todoListApi.Helpers
{
    public interface IConnectionHelper
    {
      string GetConnectionString();
    }
    public class ConnectionHelper : IConnectionHelper
    {
      private readonly IConfiguration _configuration;

      public ConnectionHelper(IConfiguration configuration)
      {
        _configuration = configuration;
      }

      public string GetConnectionString()
      {
        return _configuration.GetConnectionString("DefaultConnection");
      }
    }
}
