namespace LibraryManager.Models.Configurations.Settings
{
    public class JwtSecret
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}
