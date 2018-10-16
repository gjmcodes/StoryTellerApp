using System.Collections.Generic;
using System.Threading.Tasks;
using StoryTeller.Core.Models.NameCalls;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using StoryTeller.InternalData.Interfaces.Factories.NameCalls;

namespace StoryTeller.InternalData.Factories.NameCalls
{
    public class PronoumLocalDataFactory : BaseLocalDataFactory, IPronoumLocalDataFactory
    {
        public async Task<IEnumerable<PronoumNameCallDto>> MapPronoumNameCallToDtoAsync(IEnumerable<PronoumNameCall> models)
        {
            return await Task.Run(() =>
            {
                var dtos = new List<PronoumNameCallDto>();

                foreach (var item in models)
                {
                    var dto = new PronoumNameCallDto();
                    dto.PronoumId = item.pronoumId;
                    dto.ForFemale = item.forFemale;
                    dto.ForMale = item.forMale;

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
