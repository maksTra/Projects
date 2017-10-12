using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
using System.Windows.Forms;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path;
        private List<string> dirs;
        private Assembly assembly;

        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            AllcheckBox.IsChecked = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            
                path = fbd.SelectedPath;
            
            dirs = Directory.GetFiles(path).ToList();
            dirs = dirs.Where(x => x.EndsWith(".dll")).ToList();
            listBox.ItemsSource = dirs;
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                assembly = Assembly.LoadFrom(listBox.SelectedItem.ToString());
                var types = assembly.GetTypes();
                listBox1.Items.Clear();
                foreach (var item in types)
                {
                    listBox1.Items.Add(item.FullName);
                }
            }
            else
            {
                MessageBox.Show("Select dll file");
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                listBox2.Items.Clear();
                if (AllcheckBox.IsChecked ?? false)
                {
                    getFields();
                    getProperties();
                    getMethods();
                }
                else
                {
                    if (FieldcheckBox.IsChecked ?? false)
                    {
                        getFields();
                    }
                    if (PropertiesCheckBox.IsChecked ?? false)
                    {
                        getProperties();
                    }
                    if (MethodsCheckBox.IsChecked ?? false)
                    {
                        getMethods();
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("There are nothing to show");
            }
        }

        private void getFields()
        {
            var fields = assembly.GetType(listBox1.SelectedItem.ToString()).GetFields();
            foreach (var item in fields)
            {
                listBox2.Items.Add(item);
            }
        }

        private void getProperties()
        {
            var properties = assembly.GetType(listBox1.SelectedItem.ToString()).GetProperties();
            foreach (var item in properties)
            {
                listBox2.Items.Add(item);
            }
        }

        private void getMethods()
        {
            var methods = assembly.GetType(listBox1.SelectedItem.ToString()).GetMethods();
            foreach (var item in methods)
            {
                listBox2.Items.Add(item);
            }
        }
    }
}
