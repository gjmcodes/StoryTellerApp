using StoryTeller.Core.Models;

namespace StoryTeller.Core.CharactersData
{
    public class Character
    {
        public Character(string name, bool gender)
        {
            Name = name;
            Gender = gender;
        }

        public string Name { get; private set; }

        public bool Gender { get; private set; }

        public bool IsFemale => Gender;
    }
}
