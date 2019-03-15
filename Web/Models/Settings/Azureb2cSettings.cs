namespace NetWorth.Web.Models.Settings
{
    public class AzureB2CSettings
    {
        public string ClientId { get; set; }
        public string Tenant { get; set; }
        public string[] LoginPageCors { get; set; }
        public string SignUpInPolicyName { get; set; }
        public string PasswordResetPolicyName { get; set; }
    }
}
