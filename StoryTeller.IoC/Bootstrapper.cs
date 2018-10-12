using Prism.Ioc;
using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.ContentTranslation.CharactersData;
using StoryTeller.Core.ContentTranslation.FontAttributes;
using StoryTeller.Core.ContentTranslation.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.CharactersData;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users;
using StoryTeller.Core.Interfaces.Repositories.Local.ReadOnly.Users;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using StoryTeller.Core.Interfaces.Services.Users;
using StoryTeller.Core.Services.ContentTranslation;
using StoryTeller.Core.Services.GameContentDownload;
using StoryTeller.Core.Services.Users;
using StoryTeller.ExternalData.FireBase.GameCulture;
using StoryTeller.ExternalData.FireBase.Pages;
using StoryTeller.InternalData.Factories.CharactersData;
using StoryTeller.InternalData.Factories.NameCalls;
using StoryTeller.InternalData.Interfaces.Factories.CharactersData;
using StoryTeller.InternalData.Interfaces.Factories.NameCalls;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using StoryTeller.InternalData.Interfaces.Services;
using StoryTeller.InternalData.Repositories.Persistence.CharactersData;
using StoryTeller.InternalData.Repositories.Persistence.NameCalls;
using StoryTeller.InternalData.Repositories.Persistence.Pages;
using StoryTeller.InternalData.Repositories.Persistence.Users;
using StoryTeller.InternalData.Services;

public static class Bootstrapper
{
    public static void RegisterDependencies(this IContainerRegistry containerRegistry)
    {
        RegisterDomainServices(containerRegistry);
        RegisterExternalRepositories(containerRegistry);
        RegisterInternalRepositories(containerRegistry);
        RegisterInternalDataServices(containerRegistry);
        RegisterInternalFactories(containerRegistry);
        RegisterCrossCuttingServices(containerRegistry);
    }

    static void RegisterDomainServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<INameCallTranslatorService, NameCallTranslatorService>();
        containerRegistry.Register<IFontAttributeTranslatorService, FontAttributeTranslatorService>();
        containerRegistry.Register<ICharacterDataTranslatorService, CharacterDataTranslatorService>();
        containerRegistry.Register<IContentMarkupTranslatorService, ContentMarkupTranslatorService>();

        containerRegistry.Register<NameCallContentFormatter>();
        containerRegistry.Register<FontAttributeContentFormatter>();
        containerRegistry.Register<CharacterDataFormatter>();

        containerRegistry.Register<IPageDownloadTasksService, PageDownloadTasksService>();
        containerRegistry.Register<INameCallDownloadTasksService, NameCallDownloadTasksService>();
    }

    static void RegisterInternalRepositories(IContainerRegistry containerRegistry)
    {
        //Criação de repository readonly
        containerRegistry.Register<IUserStatusLocalRepository, UserStatusLocalRepository>();

        containerRegistry.Register<IUserStatusLocalPersistentRepository, UserStatusPersistentRepository>();
        containerRegistry.Register<ICharacterDataLocalPersistentRepository, CharacterDataPersistentRepository>();
        containerRegistry.Register<IPronoumLocalPersistentRepository, PronoumPersistentRepository>();
        containerRegistry.Register<IPageLocalPersistentRepository, PagePersistentRepository>();
    }

    static void RegisterInternalDataServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<ILocalDataManagerService, LocalDataManagerService>();
    }

    static void RegisterInternalFactories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<ICharacterLocalDataFactory, CharacterLocalDataFactory>();
        containerRegistry.Register<IPronoumLocalDataFactory, PronoumLocalDataFactory>();
    //    containerRegistry.Register<IPageActionPersistenceFactory, PageActionPersistenceFactory>();
    //    containerRegistry.Register<IPageContentPersistenceFactory, PageActionPersistenceFactory>();
    //    containerRegistry.Register<IPageDtoPersistenceFactory, PageActionPersistenceFactory>();
    }

    static void RegisterExternalRepositories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IGameCultureRepository, GameCultureWs>();
        containerRegistry.Register<IPageExternalRepository, PageWs>();
    }

    static void RegisterCrossCuttingServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IUserStatusService, UserStatusService>();
    }
}
