using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using gherkin.formatter.model;
namespace gherkin
{
    [TestClass]
    public class TagExpressionTest
    {
        [TestMethod]
        public void notFooShouldMatchBar()
        {
            TagExpression e = new TagExpression(new List<string> { "~@foo" });
            Assert.IsTrue(e.eval(new List<Tag> { new Tag("@bar", 1) } ));
        }

        [TestMethod]
        public void notFooShouldNotMatchFoo()
        {
            TagExpression e = new TagExpression(new List<string> { "~@foo" });
            Assert.IsFalse(e.eval(new List<Tag> { new Tag("@foo", 1) }));
        }

        [TestMethod]
        public void fooShouldNotMatchEmptyTags()
        {
            TagExpression e = new TagExpression(new List<string>  { "@foo" });
            Assert.IsFalse(e.eval(new List<Tag> { }));
        }
    }
}