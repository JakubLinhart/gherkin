using System;
namespace gherkin.formatter.model
{
    public class Result : Mappable
    {
        private String status;
        private long duration;
        private String error_message;
        private Exception error;
        
        public static Result SKIPPED
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static Result UNDEFINED
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static String PASSED
        {
            get
            {
                return "passed";
            }
        }

        public static String FAILED
        {
            get
            {
                return "failed";
            }
        }

        /**
         * Used at runtime
         *
         * @param status
         * @param duration
         * @param error
         * @param dummy    only used to distinguish the constructor when used from JRuby (and null for error).
         */
        public Result(String status, long duration, Exception error, Object dummy)
        {
            this.status = status;
            this.duration = duration;
            this.error_message = null;
            this.error = error;
        }

        /**
         * Used when parsing JSON. TODO: constructing an Exception instance when parsing JSON might be better.
         *
         * @param status
         * @param duration
         * @param errorMessage
         */
        public Result(String status, long duration, String errorMessage)
        {
            this.status = status;
            this.duration = duration;
            this.error_message = errorMessage;
            this.error = null;
        }

        public String getStatus()
        {
            return this.status;
        }

        public long getDuration()
        {
            return this.duration;
        }

        public Exception getError()
        {
            return this.error;
        }

        public String getErrorMessage()
        {
            throw new NotImplementedException();
        }

        public void replay(Reporter reporter)
        {
            reporter.result(this);
        }
    }
}