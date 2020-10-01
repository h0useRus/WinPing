using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NSW.WinPing
{
    public static class Logger
    {
        private const int MaxListBoxItemsCount = 10000;

        private static StreamWriter _fileStream;
        private static ListBox _listBox;

        public static bool NoFileLog { get; set; }
        public static bool IsStopped
        {
            get
            {
                return _listBox == null || (_fileStream == null && !NoFileLog);
            }
        }
        public static void Start(string fileName, ListBox listBox)
        {
            if(!IsStopped)
                Stop();
            _listBox = listBox;
            if (!NoFileLog)
            {
                _fileStream = File.CreateText(fileName);
                _fileStream.AutoFlush = true;
            }
        }

        public static void Stop()
        {            
            _listBox = null;
            if (_fileStream != null)
            {
                _fileStream.Flush();
                _fileStream.Close();
                _fileStream = null;
            }
        }

        public static void Log(DateTime? time, string message, Color? color, bool isLogToFile = false)
        {
            if (!IsStopped)
            {
                var logData = new LogData
                {
                    Time = time ?? DateTime.Now,
                    Message = message,
                    Color = color ?? _listBox.ForeColor
                };
                if(_listBox.Items.Count>MaxListBoxItemsCount)
                    _listBox.Items.RemoveAt(0);
                _listBox.SelectedIndex = _listBox.Items.Add(logData);
                if (isLogToFile && !NoFileLog)
                {
                    _fileStream.WriteLine(logData);
                }
            }
        }
    }

    public class LogData
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public Color Color { get; set; }
        public override string ToString()
        {
            return Time.ToString("dd.MM.yy HH:mm:ss") + " " + Message;
        }
    }
}
