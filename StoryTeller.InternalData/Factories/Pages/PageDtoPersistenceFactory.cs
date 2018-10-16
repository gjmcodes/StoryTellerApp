using StoryTeller.Core.Pages;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Factories.Pages
{
    public class PageDtoPersistenceFactory : BaseLocalDataFactory, IPageDtoPersistenceFactory
    {
        public async Task<PageDto> MapPageToDtoAsync(Page page)
        {
            return await Task.Run(() =>
            {

                var pageDto = new PageDto();
                pageDto.Content = page.content.content;
                pageDto.PageId = page.pageId;

                return pageDto;
            });
        }

        public async Task<IEnumerable<PageDto>> MapPageToDtoAsync(IEnumerable<Page> pages)
        {
            var dtos = new List<PageDto>();

            foreach (var item in pages)
            {
                dtos.Add(await MapPageToDtoAsync(item));
            }

            return dtos;
        }

        protected override void ReleaseResources()
        {
        }
    }
}
