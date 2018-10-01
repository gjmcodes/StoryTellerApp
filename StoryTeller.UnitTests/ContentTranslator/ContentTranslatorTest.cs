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
        public async void Can_Translate_Multiple_Paragraphs()
        {
            string content = "<p>Texto texto texto</p> <p>Text 2 text 2 text 2</p> <p>Text 3 texto 3 texto 3 </p>";

            var result = await _contentMarkupTranslator.TranslateAsync(content);

            Assert.IsTrue(result.Count() >= 3);
        }

        [TestMethod]
        public async void Can_Translate_With_Bold()
        {
            string content = "<p>Texto <atr-bold>texto</atr-bold> texto</p> <p>Text 2 text 2 text 2</p> <p>Text 3 texto 3 texto 3 </p>";

            var result = await _contentMarkupTranslator.TranslateAsync(content);

            Assert.AreEqual(result.Where(x => x.fontAttribute == FontAttribute.Bold).Count(), 1);
        }

        [TestMethod]
        public async void Can_Translate_With_Italic()
        {
            string content = "<p>Texto <atr-italic>texto</atr-italic> texto</p> <p>Text 2 text 2 text 2</p> <p>Text 3 texto 3 texto 3 </p>";

            var result = await _contentMarkupTranslator.TranslateAsync(content);

            Assert.IsTrue(result.Where(x => x.fontAttribute == Core.Enums.Text.FontAttribute.Italic).Count() > 0);
        }

        [TestMethod]
        public async void Can_Translate_All_Font_Attributes()
        {
            string content = "<p>Texto <atr-italic>texto</atr-italic> texto</p> <p>Text 2 <atr-bold>text 2</atr-bold> <atr-italic>texto</atr-italic> <atr-bold>text 2</atr-bold> text 2</p> <atr-italic>texto</atr-italic> <p>Text 3 texto 3 texto 3 </p>";

            var result = await _contentMarkupTranslator.TranslateAsync(content);

            var qtdBold = 2;
            var qtdItalic = 3;

            var testQtdBold = result.Where(x => x.fontAttribute == FontAttribute.Bold).Count();
            var testQtdItalic = result.Where(x => x.fontAttribute == FontAttribute.Italic).Count();

            Assert.IsTrue((testQtdBold + testQtdItalic) == (qtdBold + qtdItalic));
        }

        [TestMethod]
        public async void Can_Translate_All_Font_Attributes_With_Multiple_Paragraphs()
        {
            string content = "<p>Texto <atr-italic>texto</atr-italic> texto</p> <p>Text 2 <atr-bold>text 2</atr-bold> <atr-italic>texto</atr-italic> <atr-bold>text 2</atr-bold> text 2</p> <atr-italic>texto</atr-italic> <p>Text 3 texto 3 texto 3 </p>";

            var result = await _contentMarkupTranslator.TranslateAsync(content);

            var qtdBold = 2;
            var qtdItalic = 3;
            var qtdParagraphs = 10;

            var testQtdBold = result.Where(x => x.fontAttribute == FontAttribute.Bold).Count();
            var testQtdItalic = result.Where(x => x.fontAttribute == FontAttribute.Italic).Count();
            var testQtParagraph = result.Where(x => !string.IsNullOrEmpty(x.content)).Count();

            Assert.IsTrue((testQtdBold + testQtdItalic + testQtParagraph) == (qtdBold + qtdItalic + qtdParagraphs));
        }

        [TestMethod]
        public async void Can_Translate_With_NameCalls_Formal_Male()
        {
            string content = @"\r\n\r\n<p>- <pronoum>0002</pronoum>. Wake up!</p>\r\n\r\n<c-data_name></c-data_name> open <pronoum>0001</pronoum> eyes and you see T-2, the robot assigned to help you. <namecall_gender></namecall_gender> head hurts and the last \r\nthing <namecall_gender></namecall_gender> can remember was fleeing in a pod from Zeta, a ship ruled by errand smugglers.\r\n\r\n- T-2... what happened?\r\n\r\n- Well, <namecall_formal></namecall_formal>, it seems like they didn't like your message and that you're terrible at poker.\r\n\r\n";

            //Assert
            // ToDo: Configure character data as male
            var result = await _contentMarkupTranslator.TranslateAsync(content);

            Assert.IsTrue(result.Any(x => x.content.ToLower() == "mister"));
        }

        
        public async void Can_Translate_With_NameCalls_Formal_Female()
        {
            string content = @"\r\n\r\n<p>- <pronoum>0002</pronoum>. Wake up!</p>\r\n\r\n<c-data_name></c-data_name> open <pronoum>0001</pronoum> eyes and you see T-2, the robot assigned to help you. <namecall_gender></namecall_gender> head hurts and the last \r\nthing <namecall_gender></namecall_gender> can remember was fleeing in a pod from Zeta, a ship ruled by errand smugglers.\r\n\r\n- T-2... what happened?\r\n\r\n- Well, <namecall_formal></namecall_formal>, it seems like they didn't like your message and that you're terrible at poker.\r\n\r\n";

            //Assert
            // ToDo: Configure character data as female

            var result = await _contentMarkupTranslator.TranslateAsync(content);

            Assert.IsTrue(result.Any(x => x.content.ToLower() == "ma'am"));
        }
    }
}
