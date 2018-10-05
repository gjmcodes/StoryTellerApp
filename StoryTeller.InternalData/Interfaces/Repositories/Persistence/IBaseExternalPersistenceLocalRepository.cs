using StoryTeller.Core.Interfaces.Repositories;
using StoryTeller.Core.Models;
using StoryTeller.InternalData.DTOs.PersistentObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryTeller.InternalData.Interfaces.Repositories.Persistence
{
    public interface IBaseExternalPersistenceLocalRepository<TPersistentObject, TExternalEntity>  : IBaseRepository<TExternalEntity>
        where TPersistentObject : BasePersistentObject
        where TExternalEntity : BaseExternalEntity
    {
    }
}
