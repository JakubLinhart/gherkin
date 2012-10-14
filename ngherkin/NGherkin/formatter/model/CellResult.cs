using System;
using System.Collections.Generic;
namespace gherkin.formatter.model
{
    public class CellResult : Mappable
    {
        private static readonly List<String> SEVERITY = new List<string>() {
            "executing", "executing_arg", "passed", "passed_arg", "undefined",
            "pending", "pending_arg", "skipped", "skipped_arg", "failed", "failed_arg"
        };

        private List<Result> results = new List<Result>();
        private String status = null;
        private int statusIndex = -1;

        public CellResult(String status)
        {
            updateStatus(status);
        }

        private void updateStatus(String status)
        {
            int index = SEVERITY.IndexOf(status);
            if (index == -1)
            {
                throw new InvalidOperationException("Illegal state: " + status + ". Legal: " + SEVERITY);
            }
            if (index > statusIndex)
            {
                this.status = status;
                this.statusIndex = index;
            }
        }

        public String getStatus()
        {
            return this.status;
        }

        public List<Result> getResults()
        {
            return this.results;
        }

        public void addResult(Result result)
        {
            this.updateStatus(result.getStatus());
            this.results.Add(result);
        }

        public String toString()
        {
            return this.status;
        }
    }
}