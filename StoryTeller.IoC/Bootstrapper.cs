using Prism.Ioc;
using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.ContentTranslation.CharactersData;
using StoryTeller.Core.ContentTranslation.FontAttributes;
using StoryTeller.Core.ContentTranslation.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.External.Pronoums;
using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.Core.Interfaces.Repositories.Local.CharactersData;
using StoryTeller.Core.Interfaces.Repositories.Local.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.Local.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Users;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Interfaces.Services.GameContentDownload;
using StoryTeller.Core.Interfaces.Services.Users;
using StoryTeller.Core.Services.ContentTranslation;
using StoryTeller.Core.Services.GameContentDownload;
using StoryTeller.Core.Services.Users;
using StoryTeller.ExternalData.FireBase.GameCulture;
using StoryTeller.ExternalData.FireBase.NameCalls;
using StoryTeller.ExternalData.FireBase.Pages;
using StoryTeller.InternalData.Factories.CharactersData;
using StoryTeller.InternalData.Factories.NameCalls;
using StoryTeller.InternalData.Factories.Pages;
using StoryTeller.InternalData.Interfaces.Factories.CharactersData;
using StoryTeller.InternalData.Interfaces.Factories.NameCalls;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using StoryTeller.InternalData.Interfaces.Services;
using StoryTeller.InternalData.Repositories.CharactersData;
using StoryTeller.InternalData.Repositories.NameCalls;
using StoryTeller.InternalData.Repositories.Pages;
using StoryTeller.InternalData.Repositories.Users;
using StoryTeller.InternalData.Services;
using StoryTeller.ExternalData.FireBase.App;
using StoryTeller.Core.Interfaces.Repositories.External.App;
using StoryTeller.InternalData.Factories.App;
using StoryTeller.InternalData.Interfaces.Factories.App;

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
        containerRegistry.Register<IPronoumTranslatorService, PronoumTranslatorService>();
        containerRegistry.Register<IFontAttributeTranslatorService, FontAttributeTranslatorService>();
        containerRegistry.Register<ICharacterDataTranslatorService, CharacterDataTranslatorService>();
        containerRegistry.Register<IContentMarkupTranslatorService, ContentMarkupTranslatorService>();

        containerRegistry.Register<IFontAttributeTranslatorService, FontAttributeTranslatorService>();
        containerRegistry.Register<ICharacterDataTranslatorService, CharacterDataTranslatorService>();
        containerRegistry.Register<IPronoumTranslatorService, PronoumTranslatorService>();
        containerRegistry.Register<IParagraphTranslatorService, ParagraphTranslatorService>();


        containerRegistry.Register<NameCallContentFormatter>();
        containerRegistry.Register<FontAttributeContentFormatter>();
        containerRegistry.Register<CharacterDataFormatter>();

        containerRegistry.Register<IPageDownloadTasksService, PageDownloadTasksService>();
        containerRegistry.Register<INameCallDownloadTasksService, NameCallDownloadTasksService>();
    }

    static void RegisterInternalRepositories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IUserStatusLocalRepository, UserStatusPersistentRepository>();
        containerRegistry.Register<ICharacterDataLocalRepository, CharacterDataRepository>();
        containerRegistry.Register<IPronoumLocalRepository, PronoumRepository>();
        containerRegistry.Register<IPageLocalRepository, PageRepository>();
    }

    static void RegisterInternalDataServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<ILocalDataManagerService, LocalDataManagerService>();
    }

    static void RegisterInternalFactories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<ICharacterLocalDataFactory, CharacterLocalDataFactory>();
        containerRegistry.Register<IPronoumLocalDataFactory, PronoumLocalDataFactory>();

        containerRegistry.Register<IPageDtoPersistenceFactory, PageDtoPersistenceFactory>();
        containerRegistry.Register<IPageActionPersistenceFactory, PageActionPersistenceFactory>();
        containerRegistry.Register<IPageContentPersistenceFactory, PageContentPersistenceFactory>();
        containerRegistry.Register<IAppDictionaryFactory, AppDictionaryFactory>();
    }

    static void RegisterExternalRepositories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IGameCultureRepository, GameCultureWs>();
        containerRegistry.Register<IPageExternalRepository, PageWs>();
        containerRegistry.Register<IPronoumsNameCallsExternalRepository, PronoumNameCallWs>();
        containerRegistry.Register<IAppDictionaryExternalRepository, AppDictionaryWs>();
    }

    static void RegisterCrossCuttingServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IUserStatusService, UserStatusService>();
    }
}
