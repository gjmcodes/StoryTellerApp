﻿using StoryTeller.Core.Models;

namespace StoryTeller.Core.CharactersData
{
    public class Character
    {
        public string Name { get; private set; }

        public bool Gender { get; private set; }

        public bool IsFemale => Gender;
    }
}