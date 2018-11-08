using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.Enums.Text;
using StoryTeller.Core.Text;
using StoryTeller.InternalData.DTOs.PersistentObjects.Pages;
using StoryTeller.InternalData.Interfaces.Factories.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoryTeller.InternalData.Factories.Pages
{
    public class PageContentPersistenceFactory : BaseLocalDataFactory, IPageContentPersistenceFactory
    {
        public async Task<IEnumerable<ContentTranslationDto>> MapDtoToTranslatedContentAsync(IEnumerable<PageContentDto> contents)
        {
            return await Task.Run(() =>
            {
                var translatedContents = new List<ContentTranslationDto>();

                foreach (var item in contents)
                {
                    var translatedContent = new ContentTranslationDto();
                    translatedContent.amountLineBreaks = item.AmountLineBreaks;
                    translatedContent.content = item.Content;
                    translatedContent.fontAttribute = (FontAttribute)item.FontAttribute;
                    translatedContent.fontFamily = item.FontFamily;
                    translatedContent.fontSize = (FontNamedSize)item.FontSize;
                    translatedContent.hexBackgroundColor = item.HexBackgroundColor;
                    translatedContent.hexForegroundColor = item.HexForegroundColor;
                    translatedContent.lineBreak = item.LineBreak;

                    translatedContents.Add(translatedContent);
                }

                return translatedContents;
            });
        }

        public async Task<IEnumerable<PageContentDto>> MapPageContentToDtoAsync(IEnumerable<TextSpan> pageContents, string pageId)
        {
            return await Task.Run(() =>
            {
                var dtos = new List<PageContentDto>();

                foreach (var item in pageContents)
                {
                    var dto = new PageContentDto();

                    dto.LineBreak = item.lineBreak;
                    dto.AmountLineBreaks = item.amountLineBreaks;
                    dto.Content = item.content;
                    dto.FontAttribute = item.fontAttribute.GetHashCode();
                    dto.FontFamily = item.fontFamily;
                    dto.FontSize = item.fontSize.GetHashCode();
                    dto.HexBackgroundColor = item.HexBackgroundColor;
                    dto.HexForegroundColor = item.HexForegroundColor;
                    dto.PageId = pageId;

                    dtos.Add(dto);
                }

                return dtos;
            });
        }

        public async Task<IEnumerable<TextSpan>> MapPageContentDtoToTextSpanAsync(IEnumerable<PageContentDto> pageContentDtos)
        {
            return await Task.Run(() =>
            {

                var textSpans = new List<TextSpan>();

                foreach (var item in pageContentDtos)
                {
                    var txtSpan = new TextSpan();
                    txtSpan.amountLineBreaks = item.AmountLineBreaks;
                    txtSpan.content = item.Content;
                    txtSpan.fontAttribute = (FontAttribute)item.FontAttribute;
                    txtSpan.fontFamily = item.FontFamily;
                    txtSpan.fontSize = (FontNamedSize)item.FontSize;
                    txtSpan.hexForegroundColor = item.HexForegroundColor;
                    txtSpan.hexBackgroundColor = item.HexBackgroundColor;
                    txtSpan.lineBreak = item.LineBreak;

                    textSpans.Add(txtSpan);
                }

                return textSpans;
            });
        }

        protected override void ReleaseResources()
        {
        }
    }
}
