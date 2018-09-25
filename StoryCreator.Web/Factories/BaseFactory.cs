using StoryTeller.CrossCutting.Disposable;

namespace StoryCreator.Web.Factories
{
    public abstract class BaseFactory : DisposableObject
    {
        protected override void ReleaseResources()
        {
        }
    }
}
