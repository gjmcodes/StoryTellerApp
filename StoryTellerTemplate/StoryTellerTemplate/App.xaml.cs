﻿using Prism;
using Prism.Ioc;
using StoryTellerTemplate.ViewModels;
using StoryTellerTemplate.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Autofac;
using StoryTellerTemplate.Factories;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Interfaces.Services.GameContent;
using StoryTellerTemplate.Services.GameContent;
using StoryTellerTemplate.Services.CharacterCreation;
using StoryTellerTemplate.Interfaces.Services.CharacterCreation;
using StoryTellerTemplate.Interfaces.Services.CultureSelection;
using StoryTellerTemplate.Services.CultureSelection;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StoryTellerTemplate
{
    public partial class App : PrismApplication
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

            await NavigationService.NavigateAsync("NavigationPage/CultureSelectionPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterAppServices(containerRegistry);
            RegisterFactories(containerRegistry);

            containerRegistry.RegisterDependencies();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<CharacterCreationPage>();
            containerRegistry.RegisterForNavigation<CultureSelectionPage>();
            containerRegistry.RegisterForNavigation<GameMasterPage, GameMasterPageViewModel>();
            containerRegistry.RegisterForNavigation<GamePage, GamePageViewModel>();
        }

        void RegisterAppServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICharacterCreationAppService, CharacterCreationAppService>();
            containerRegistry.Register<IGameContentAppService, GameContentAppService>();
            containerRegistry.Register<ICultureSelectionAppService, CultureSelectionAppService>();
            containerRegistry.Register<IGameContentDownloadAppService, GameContentDownloadAppService>();
            containerRegistry.Register<ICharacterCreationAppService, CharacterCreationAppService>();
        }

        void RegisterFactories(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITextSpanFactory, TextSpanFactory>();
            containerRegistry.Register<IGameActionVmFactory, GameActionVmFactory>();
            containerRegistry.Register<IPageVmFactory, PageVmFactory>();
            containerRegistry.Register<ICultureVmFactory, CultureVmFactory>();
            containerRegistry.Register<ICharacterCreationVmFactory, CharacterCreationVmFactory>();
        }
    }
}
