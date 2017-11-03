using System.Windows;
using System.Windows.Input;
using BRAIN.Actions;

namespace BRAIN
{
    /// <summary>
    ///     Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var l = new Listener();
            var m = new ActionManager();
        }

        private void OnListenDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}