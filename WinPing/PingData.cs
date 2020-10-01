using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;

namespace NSW.WinPing
{
    class PingData
    {
        public long Time { get; private set; }
        public string Message { get; private set; }
        public Color Color { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public IPAddress Address { get; private set; }
        public int TTL { get; private set; }
        public IPStatus Status { get; private set; }
        public PingData(PingReply pingReply)
        {
            Time = -1;
            Message = "Unknown";
            Status = IPStatus.Unknown;
            TimeStamp = DateTime.Now;
            if (pingReply != null)
            {
                Message = pingReply.Status.ToString();
                Status = pingReply.Status;
                Address = pingReply.Address;
                if (pingReply.Options!=null)
                    TTL = pingReply.Options.Ttl;
                if (pingReply.Status == IPStatus.Success)
                    Time = pingReply.RoundtripTime > 0 ? pingReply.RoundtripTime : 1;
            }
            Color = GetColor(Time);
        }
        public PingData(Exception e)
        {
            Time = -1;
#if DEBUG
            Message = e.ToString();
#else
            Message = e.InnerException != null ? e.InnerException.Message : e.Message;
#endif
            TimeStamp = DateTime.Now;
            Color = GetColor(Time);
            Status = IPStatus.Unknown;
        }

        public static Color GetColor(long time)
        {
            if (time == -1)
                return Color.Red;
            if (time < PingSpectrum.Current.Good / 3)
                return Color.LightBlue;
            if (time < PingSpectrum.Current.Good / 2)
                return Color.Cyan;
            if (time < (2 * PingSpectrum.Current.Good) / 3)
                return Color.LightGreen;
            if (time < PingSpectrum.Current.Good)
                return Color.Green;
            if (time < PingSpectrum.Current.Bad / 2)
                return Color.Yellow;
            if (time < PingSpectrum.Current.Bad)
                return Color.Orange;
            return Color.OrangeRed;
        }

        public override string ToString()
        {
            return Message + (Time > 0 ? " " + Time + " ms" : "");
        }
    }
}
