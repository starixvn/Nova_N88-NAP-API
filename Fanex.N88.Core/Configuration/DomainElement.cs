namespace Fanex.N88.Core.Configuration
{
    using System.Configuration;

    /// <summary>
    /// Domain Element.
    /// </summary>
    public class DomainElement : ConfigurationElement
    {
        private const string __N88_DOMAIN_NAME = "Name";

        private const string __N88_DOMAIN_PATH = "Path";

        [ConfigurationProperty(__N88_DOMAIN_NAME, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this[__N88_DOMAIN_NAME];
            }

            set
            {
                this[__N88_DOMAIN_NAME] = value;
            }
        }

        [ConfigurationProperty(__N88_DOMAIN_PATH, IsRequired = true)]
        public string Path
        {
            get
            {
                return (string)this[__N88_DOMAIN_PATH];
            }

            set
            {
                this[__N88_DOMAIN_PATH] = value;
            }
        }
    }
}