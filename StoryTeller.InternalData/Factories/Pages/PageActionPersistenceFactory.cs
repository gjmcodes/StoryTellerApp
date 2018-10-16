using StoryTeller.Core.Actions;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Factories.Pages
{
    public class PageActionPersistenceFactory : BaseLocalDataFactory, IPageActionPersistenceFactory
    {
        public async Task<IEnumerable<PageActionDto>> MapPageActionToDtoAsync(IEnumerable<GameAction> pageActions, string pageId)
        {
            return await Task.Run(() =>
            {
                var dtos = new List<PageActionDto>();

                foreach (var item in pageActions)
                {
                    var dto = new PageActionDto();
                    dto.PageId = pageId;
                    dto.Description = item.description;
                    dto.PageIdToNagivate = item.pageIdToNavigate;

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
