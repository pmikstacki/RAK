using System;
using BRAIN.Actions;
using BRAIN.SentenceAnalysis;
using BRAIN.VoiceInput;

namespace BRAIN
{
    /// <summary>
    ///     Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SentenceAnalysisManager SentenceAnalyzer;

        public MainWindow()
        {
            InitializeComponent();
            var l = new Listener();
            var m = new ActionManager();
            SentenceAnalyzer = new SentenceAnalysisManager();
        }

        private void OnListenDown(object sender, MouseButtonEventArgs e)
        {
            var vi = new VoiceI();
            vi.Show();
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Console.WriteLine(textbubble.Text);
                SentenceAnalyzer.Analyze(textbubble.Text);
            }
        }
    }
}