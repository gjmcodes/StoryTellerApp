using StoryTeller.Core.Text;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Factories.Pages
{
    public class PageContentPersistenceFactory : BaseLocalDataFactory, IPageContentPersistenceFactory
    {
        public async Task<IEnumerable<PageContentDto>> MapPageContentToDtoAsync(IEnumerable<TextSpan> pageContents, string pageId)
        {
            return await Task.Run(() =>
            {
                var dtos = new List<PageContentDto>();

                foreach (var item in pageContents)
                {
                    var dto = new PageContentDto();
                    dto.AmountLineBreaks = item.amountLineBreaks;
                    dto.Content = item.content;
                    dto.FontAttribute = item.fontAttribute.GetHashCode();
                    dto.FontFamily = item.fontFamily;
                    dto.FontSize = item.fontSize.GetHashCode();
                    dto.HexBackgroundColor = item.HexBackgroundColor;
                    dto.HexForegroundColor = item.HexForegroundColor;
                    dto.PageId = pageId;

                    dtos.Add(dto);
                }

                return dtos;
            });
        }

        protected override void ReleaseResources()
        {
        }
    }
}
