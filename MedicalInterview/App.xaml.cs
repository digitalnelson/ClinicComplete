using MedicalInterview.Common;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226

namespace MedicalInterview
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : MvvmAppBase
    {
        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnInitialize(IActivatedEventArgs args)
        {
            _cont.RegisterInstance<INavigationService>(NavigationService);

            //ViewModelLocator.SetDefaultViewTypeToViewModelTypeResolver((viewType) => { ... return viewModelType; }); }

            //ViewModelLocator.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            //{
            //    var viewModelTypeName = string.Format(CultureInfo.InvariantCulture, "MedicalInterview.ViewModels.{0}, MedicalInterview, Version=1.0.0.0, Culture=neutral, PublicKeyToken=634ac3171ee5190a", viewType.Name);
            //    var viewModelType = Type.GetType(viewModelTypeName);
            //    return viewModelType;
            //});
        }

        protected override object Resolve(Type type)
        {
            return _cont.Resolve(type);
        }

        protected override void OnLaunchApplication(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Timeline", null);
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private readonly IUnityContainer _cont = new UnityContainer();
    }
}
