using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace EpamTask.PrivateLibrary
{
    [RunInstaller(true)]
    public partial class LibraryInstaller : Installer
    {
        public LibraryInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            var con = "Server=" + Context.Parameters["Server"] + "; Database=" + Context.Parameters["Database"] + ";Trusted_Connection=True;";

            var map = new ExeConfigurationFileMap();

            var configFile = string.Concat(Assembly.GetExecutingAssembly().Location, ".config");
            map.ExeConfigFilename = configFile;
            var config = ConfigurationManager.
            OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var connectionsection = config.ConnectionStrings.ConnectionStrings
            ["MainConnectionString"].ConnectionString;
            ConnectionStringSettings connectionstring = null;
            if (connectionsection != null)
            {
                config.ConnectionStrings.ConnectionStrings.Remove("MainConnectionString");
            }
            connectionstring = new ConnectionStringSettings("MainConnectionString", con);
            config.ConnectionStrings.ConnectionStrings.Add(connectionstring);
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
