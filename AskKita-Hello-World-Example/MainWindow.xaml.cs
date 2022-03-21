using System.Diagnostics;
using System.Windows;

namespace AskKita_Hello_World_Example
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Microphone_Click(object sender, RoutedEventArgs e)
        {
            bool kitaIsRunning = AskKita.kitaChangeState();
            if (kitaIsRunning)
            {
                MicTextBlock.Text = "click to stop";
            }
            else
            {

                MicTextBlock.Text = "click to start";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AskKita.stopAskKita();
        }
    }
}
