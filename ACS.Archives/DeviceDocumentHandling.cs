using System;

namespace ACS.Archives
{
    public class DeviceDocumentHandling
    {
        public static int Feeder { get; internal set; }

        public static explicit operator int(DeviceDocumentHandling v)
        {
            throw new NotImplementedException();
        }
    }
}