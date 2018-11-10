using StoryTeller.Core.Disposing;

namespace StoryTeller.Xamarin.Domain.Factories
{
    public abstract class BaseFactory : DisposableObject
    {
        protected override void ReleaseResources()
        {
        }
    }
}
