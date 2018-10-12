using StoryTeller.Core.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.MainPage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTellerTemplate.Factories
{
    public class PageVmFactory : BaseFactory, IPageVmFactory
    {
        private readonly ITextSpanFactory _textSpanFactory;
        private readonly IGameActionVmFactory _gameActionVmFactory;

        public PageVmFactory(ITextSpanFactory textSpanFactory,
            IGameActionVmFactory gameActionVmFactory)
        {
            _gameActionVmFactory = gameActionVmFactory;
            _textSpanFactory = textSpanFactory;
        }

        public PageVm MapPageToPageVm(Page page)
        {
            var pageVm = new PageVm();
            pageVm.Actions = _gameActionVmFactory.MapGameActionToVm(page.actions);
            //pageVm.Content = _textSpanFactory.MapStringToXamarinSpan(page.content.content);

            return pageVm;
        }

        protected override void ReleaseResources()
        {
            _textSpanFactory.Dispose();
            _gameActionVmFactory.Dispose();
            base.ReleaseResources();
        }
    }
}
