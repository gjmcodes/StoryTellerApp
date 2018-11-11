using StoryTeller.Core.Enums.Text;
using StoryTeller.Core.Interfaces.Services.ContentTranslation;
using StoryTeller.Xamarin.Domain.Entities.Pages;
using StoryTeller.Xamarin.Domain.Entities.Pages.Factories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Factories.Pages
{
    public class XamarinPageContentFactory : BaseFactory, IXamarinPageContentFactory
    {
        private readonly IContentMarkupTranslatorService _contentMarkupTranslatorService;

        public XamarinPageContentFactory(IContentMarkupTranslatorService contentMarkupTranslatorService)
        {
            _contentMarkupTranslatorService = contentMarkupTranslatorService;
        }

        public async Task<IEnumerable<XamarinPageContent>> MapPageContentToXamarin(string pageContent, string pageId, string pageVersion)
        {
            return await Task.Run(async () =>
            {
                var contents = new List<XamarinPageContent>();

                var translatedContents = await _contentMarkupTranslatorService.TranslateAsync(pageContent);

                foreach (var item in translatedContents)
                {
                    var xamPageContent = new XamarinPageContent
                    (
                        pageId,
                        item.Content,
                        item.hexForegroundColor,
                        item.hexBackgroundColor,
                        item.fontFamily,
                        item.fontSize.GetHashCode(),
                        item.fontAttribute.GetHashCode(),
                        item.lineBreak,
                        item.amountLineBreaks,
                        pageVersion
                    );

                    contents.Add(xamPageContent);
                }

                return contents;
            });
        }

        protected override void ReleaseResources()
        {
            _contentMarkupTranslatorService.Dispose();
        }
    }
}
