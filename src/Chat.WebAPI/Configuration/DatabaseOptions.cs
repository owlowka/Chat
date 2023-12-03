namespace Chat.WebAPI.Configuration
{
    public class DatabaseOptions
    {
        public DatabaseServer Server { get; set; }
    }

    public enum DatabaseServer
    {
        SQLite,
        SqlServer
    }
}
