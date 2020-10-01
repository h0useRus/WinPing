namespace NSW.WinPing
{
    public class PingSpectrum
    {
        public long Good { get; set; }
        public long Bad { get; set; }
        public long TimeOut { get; set; }
        public PingSpectrum()
        {
            Good = 300;
            Bad = 1000;
            TimeOut = 3000;
        }

        private static PingSpectrum? _current;
        public static PingSpectrum Current
        {
            get { return _current ??= new PingSpectrum(); }
            set => _current = value;
        }
    }
}
