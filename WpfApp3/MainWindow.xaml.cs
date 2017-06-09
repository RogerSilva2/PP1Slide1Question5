using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WpfApp3
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dinamico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button button = CreateButton(((TextBox) sender).Text.ToString());
                button.Click += new RoutedEventHandler(Button_Click);
                LayoutRoot.Children.Add(button);
            }
        }

        private Button CreateButton(string name)
        {
            Button originalButton = new Button();
            originalButton.Height = 50;
            originalButton.Width = 50;
            originalButton.Background = Brushes.AliceBlue;
            originalButton.Content = name;

            string savedButton = XamlWriter.Save(originalButton);

            StringReader stringReader = new StringReader(savedButton);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return (Button)XamlReader.Load(xmlReader);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("Clique do botão {0}!", ((Button) sender).Content.ToString()),
                "Trabalho XAML", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
