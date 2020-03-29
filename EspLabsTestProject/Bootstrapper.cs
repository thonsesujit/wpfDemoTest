using Caliburn.Micro;
using EspLabsTestProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EspLabsTestProject
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        //We are overrinding OnStartup Method here
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<EspLabTestViewModel>();  // This view will be launching on startup
        }
    }
}
