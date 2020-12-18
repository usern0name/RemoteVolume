using System;

namespace RemoteVolume.Data.Exception
{
    [Serializable]
    public class ExecutionException : System.Exception
    {
        public ExecutionException(string message) : base(message)
        {
        }

        public ExecutionException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
