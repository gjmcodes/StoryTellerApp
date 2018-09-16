using StoryTeller.CrossCutting.Disposable;
using StoryTellerTemplate.Interfaces.Services;

namespace StoryTellerTemplate.Services
{
    public abstract class BaseAppService : DisposableObject, IBaseAppService
    {
        protected override void ReleaseResources()
        {
        }
    }
}
