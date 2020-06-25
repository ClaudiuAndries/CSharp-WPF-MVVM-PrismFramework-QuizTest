using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using AutolocatorWPF.Views;


namespace AutolocatorWPF
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
                        containerRegistry.RegisterForNavigation<MainPage>("MainPage");

                        containerRegistry.RegisterForNavigation<ViewA>("ViewA");
                }
        }
}
