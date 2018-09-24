using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoryTeller.Core.ContentTranslation;
using StoryTeller.Core.Enums.Text;
using System.Linq;

namespace StoryTeller.UnitTests.ContentTranslator
{
    [TestClass]
    public class ContentTranslatorTest
    {
        private readonly ContentMarkupTranslator _contentMarkupTranslator;

        public ContentTranslatorTest()
        {
            _contentMarkupTranslator = new ContentMarkupTranslator();
        }

        [TestMethod]
        public void Can_Translate_Multiple_Paragraphs()
        {
            string content = "<p>Texto texto texto</p> <p>Text 2 text 2 text 2</p> <p>Text 3 texto 3 texto 3 </p>";

            var result = _contentMarkupTranslator.Translate(content);

            Assert.IsTrue(result.Count() >= 3);
        }

        [TestMethod]
        public void Can_Translate_With_Bold()
        {
            string content = "<p>Texto <atr-bold>texto</atr-bold> texto</p> <p>Text 2 text 2 text 2</p> <p>Text 3 texto 3 texto 3 </p>";

            var result = _contentMarkupTranslator.Translate(content);

            Assert.IsTrue(result.Where(x => x.fontAttribute == Core.Enums.Text.FontAttribute.Bold).Count() > 0);
        }

        [TestMethod]
        public void Can_Translate_With_Italic()
        {
            string content = "<p>Texto <atr-italic>texto</atr-italic> texto</p> <p>Text 2 text 2 text 2</p> <p>Text 3 texto 3 texto 3 </p>";

            var result = _contentMarkupTranslator.Translate(content);

            Assert.IsTrue(result.Where(x => x.fontAttribute == Core.Enums.Text.FontAttribute.Italic).Count() > 0);
        }

        [TestMethod]
        public void Can_Translate_All_Font_Attributes()
        {
            string content = "<p>Texto <atr-italic>texto</atr-italic> texto</p> <p>Text 2 <atr-bold>text 2</atr-bold> <atr-italic>texto</atr-italic> <atr-bold>text 2</atr-bold> text 2</p> <atr-italic>texto</atr-italic> <p>Text 3 texto 3 texto 3 </p>";

            var result = _contentMarkupTranslator.Translate(content);

            var qtdBold = 2;
            var qtdItalic = 3;

            var testQtdBold = result.Where(x => x.fontAttribute == FontAttribute.Bold).Count();
            var testQtdItalic = result.Where(x => x.fontAttribute == FontAttribute.Italic).Count();

            Assert.IsTrue((testQtdBold + testQtdItalic) == (qtdBold + qtdItalic));
        }

        [TestMethod]
        public void Can_Translate_All_Font_Attributes_With_Multiple_Paragraphs()
        {
            string content = "<p>Texto <atr-italic>texto</atr-italic> texto</p> <p>Text 2 <atr-bold>text 2</atr-bold> <atr-italic>texto</atr-italic> <atr-bold>text 2</atr-bold> text 2</p> <atr-italic>texto</atr-italic> <p>Text 3 texto 3 texto 3 </p>";

            var result = _contentMarkupTranslator.Translate(content);

            var qtdBold = 2;
            var qtdItalic = 3;
            var qtdParagraphs = 10;

            var testQtdBold = result.Where(x => x.fontAttribute == FontAttribute.Bold).Count();
            var testQtdItalic = result.Where(x => x.fontAttribute == FontAttribute.Italic).Count();
            var testQtParagraph = result.Where(x => !string.IsNullOrEmpty(x.content)).Count();

            Assert.IsTrue((testQtdBold + testQtdItalic + testQtParagraph) == (qtdBold + qtdItalic + qtdParagraphs));
        }
    }
}
