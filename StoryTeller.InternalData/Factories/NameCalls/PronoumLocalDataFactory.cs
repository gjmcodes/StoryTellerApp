using System.Collections.Generic;
using System.Threading.Tasks;
using StoryTeller.Core.Models.Pronoums;
using StoryTeller.InternalData.DTOs.PersistentObjects.NameCalls;
using StoryTeller.InternalData.Interfaces.Factories.NameCalls;

namespace StoryTeller.InternalData.Factories.NameCalls
{
    public class PronoumLocalDataFactory : BaseLocalDataFactory, IPronoumLocalDataFactory
    {
        public async Task<IEnumerable<PronoumNameCallDto>> MapPronoumNameCallToDtoAsync(IEnumerable<Pronoum> models)
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
