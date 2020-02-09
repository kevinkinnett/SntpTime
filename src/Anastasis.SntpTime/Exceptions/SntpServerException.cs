using System;

namespace Anastasis.SntpTime.Exceptions
{
    [Serializable]
    public class SntpServerException: Exception
    {
        public SntpServerException(string message)
            : base(message)
        {

        }
    }
}