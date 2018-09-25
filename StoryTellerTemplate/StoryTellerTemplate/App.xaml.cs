using Prism;
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

            await NavigationService.NavigateAsync("NavigationPage/CharacterCreation");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterAppServices(containerRegistry);
            RegisterFactories(containerRegistry);

            containerRegistry.RegisterDependencies();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<CharacterCreation>();

        }

        void RegisterAppServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IGameContentAppService, GameContentAppService>();
        }

        void RegisterFactories(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITextSpanFactory, TextSpanFactory>();
            containerRegistry.Register<IRoomVmFactory, RoomVmFactory>();
            containerRegistry.Register<IGameActionVmFactory, GameActionVmFactory>();
            containerRegistry.Register<IPageVmFactory, PageVmFactory>();

        }
    }
}
