using System;

namespace TCD.Mathematics
{
    //Exceptions
    public class IdenticalException : Exception
    {
        public IdenticalException()
            : base()
        {
            
        }
        public IdenticalException(string message)
            : base(message)
        {

        }
    }
    public class ParallelityException : Exception
    {
        public ParallelityException()
            : base()
        {

        }
        public ParallelityException(string message)
            : base(message)
        {

        }
    }
    public class NullVectorException : Exception
    {
        public NullVectorException()
            : base()
        {

        }
        public NullVectorException(string message)
            : base(message)
        {

        }
    }
    public class ParameterViolationException : Exception
    {
        public ParameterViolationException()
            : base()
        {

        }
        public ParameterViolationException(string message)
            : base(message)
        {

        }
    }
}
