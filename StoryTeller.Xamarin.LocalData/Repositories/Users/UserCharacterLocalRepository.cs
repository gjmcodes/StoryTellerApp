using StoryTeller.Core.Interfaces.Repositories.Users;
using StoryTeller.Xamarin.Domain.Entities.App;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.LocalData.Repositories.Users
{
    public class UserCharacterLocalRepository : BaseRepository, IUserCharacterRepository
    {
        public async Task<string> GetCharacterCurrentPageAsync()
        {
            var charUserData = await Conn.Table<XamarinUserCharacterData>().FirstAsync();

            return charUserData.CharacterCurrentPageId;
        }
    }
}
