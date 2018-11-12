﻿using StoryTeller.Core.Models.Pages.DTOs;
using StoryTeller.Core.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTellerTemplate.Interfaces.Factories;
using StoryTellerTemplate.Models.GameContent;
using StoryTellerTemplate.Models.MainPage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public async Task<PageVm> MapPageToPageVmAsync(XamarinPage page,
            IEnumerable<XamarinPageAction> pageActions,
            IEnumerable<XamarinPageContent> pageContent)
        {
            var pagevm = new PageVm();

            var pgActionsTask = await _gameActionVmFactory.MapGameActionDtoToVmAsync(pageActions);
            pagevm.Actions = pgActionsTask.ToList();

            var pgContentTask = await _textSpanFactory.MapContentToSpanAsync(pageContent);
            pagevm.Content = pgContentTask.ToList();

            return pagevm;
        }

        public PageVm MapPageToPageVm(XamarinPage page)
        {
            var pageVm = new PageVm();

            var pgActionTask = _gameActionVmFactory.MapGameActionToVm(page.PageActions);
            pageVm.Actions = pgActionTask.ToList();

            return pageVm;
        }

        public async Task<PageVm> MapTranslatedPageDtoToPageVmAsync(XamarinPage page)
        {
            var pageVm = new PageVm();
            pageVm.Title = page.Title;
            pageVm.Image = page.Image;

            pageVm.Content = new List<Span>();

            var pageActions = _gameActionVmFactory.MapGameActionToVm(page.PageActions);
            pageVm.Actions = pageActions.ToList();

            var pageContents = await _textSpanFactory.MapContentToSpanAsync(page.PageContent);
            pageVm.Content = pageContents.ToList();

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
