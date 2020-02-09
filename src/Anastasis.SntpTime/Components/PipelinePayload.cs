using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Anastasis.SntpTime.Components
{
    public class PipelinePayload: IPipelinePayload
    {
        public string TimeServerHost { get; set; }
        public Uri TimeServerUri { get; set; }
        public IPEndPoint IPEndPoint { get; set; }

        // SNTP Data Structure (as described in RFC 2030)
        private static byte[] _sntpData = new byte[Constants.SntpDataLength];

        public byte[] SntpData
        {
            get => _sntpData;
            set => _sntpData = value;
        }

        public ulong Millisecond { get; set; }
        public DateTime TimeInUtc { get; set; }
        public UdpClient TimeSocket { get; set; }
    }
}
