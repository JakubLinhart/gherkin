using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using gherkin.lexer;
using Moq;
using gherkin.util;
using System.Reflection;
namespace gherkin
{
    [TestClass]
    public class I18nLexerTest
    {
        [TestMethod]
        public void shouldScanMultiLineFeature()
        {
            var listener = new Mock<Listener>();
            Lexer lexer = new I18nLexer(listener.Object);

            String feature = "" +
                    " Feature: Hello\n" +
                    "     Big    \n" +
                    "       World  \n" +
                    "  Scenario Outline:\n" +
                    "    Given I have an empty stack\n" +
                    "    When I pøsh <x> onto the stack";

            lexer.scan(feature);

            listener.Verify(x => x.feature("Feature", "Hello", "  Big    \r\n    World", 1));
            listener.Verify(x => x.step("Given ", "I have an empty stack", 5));
            listener.Verify(x => x.step("When ", "I pøsh <x> onto the stack", 6));
        }

        [TestMethod]
        public void shouldScanUtf8FeatureInSourceProperly()
        {
            var listener = new Mock<Listener>();
            Lexer lexer = new I18nLexer(listener.Object);

            String feature = "Feature: ÆØÅ\n" +
                    "\n" +
                    "  Scenario Outline:\n" +
                    "    Given I have an empty stack\n" +
                    "    When I pøsh <x> onto the stack";

            lexer.scan(feature);

            listener.Verify(x => x.feature("Feature", "ÆØÅ", "", 1));
            listener.Verify(x => x.step("When ", "I pøsh <x> onto the stack", 5));
        }

        [TestMethod]
        public void shouldScanUtf8FeatureInFileProperly()
        {
            var listener = new Mock<Listener>();
            var lexer = new I18nLexer(listener.Object);

            String feature = FixJava.readResource("NGherkin.Tests.utf8.feature", Assembly.GetExecutingAssembly());

            lexer.scan(feature);

            listener.Verify(x => x.feature("Feature", "ÆØÅ", "", 1));
            listener.Verify(x => x.step("When ", "I pøsh <x> onto the stack", 5));
        }
    }
}