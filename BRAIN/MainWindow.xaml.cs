using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BRAIN.Actions;
using BRAIN.SentenceAnalysis;

namespace BRAIN
{
    /// <summary>
    ///     Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SentenceAnalysisManager SentenceAnaliser;
        public MainWindow()
        {
            InitializeComponent();
            var l = new Listener();
            var m = new ActionManager();
            SentenceAnaliser = new SentenceAnalysisManager();
        }

        private void OnListenDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SentenceAnaliser.Analyze("czesc i witam lol");
                

            }
        }
    }
}