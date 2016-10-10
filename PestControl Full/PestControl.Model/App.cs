using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PestControl.Model;

namespace PestControl.Core
{
    public class App
    {               
        private static ConfigurationVariables _configurations;
        public static ConfigurationVariables Configurations { get { return _configurations ?? (_configurations = new ConfigurationVariables()); } }               
    }
}
