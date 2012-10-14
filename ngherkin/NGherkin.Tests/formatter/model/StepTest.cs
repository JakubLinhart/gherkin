using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gherkin.formatter.model
{
    [TestClass]
    public class StepTest
    {
        [TestMethod]
        public void shouldProvideArgumentsForOutlineTokens()
        {
            Step step = new Step(new List<Comment>(), "Given ", "I have <number> cukes in <whose> belly", 10, null, null);
            Assert.AreEqual(7, step.getOutlineArgs()[0].getOffset());
            Assert.AreEqual("<number>", step.getOutlineArgs()[0].getVal());
            Assert.AreEqual(25, step.getOutlineArgs()[1].getOffset());
            Assert.AreEqual("<whose>", step.getOutlineArgs()[1].getVal());
        }
    }
}