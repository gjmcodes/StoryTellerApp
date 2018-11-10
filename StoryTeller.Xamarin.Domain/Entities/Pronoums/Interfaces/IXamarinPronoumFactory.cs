﻿using StoryTeller.Core.Disposing;
using StoryTeller.Core.Models.NameCalls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.Xamarin.Domain.Entities.Pronoums.Interfaces
{
    public interface IXamarinPronoumFactory : IDisposableObject
    {
        Task<XamarinPronoum> MapPronoumToXamarin(PronoumNameCall pronoum);
        Task<IEnumerable<XamarinPronoum>> MapPronoumToXamarin(IEnumerable<PronoumNameCall> pronoums);
    }
}
