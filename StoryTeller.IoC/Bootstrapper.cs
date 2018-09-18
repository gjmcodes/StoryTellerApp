using Prism.Ioc;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.Core.Services.Rooms;
using StoryTeller.CrossCutting.User.Interfaces.Services;
using StoryTeller.CrossCutting.User.Preferences;
using StoryTeller.CrossCutting.User.Services.Status;
using StoryTeller.ExternalData.FireBase.Rooms;
using System;

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
        containerRegistry.Register<IRoomService, RoomService>();
        containerRegistry.Register<IRoomContentService, RoomContentService>();
        containerRegistry.Register<IRoomEventService, RoomEventService>();
        containerRegistry.Register<IRoomActionService, RoomActionService>();
        containerRegistry.Register<IRoomActionService, RoomActionService>();
    }

    static void RegisterExternalRepositories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IRoomExternalRepository, RoomWs>();
        containerRegistry.Register<IRoomContentExternalRepository, RoomContentWs>();
        containerRegistry.Register<IRoomEventExternalRepository, RoomEventWs>();
        containerRegistry.Register<IRoomActionExternalRepository, RoomActionWs>();
    }

    static void RegisterCrossCuttingServices(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IUserStatusService, UserStatusService>();
        containerRegistry.RegisterSingleton<UserPreferences>();
    }
}
