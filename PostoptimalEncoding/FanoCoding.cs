using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PostoptimalEncoding.FunctionsClass;

namespace PostoptimalEncoding
{
    static class FanoCoding
    {
        public static List<CodeInformationCell> Code()
        {
            var sortDict = DictionaryFerquencySort<double>(keyPair => keyPair.Value,SortParametr.Descending);
            List<CodeInformationCell> listOut = Method(sortDict);
            return listOut;
        }

        /// <summary>
        /// Функция нахождения медианы
        /// </summary>
        /// <param name="start"> начальный индекс</param>
        /// <param name="end">конечный индекс</param>
        /// <param name="fdq">словарь частот</param>
        /// <returns>индекс разбиения</returns>
        static int Med(int startIndex, int endIndex, Dictionary<char, double> fdq)
        {
            double sumL = 0.0;

            for (int i = startIndex; i <= endIndex - 1; i++)
                sumL += fdq.ValueDict(i).Value;

            double sumR = fdq.ValueDict(endIndex).Value;

            int med = endIndex;

            while (sumL >= sumR)
            {
                med = med - 1;
                sumL = sumL - fdq.ValueDict(med).Value;
                sumR = sumR + fdq.ValueDict(med).Value;
            }

            return med;
        }

        /// <summary>
        /// метод построения кода
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="d"></param>
        static void Fano(int startIndex, int endIndex, Dictionary<char, double> d, String[] listCodes)
        {
            if (startIndex < endIndex)
            {
                int med = Med(startIndex, endIndex, d);
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (i <= med)
                        listCodes[i] += '0';
                    else
                        listCodes[i] += '1';
                }
                Fano(startIndex, med, d, listCodes);
                Fano(med + 1, endIndex, d, listCodes);
            }
            if (listCodes.Length == 1)
            {
                listCodes[0] = "0";
            }
        }

        static List<CodeInformationCell> Method(Dictionary<char, double> sortDict)
        {
            int lenght = sortDict.Keys.Count;
            String[] codeWords = new String[lenght];

            Fano(0, lenght - 1, sortDict, codeWords);

            List<CodeInformationCell> listOut = new List<CodeInformationCell>();

            int index = 0;

            foreach (var c in sortDict)
            {
                listOut.Add(new CodeInformationCell(c.Key, c.Value, codeWords[index]));
                index++;
            }
            return listOut;
        }
    }

    // класс методов расширения для словаря
    static class DictExt
    {
        // возвращает пару ключ-значение по индексу в словаре
        public static KeyValuePair<char, double> ValueDict(this Dictionary<char, double> d, int index)
        {
            var count = 0;
            foreach (var c in d)
            {
                if (index == count)
                    return c;
                count++;
            }

            throw new IndexOutOfRangeException("Указанный индекс за пределами возможных занчения!!!");
        }
    }
}
