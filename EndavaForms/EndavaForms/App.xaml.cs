﻿using Prism;
using Prism.Ioc;
using EndavaForms.ViewModels;
using EndavaForms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EndavaForms
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(@"MainPage\NavigationPage\Calculadora");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Calculadora, CalculadoraViewModel>();
            containerRegistry.RegisterForNavigation<ListaRest, ListaRestViewModel>();
            containerRegistry.RegisterForNavigation<LocalDb, LocalDbViewModel>();
            containerRegistry.RegisterForNavigation<RegistroRest, RegistroRestViewModel>();
            containerRegistry.RegisterForNavigation<NuevoRegistro, NuevoRegistroViewModel>();
        }
    }
}
