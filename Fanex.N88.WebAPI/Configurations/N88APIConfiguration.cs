namespace Fanex.N88.WebAPI.Configurations
{
    using System.Configuration;

    public class N88APIConfiguration : ConfigurationSection
    {
        private static N88APIConfiguration settings
            = ConfigurationManager.GetSection("N88APIConfiguration") as N88APIConfiguration;

        public static N88APIConfiguration Settings
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty("EnableLogging", IsRequired = false, DefaultValue = false)]
        public bool EnableLogging
        {
            get { return (bool)this["EnableLogging"]; }
            set { this["EnableLogging"] = value; }
        }
    }
}