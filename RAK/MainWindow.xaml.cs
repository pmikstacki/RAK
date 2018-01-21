using System;
using System.Windows;
using System.Windows.Input;
using RAK.SentenceAnalysis;
using RAK.Actions;

namespace RAK
{
    /// <summary>
    ///     Main App View. It features a chat window and manages all other components.
    /// </summary>
    public partial class MainWindow : Window
    {
        private SentenceAnalysisManager sentenceAnalyzer;
        private Listener listen;
        public static MainWindow _current;
        public Listener Listen { get => listen; set => listen = value; }
        public SentenceAnalysisManager SentenceAnalyzer { get => sentenceAnalyzer; set => sentenceAnalyzer = value; }
        public Speaker _speaker;
        public MainWindow()
        {
            _current = this;
            _speaker = new Speaker();
            listen = new Listener();
            InitializeComponent();
            var m = new ActionManager();
            sentenceAnalyzer = new SentenceAnalysisManager();
        }

        private void OnListenDown(object sender, MouseButtonEventArgs e)
        {
                Dispatcher.Invoke(() => MessagesWindow.Children.Add(new bubble(textbubble.Text, true)));
                SentenceAnalyzer.Analyze(textbubble.Text);
        }

        public void AddMessage(string message, bool userInput)
        {
            Dispatcher.Invoke(() => MessagesWindow.Children.Add(new bubble(message, userInput)));
        }
        public void AddMessage(string message, bool userInput, bool speak)
        {
            Dispatcher.Invoke(() => MessagesWindow.Children.Add(new bubble(message, userInput, speak)));
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Dispatcher.Invoke(() => MessagesWindow.Children.Add(new bubble(textbubble.Text, true)));
                SentenceAnalyzer.Analyze(textbubble.Text);
            }
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}