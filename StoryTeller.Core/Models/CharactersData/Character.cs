using StoryTeller.Core.Models;
using System;

namespace StoryTeller.Core.CharactersData
{
    public class Character
    {
        public Character(string name, bool gender)
        {
            Name = name;
            Gender = gender;
        }

        public string UserId { get; private set; }

        public string CharacterId { get; private set; }

        public string Name { get; private set; }

        public bool Gender { get; private set; }

        public bool IsFemale => Gender;

        public static Character CreateNewCharacter(string name, bool gender, string userId)
        {
            var chara = new Character(name, gender);
            chara.UserId = userId;
            chara.CharacterId = Guid.NewGuid().ToString();

            return chara;
        }
    }
}
