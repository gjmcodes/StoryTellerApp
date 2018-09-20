using Microsoft.Extensions.DependencyInjection;
using StoryCreator.Web.Factories.Rooms;
using StoryCreator.Web.Interfaces.Services.Rooms;
using StoryCreator.Web.Services.Rooms;
using StoryTeller.Core.Interfaces.Repositories.External;
using StoryTeller.Core.Interfaces.Repositories.GameCultures;
using StoryTeller.Core.Interfaces.Services.Rooms;
using StoryTeller.Core.Services.Rooms;
using StoryTeller.CrossCutting.User.Preferences;
using StoryTeller.ExternalData.FireBase.GameCulture;
using StoryTeller.ExternalData.FireBase.Rooms;

namespace StoryCreator.Web.IoC
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            RegisterAppServices(services);
            RegisterDomainServices(services);
            RegisterFactories(services);
            RegisterRepositories(services);
        }

        static void RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IRoomAppService, RoomAppService>();
        }

        static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<StoryTeller.Core.ContentTranslation.ContentMarkupTranslator>();
            services.AddScoped<UserPreferences>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomActionService, RoomActionService>();
            services.AddScoped<IRoomContentService, RoomContentService>();
            services.AddScoped<IRoomEventService, RoomEventService>();
        }

        static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<RoomFactory>();
            services.AddScoped<RoomContentFactory>();
            services.AddScoped<RoomActionFactory>();
        }

        static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IRoomExternalRepository, RoomWs>();
            services.AddScoped<IRoomActionExternalRepository, RoomActionWs>();
            services.AddScoped<IRoomContentExternalRepository, RoomContentWs>();
            services.AddScoped<IRoomEventExternalRepository, RoomEventWs>();
            services.AddScoped<IGameCultureRepository, GameCultureWs>();
        }
    }
}
