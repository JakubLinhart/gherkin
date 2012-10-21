using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using gherkin.formatter.model;
using System.Threading;

namespace gherkin.formatter
{
    [TestClass]
    public class PrettyFormatterTest
    {
        private static List<Comment> NO_COMMENTS = new List<Comment>();
        private static List<Tag> NO_TAGS = new List<Tag>();

        [TestMethod]
        public void prints_nice_colors()
        {
            PrettyFormatter f = new PrettyFormatter(Console.Out, false, false);
            f.scenario(new Scenario(NO_COMMENTS, NO_TAGS, "Scenario", "a scenario", "", 1, "a-scenario"));
            f.step(new Step(new List<Comment>(), "Given ", "I have 6 cukes", 1, null, null));
            Thread.Sleep(1000);
            f.match(new Match(new List<Argument>() { new Argument(7, "6") }, "somewhere.brainfuck"));
            Thread.Sleep(1000);
            f.result(new Result("failed", 55L, "Something\nbad\nhappened"));
        }

        [TestMethod]
        public void prints_table()
        {
            PrettyFormatter f = new PrettyFormatter(Console.Out, false, false);
            f.scenario(new Scenario(NO_COMMENTS, new List<Tag>(), "Scenario", "a scenario", "", 1, "a-scenario"));
            List<DataTableRow> rows = new List<DataTableRow>() {
                new DataTableRow(NO_COMMENTS, new List<string> { "un", "deux" }, 1, Row.DiffType.NONE),
                new DataTableRow(NO_COMMENTS, new List<string> {"one", "two" }, 1, Row.DiffType.DELETE),
                new DataTableRow(NO_COMMENTS, new List<string> {"en", "to" }, 1, Row.DiffType.INSERT),
            };
            Step step = new Step(new List<Comment>(), "Given ", "I have 6 cukes", 1, rows, null);
            f.step(step);
            Thread.Sleep(1000);
            f.match(new Match(new List<Argument> { new Argument(7, "6") }, "somewhere.brainfuck"));
            Thread.Sleep(1000);
            f.result(new Result("failed", 55L, "Something\nbad\nhappened"));
        }
    }
}