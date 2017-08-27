using System;
using System.Windows;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
        #if WIN
            : Window
        #endif
    {
        public MainWindow()
        {
            #if WIN
                InitializeComponent();
            #endif
        }

        private void button_Click(object sender
            #if WIN
                , RoutedEventArgs e
            #endif
            )
        {
            Environment.Exit(0);
        }
    }
}
