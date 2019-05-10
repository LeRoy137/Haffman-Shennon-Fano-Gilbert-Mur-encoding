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
using static PostoptimalEncoding.CodeInformationCell;

namespace PostoptimalEncoding
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

        private async void btnCoding_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String inputText = txtInput.Text;
                FunctionsClass.LoadFrequency(inputText);

                List<CodeInformationCell> fanoCode = await Task.Factory.StartNew(FanoCoding.Code);
                List<CodeInformationCell> gil_murCode = await Task.Factory.StartNew(GilbertMurCoding.Code);
                List<CodeInformationCell> shennonCode = await Task.Factory.StartNew(ShennonCoding.Code);

                String allInformation = String.Format("Энтропия текста = {0:f5}\nСредняя длина кода Шеннона = {1:f5}\nСредняя длина кода Фано = {2:f5}\nСредняя длина кода Гилберта-Мура = {3:f5}", FunctionsClass.Entropy(), MedLenghtList(shennonCode), MedLenghtList(fanoCode), MedLenghtList(gil_murCode));

                ChangeTextDocument(ListToString(fanoCode), docFano);
                ChangeTextDocument(ListToString(gil_murCode), docGilbertMur);
                ChangeTextDocument(ListToString(shennonCode), docShennon);
                ChangeTextDocument(allInformation, docCommon);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"help: leroy137.artur@gmail.com" + Environment.NewLine + ex.StackTrace, ex.Message);
            }
        }

        // открыть текстовый документ
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

        // закрытие программы
        private void menuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuGilbertMur_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowGilbertMurAbout windowGilbertMur = new WindowGilbertMurAbout();
                windowGilbertMur.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }

        private void menuShennon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowShennonAbout windowShennon = new WindowShennonAbout();
                windowShennon.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }

        private void menuFano_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowFanoAbout windowFano = new WindowFanoAbout();
                windowFano.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message);
            }
        }

        private void menuAbout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowAbout windowAbout = new WindowAbout();
                windowAbout.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace,ex.Message);
            }
        }
    }
}
