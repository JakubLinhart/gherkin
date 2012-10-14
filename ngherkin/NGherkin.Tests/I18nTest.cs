using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace gherkin
{

    [TestClass]
    public class I18nTest
    {
        [TestMethod]
        public void shouldProvideKeywordsForNorwegian()
        {
            throw new NotImplementedException();
            //I18n no = new I18n("no");
            //assertEquals(Arrays.asList("* ", "Så "), no.keywords("then"));
        }

        [TestMethod]
        public void shouldProvideKeywordsForIndonesian()
        {
            throw new NotImplementedException();
            //I18n no = new I18n("id");
            //assertEquals(Arrays.asList("* ", "Ketika "), no.keywords("when"));
        }

        [TestMethod]
        public void shouldProvideKeywordsForHebrew()
        {
            throw new NotImplementedException();
            //I18n he = new I18n("he");
            //assertEquals(Arrays.asList("דוגמאות"), he.keywords("examples"));
        }

        [TestMethod]
        public void shouldProvideKeywordsForChinese()
        {
            throw new NotImplementedException();
            //I18n zhCn = new I18n("zh-CN");
            //assertEquals(Arrays.asList("* ", "但是"), zhCn.keywords("but"));
        }

        [TestMethod]
        public void shouldProvideKeywordsForScouse()
        {
            throw new NotImplementedException();
            //I18n enScouse = new I18n("en-Scouse");
            //assertEquals(Arrays.asList("* ", "Givun ", "Youse know when youse got "), enScouse.keywords("given"));
        }
    }
}