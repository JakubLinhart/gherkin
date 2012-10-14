using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace gherkin
{
    [TestClass]
    public class I18nLexerTest
    {
        [TestMethod]
        public void shouldScanMultiLineFeature()
        {
            throw new NotImplementedException();
            //Listener listener = mock(Listener.class);
            //Lexer lexer = new I18nLexer(listener);

            //String feature = "" +
            //        " Feature: Hello\n" +
            //        "     Big    \n" +
            //        "       World  \n" +
            //        "  Scenario Outline:\n" +
            //        "    Given I have an empty stack\n" +
            //        "    When I pøsh <x> onto the stack";

            //lexer.scan(feature);

            //verify(listener).feature("Feature", "Hello", "  Big    \n    World", 1);
            //verify(listener).step("Given ", "I have an empty stack", 5);
            //verify(listener).step("When ", "I pøsh <x> onto the stack", 6);
        }

        [TestMethod]
        public void shouldScanUtf8FeatureInSourceProperly()
        {
            throw new NotImplementedException();
            //Listener listener = mock(Listener.class);
            //Lexer lexer = new I18nLexer(listener);

            //String feature = "Feature: ÆØÅ\n" +
            //        "\n" +
            //        "  Scenario Outline:\n" +
            //        "    Given I have an empty stack\n" +
            //        "    When I pøsh <x> onto the stack";

            //lexer.scan(feature);

            //verify(listener).feature("Feature", "ÆØÅ", "", 1);
            //verify(listener).step("When ", "I pøsh <x> onto the stack", 5);
        }

        [TestMethod]
        public void shouldScanUtf8FeatureInFileProperly() /*throws UnsupportedEncodingException*/ {
            throw new NotImplementedException();
            //Listener listener = mock(Listener.class);
            //Lexer lexer = new I18nLexer(listener);

            //String feature = FixJava.readResource("/gherkin/utf8.feature");

            //lexer.scan(feature);

            //verify(listener).feature("Feature", "ÆØÅ", "", 1);
            //verify(listener).step("When ", "I pøsh <x> onto the stack", 5);
        }
    }
}