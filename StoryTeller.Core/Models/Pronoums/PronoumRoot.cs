using System.Collections.Generic;
using System.Linq;

namespace StoryTeller.Core.Models.Pronoums
{
    public class PronoumRoot : BaseEntity
    {
        public Dictionary<string, Pronoum> pronoums;
        public IEnumerable<Pronoum> GetPronoums => pronoums.Select(x => x.Value);
    }
}
