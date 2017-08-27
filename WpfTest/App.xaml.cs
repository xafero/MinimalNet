using System.Windows;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
            #if WIN 
                : Application 
            #endif
    {
        #if !WIN
            static void Main() { }
        #endif
    }
}