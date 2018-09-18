using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryTeller.Core.Dialogues;
using StoryTeller.CrossCutting.User.Preferences;

namespace StoryTeller.ExternalData.FireBase.Dialogues
{
    public class DialogueWs : BaseFirebaseWs
    {
        public DialogueWs(UserPreferences userPreferences)
            : base("Dialogues", userPreferences)
        {
        }


        public async Task<Dialogue> GetDialogueById(string dialogueId)
        {
            var data = await base.GetByKeyAsync<Dialogue>(nameof(dialogueId), dialogueId);

            return data.FirstOrDefault();
        }
        protected override void ReleaseResources()
        {
        }
    }
}
