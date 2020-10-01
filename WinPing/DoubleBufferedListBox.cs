using System.Windows.Forms;

namespace NSW.WinPing
{
    /// <summary>
    /// This class is a double-buffered ListBox for owner drawing.
    /// The double-buffering is accomplished by creating a custom,
    /// off-screen buffer during painting.
    /// </summary>
    public sealed class DoubleBufferedListBox : ListBox
    {
        public DoubleBufferedListBox() 
        {
            DoubleBuffered = true;
        }
    }
}
