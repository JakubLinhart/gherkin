using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace gherkin.formatter.model
{
    [TestClass]
    public class CellResultTest
    {
        [TestMethod]
        public void skipped_passed_is_skipped()
        {
            CellResult r = new CellResult("skipped");
            r.addResult(passed());
            Assert.AreEqual("skipped", r.getStatus());
        }

        [TestMethod]
        public void passed_skipped_is_skipped()
        {
            CellResult r = new CellResult("passed");
            r.addResult(skipped());
            Assert.AreEqual("skipped", r.getStatus());
        }

        [TestMethod]
        public void failed_passed_is_failed()
        {
            CellResult r = new CellResult("skipped");
            r.addResult(failed());
            r.addResult(passed());
            Assert.AreEqual("failed", r.getStatus());
        }

        private Result passed()
        {
            return new Result("passed", 1L, (String)null);
        }

        private Result skipped()
        {
            return new Result("skipped", 0L, (String)null);
        }

        private Result failed()
        {
            return new Result("failed", 2L, "error");
        }
    }
}