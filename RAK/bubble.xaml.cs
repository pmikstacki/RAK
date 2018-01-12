using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RAK
{
    /// <summary>
    ///     Klasa reprezentuje objekt dymku.
    /// </summary>
    public partial class bubble : UserControl
    {
        /// <summary>
        /// Konstruktor klasy bubble
        /// </summary>
        /// <param name="msg">wiadomośc do wyświetlenia w dymku</param>
        /// <param name="userinput">sprawdza czy dymek jest napisany przez użytkownika lub bota</param>
        public bubble(string msg, bool userinput)
        {
            InitializeComponent();
            Txt.Content = msg;
            if (userinput)
            {
                Rect.Fill = new SolidColorBrush(Colors.CornflowerBlue);
            }
            else
            {
                new Thread(new ThreadStart( () => MainWindow._current._speaker.Speak(msg))).Start();
            }

        }
        public bubble(string msg, bool userinput, bool speak)
        {
            InitializeComponent();
            Txt.Content = msg;
            if (userinput)
            {
                Rect.Fill = new SolidColorBrush(Colors.CornflowerBlue);
            }
            else
            {
                if(speak)
                new Thread(new ThreadStart(() => MainWindow._current._speaker.Speak(msg))).Start();
            }

        }
    }
}
