using Prism.Ioc;
using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.ContentTranslation.CharactersData;
using StoryTeller.Core.ContentTranslation.FontAttributes;
using StoryTeller.Core.ContentTranslation.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.External.Pronoums;
using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Interfaces.Services.Users;
using StoryTeller.Core.Services.ContentTranslation;
using StoryTeller.Core.Services.GameContentDownload;
using StoryTeller.Core.Services.Users;
using StoryTeller.ExternalData.FireBase.GameCulture;
using StoryTeller.ExternalData.FireBase.NameCalls;
using StoryTeller.ExternalData.FireBase.Pages;
using StoryTeller.ExternalData.FireBase.App;
using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Repositories;
using StoryTeller.Xamarin.LocalData.Repositories.Pronoums;
using StoryTeller.Xamarin.LocalData.Repositories.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages.Repositories;
using StoryTeller.Xamarin.Domain.Entities.App.Repositories;
using StoryTeller.Xamarin.LocalData.Repositories.App;
using StoryTeller.Xamarin.Domain.Services;
using StoryTeller.Xamarin.Domain.Entities.App.Factories.Interfaces;
using StoryTeller.Xamarin.Domain.Entities.App.Factories;
using StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces;
using StoryTeller.Xamarin.Domain.Factories.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Interfaces;
using StoryTeller.Xamarin.Domain.Entities.Pronoums.Factories;
using StoryTeller.Xamarin.Domain.Entities.CharactersData.Factories.Interfaces;
using StoryTeller.Xamarin.Domain.Entities.CharactersData.Factories;
using StoryTeller.Xamarin.Domain.Interfaces.Services.LocalData;
using StoryTeller.Xamarin.LocalData.Services;
using StoryTeller.Xamarin.LocalData.Repositories.Users;
using StoryTeller.Core.Interfaces.Repositories.Pronoums;
using StoryTeller.Xamarin.Domain.Entities.CharactersData.Repositories;
using StoryTeller.Xamarin.LocalData.Repositories.CharactersData;
using StoryTeller.Core.Interfaces.Repositories.CharactersData;

public static class Bootstrapper
{
    public static void RegisterDependencies(this IContainerRegistry containerRegistry)
    {
        RegisterDomainServices(containerRegistry);
        RegisterExternalRepositories(containerRegistry);
        RegisterLocalRepositories(containerRegistry);
        RegisterInternalDataServices(containerRegistry);
        RegisterInternalFactories(containerRegistry);
        RegisterCrossCuttingServices(containerRegistry);
    }

    static void RegisterDomainServices(IContainerRegistry containerRegistry)
    {
        // CORE
        containerRegistry.Register<IPronoumTranslatorService, PronoumTranslatorService>();
        containerRegistry.Register<IFontAttributeTranslatorService, FontAttributeTranslatorService>();
        containerRegistry.Register<ICharacterDataTranslatorService, CharacterDataTranslatorService>();
        containerRegistry.Register<IContentMarkupTranslatorService, ContentMarkupTranslatorService>();

        containerRegistry.Register<IFontAttributeTranslatorService, FontAttributeTranslatorService>();
        containerRegistry.Register<ICharacterDataTranslatorService, CharacterDataTranslatorService>();
        containerRegistry.Register<IPronoumTranslatorService, PronoumTranslatorService>();
        containerRegistry.Register<IParagraphTranslatorService, ParagraphTranslatorService>();


        containerRegistry.Register<PronoumFormatter>();
        containerRegistry.Register<FontAttributeContentFormatter>();
        containerRegistry.Register<CharacterDataFormatter>();

        //containerRegistry.Register<IPageDownloadTasksService, PageDownloadTasksService>();
        //containerRegistry.Register<INameCallDownloadTasksService, NameCallDownloadTasksService>();
        //containerRegistry.Register<IAppDictionaryDownloadTasksService, AppDictionaryDownloadTasksService>();

        // XAMARIN
        containerRegistry.Register<IGameContentDownloadService, GameContentDownloadService>();
        containerRegistry.Register<ILocalDataManagementService, LocalDataManagementService>();
    }

    static void RegisterLocalRepositories(IContainerRegistry containerRegistry)
    {
        //containerRegistry.Register<IUserStatusLocalRepository, UserStatusPersistentRepository>();
        containerRegistry.Register<ICharacterLocalRepository, CharacterLocalRepository>();
        containerRegistry.Register<ICharacterDataRepository, CharacterLocalRepository>();

        containerRegistry.Register<IPronoumLocalRepository, PronoumLocalRepository>();
        containerRegistry.Register<IPronoumRepository, PronoumLocalRepository>();

        containerRegistry.Register<IPageLocalRepository, PageLocalRepository>();
        containerRegistry.Register<IAppDictionaryLocalRepository, AppDictionaryLocalRepository>();
        containerRegistry.Register<IUserLocalRepository, UserLocalRepository>();
    }

    static void RegisterInternalDataServices(IContainerRegistry containerRegistry)
    {
        //containerRegistry.Register<ILocalDataManagerService, LocalDataManagerService>();
    }

    static void RegisterInternalFactories(IContainerRegistry containerRegistry)
    {
        //containerRegistry.Register<ICharacterLocalDataFactory, CharacterLocalDataFactory>();
        //containerRegistry.Register<IPronoumLocalDataFactory, PronoumLocalDataFactory>();

        //containerRegistry.Register<IPageDtoPersistenceFactory, PageDtoPersistenceFactory>();
        //containerRegistry.Register<IPageActionPersistenceFactory, PageActionPersistenceFactory>();
        //containerRegistry.Register<IPageContentPersistenceFactory, PageContentPersistenceFactory>();
        //containerRegistry.Register<IAppDictionaryFactory, AppDictionaryFactory>();

        containerRegistry.Register<IXamarinPageActionFactory, XamarinPageActionFactory>();
        containerRegistry.Register<IXamarinPageContentFactory, XamarinPageContentFactory>();
        containerRegistry.Register<IXamarinPageFactory, XamarinPageFactory>();

        containerRegistry.Register<IXamarinAppDictionaryFactory, XamarinAppDictionaryFactory>();

        containerRegistry.Register<IXamarinPronoumFactory, XamarinPronoumFactory>();
        containerRegistry.Register<IXamarinCharacterFactory, XamarinCharacterFactory>();
    }

    static void RegisterExternalRepositories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IGameCultureRepository, GameCultureWs>();
        containerRegistry.Register<IPageExternalRepository, PageWs>();
        containerRegistry.Register<IPronoumExternalRepository, PronoumNameCallWs>();
        containerRegistry.Register<IAppDictionaryExternalRepository, AppDictionaryWs>();
    }

    static void RegisterCrossCuttingServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IUserStatusService, UserStatusService>();
    }
}
