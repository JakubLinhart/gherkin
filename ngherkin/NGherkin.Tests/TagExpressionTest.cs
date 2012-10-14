using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace gherkin
{
    [TestClass]
    public class TagExpressionTest
    {
        [TestMethod]
        public void notFooShouldMatchBar()
        {
            throw new NotImplementedException();
            //TagExpression e = new TagExpression(Collections.singletonList("~@foo"));
            //assertTrue(e.eval(Collections.singletonList("@bar")));
        }

        [TestMethod]
        public void notFooShouldNotMatchFoo()
        {
            throw new NotImplementedException();
            //TagExpression e = new TagExpression(Collections.singletonList("~@foo"));
            //assertFalse(e.eval(Collections.singletonList("@foo")));
        }

        [TestMethod]
        public void fooShouldNotMatchEmptyTags()
        {
            throw new NotImplementedException();
            //TagExpression e = new TagExpression(Collections.singletonList("@foo"));
            //assertFalse(e.eval(Collections.<String>emptyList()));
        }
    }
}