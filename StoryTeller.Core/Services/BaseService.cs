using StoryTeller.CrossCutting.Disposable;

namespace StoryTeller.Core.Services
{
    public class BaseService : DisposableObject
    {
        protected override void ReleaseResources()
        {
        }
    }
}
