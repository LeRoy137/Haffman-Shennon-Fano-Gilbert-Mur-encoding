using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using Microsoft.Win32;
using static OptimalEncoding.CodeInformationCell;

namespace OptimalEncoding
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void ChangeTextDocument(String text, FlowDocument fd)
        {
            fd.Blocks.Clear();
            Paragraph paragraph = new Paragraph(new Run(text));
            fd.Blocks.Add(paragraph);
        }

        private void menuHaffmanAbout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowHaffmanAbout windowHaffman = new WindowHaffmanAbout();
                windowHaffman.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowAbout windowAbout = new WindowAbout();
                windowAbout.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // загрузка
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == true)
                {
                    String path = openFileDialog.FileName;
                    String text = String.Empty;
                    using (StreamReader sr = new StreamReader(path, Encoding.Default))
                    {
                        text = sr.ReadToEnd();
                    }
                    txtInput.Text = text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"help: leroy137.artur@gmail.com" + Environment.NewLine + ex.StackTrace, ex.Message);
            }
        }

        private async void btnCoding_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String inputText = txtInput.Text;
                FunctionsClass.LoadFrequency(inputText);

                List<CodeInformationCell> haffmanCode = await Task.Factory.StartNew(HaffmanCoding.Code);
                String allInformation = HaffmanCoding.InformationsCode(haffmanCode);
            
                ChangeTextDocument(ListToString(haffmanCode), docHaffman);
                ChangeTextDocument(allInformation, docCommon);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"help: leroy137.artur@gmail.com" + Environment.NewLine + ex.StackTrace, ex.Message);
            }
        }
    }
}
