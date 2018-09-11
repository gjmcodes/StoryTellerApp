using Prism.Ioc;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.ExternalData.FireBase.Rooms;
using System;

public static class Bootstrapper
{
    public static void RegisterDependencies(this IContainerRegistry containerRegistry)
    {

    }

    static void RegisterDomainServices(IContainerRegistry containerRegistry)
    {

    }

    static void RegisterExternalRepositories(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IRoomActionExternalRepository, RoomActionWs>();

    }
}
