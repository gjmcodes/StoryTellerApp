﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoryTeller.InternalData.DTOs.PersistentObjects.Pages
{
    [Table("TB_PAGES")]
    public class PageDto : BasePersistentObject
    {
        public string PageId { get; set; }
        public string Content { get; set; }
    }
}
