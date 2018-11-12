﻿using SQLite;
using System.Collections.Generic;

namespace StoryTeller.Xamarin.Domain.Entities.Pages
{
    [Table("TB_PAGES")]
    public class XamarinPage : BaseXamarinModel
    {
        public XamarinPage()
        {
        }

        public XamarinPage(string pageId, string title, string image, string externalVersion)
        {
            PageId = pageId;
            Title = title;
            Image = image;

            base.ExternalTableVersion = externalVersion;
        }

        public string PageId { get; private set; }
        public string Title { get; private  set; }
        public string Image { get; private  set; }

        [Ignore]
        public IEnumerable<XamarinPageAction> PageActions { get; set; }

        [Ignore]
        public IEnumerable<XamarinPageContent> PageContent{ get; set; }

    }
}