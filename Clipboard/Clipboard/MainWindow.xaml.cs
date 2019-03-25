using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clipboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckBox_ontop.IsChecked = true;
            Topmost = true;
        }

        private Dictionary<string, string> values = new Dictionary<string, string>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(string file_name in Directory.GetFiles(".", "*.txt"))
            {
                string line = File.ReadAllLines(file_name)[0];
                string key = System.IO.Path.GetFileNameWithoutExtension(file_name);
                string value = line;
                Button btn = new Button();
                btn.Content = key;
                btn.Click += Btn_Click;
                btn.Width = 75;
                grid.Children.Add(btn);

                values[key] = value;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string key = btn.Content.ToString();
            System.Windows.Clipboard.SetText(values[key]);
        }

        private void CheckBox_ontop_Click(object sender, RoutedEventArgs e)
        {
            Topmost = CheckBox_ontop.IsChecked.Value;
        }
    }
}
