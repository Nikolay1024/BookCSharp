using System;
using System.Runtime.Serialization;

namespace ProcessMultipleExceptions
{
    // Это специальное исключение описывает детали условия выхода автомобиля из строя
    [Serializable]
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        
        public CarIsDeadException() { }
        public CarIsDeadException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        public CarIsDeadException(string message, Exception inner)
            : base(message, inner) { }
        protected CarIsDeadException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
