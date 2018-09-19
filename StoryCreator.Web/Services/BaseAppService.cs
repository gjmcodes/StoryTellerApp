using StoryCreator.Web.Interfaces.Services;
using StoryTeller.CrossCutting.Disposable;
using System;

namespace StoryCreator.Web.Services
{
    public class BaseAppService : DisposableObject, IBaseAppService
    {
        protected override void ReleaseResources()
        {
        }
    }
}
