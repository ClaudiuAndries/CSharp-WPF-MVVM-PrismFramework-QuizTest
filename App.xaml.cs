using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WpfApp2.Views;

namespace WpfApp2
{
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : PrismApplication
        {
                protected override Window CreateShell()
                {
                        return Container.Resolve<MainPage>();
                }

                protected override void RegisterTypes(IContainerRegistry containerRegistry)
                {

                        containerRegistry.RegisterForNavigation<ViewA>("ViewA");
                }

                private static void NewMethod(IContainerRegistry containerRegistry)
                {
                        containerRegistry.RegisterForNavigation<MainPage>("MainPage");
                }
        }
}
