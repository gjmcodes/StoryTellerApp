using StoryTeller.CrossCutting.Disposable;

namespace StoryTellerTemplate.Factories
{
    public class BaseFactory : DisposableObject
    {
        protected override void ReleaseResources()
        {
        }
    }
}
