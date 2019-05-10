using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostoptimalEncoding
{
    class CodeInformationCell : IComparable<CodeInformationCell>
    {
        char symbol;
        double frequency;
        String codeWord;

        public CodeInformationCell(char symbol, double frequency, String codeWord)
        {
            this.symbol = symbol;
            this.frequency = frequency;
            this.codeWord = codeWord;
        }

        public Char Symbol => symbol;
        public double Frequency => frequency;
        public String CodeWord => codeWord;
        public Int32 LenghtCode => codeWord.Length;

        public override string ToString()
        {
            return String.Format("{0,5} : {1:f5} : {2,10} : {3,5}", Symbol, Frequency, CodeWord, LenghtCode);
        }

        public Int32 CompareTo(CodeInformationCell informationCell)
        {
            return this.Symbol.CompareTo(informationCell.Symbol);
        }

        // функция на вывод
        public static String ListToString(List<CodeInformationCell> list)
        {
            String output = String.Empty;
            list.Sort();
            output += "символ: вероятность: код: длина кода" + Environment.NewLine + Environment.NewLine;

            foreach (var o in list)
                output += o.ToString() + Environment.NewLine;

            return output;
        }

        // средняя длина кодового слова
        public static double MedLenghtList(List<CodeInformationCell> list)
        {
            double medLenght = list.Select(c => c.LenghtCode * c.Frequency).Sum();
            return medLenght;
        }
    }


}
