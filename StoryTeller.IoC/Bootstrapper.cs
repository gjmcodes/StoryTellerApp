using Prism.Ioc;
using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.ContentTranslation.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.External.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.CharactersData;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.NameCalls;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Pages;
using StoryTeller.Core.Interfaces.Repositories.Local.Persistence.Users;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Core.Services.ContentTranslation;
using StoryTeller.CrossCutting.User.Interfaces.Services;
using StoryTeller.CrossCutting.User.Preferences;
using StoryTeller.CrossCutting.User.Services.Status;
using StoryTeller.ExternalData.FireBase.Pages;
using StoryTeller.ExternalData.FireBase.Rooms;
using StoryTeller.InternalData.Repositories.Persistence.NameCalls;
using StoryTeller.InternalData.Repositories.Persistence.Pages;

public static class Bootstrapper
{
    public static void RegisterDependencies(this IContainerRegistry containerRegistry)
    {
        RegisterDomainServices(containerRegistry);
        RegisterExternalRepositories(containerRegistry);
        RegisterCrossCuttingServices(containerRegistry);
    }

    static void RegisterDomainServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<INameCallTranslatorService, NameCallTranslatorService>();
        containerRegistry.Register<IFontAttributeTranslatorService, FontAttributeTranslatorService>();
        containerRegistry.Register<ICharacterDataTranslatorService, CharacterDataTranslatorService>();
        containerRegistry.Register<IContentMarkupTranslatorService, ContentMarkupTranslatorService>();

        containerRegistry.Register<NameCallContentFormatter>();
    }

    static void RegisterInternalRepositories(IContainerRegistry containerRegistry)
    {
        
        containerRegistry.Register<IUserStatusPersistentRepository, >();
        containerRegistry.Register<ICharacterDataLocalPersistentRepository, >();
        containerRegistry.Register<IPronoumLocalPersistentRepository, PronoumPersistentRepository>();
        containerRegistry.Register<IPageLocalPersistentRepository, PagePersistentRepository>();
    }

    static void RegisterExternalRepositories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IPageExternalRepository, PageWs>();
    }

    static void RegisterCrossCuttingServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IUserStatusService, UserStatusService>();
        containerRegistry.RegisterSingleton<UserPreferences>();
    }
}
