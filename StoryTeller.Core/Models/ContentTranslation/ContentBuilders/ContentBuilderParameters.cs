using StoryTeller.Core.Enums.Text;

namespace StoryTeller.Core.ContentTranslation.ContentBuilders
{
    public struct ContentBuilderParameters
    {
        public FontAttribute fontAttributeOption;

        public ContentBuilderParameters(FontAttribute fontAttributeOption)
        {
            this.fontAttributeOption = fontAttributeOption;
        }
    }
}
