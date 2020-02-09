using System;
using System.Net;
using System.Net.Sockets;

namespace Anastasis.SntpTime.Components
{
    public interface IPipelinePayload
    {
        string TimeServerHost { get; set; }
        Uri TimeServerUri { get; set; }
        IPEndPoint IPEndPoint { get; set; }
        // SNTP Data Structure (as described in RFC 2030)
        byte[] SntpData { get; set;  }

        ulong Millisecond { get; set; }
        DateTime TimeInUtc { get; set; }

        UdpClient TimeSocket { get; set; }
    }
}