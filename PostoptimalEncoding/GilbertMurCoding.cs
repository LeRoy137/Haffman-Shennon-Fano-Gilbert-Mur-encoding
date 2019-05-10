using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PostoptimalEncoding.FunctionsClass;

namespace PostoptimalEncoding
{
    static class GilbertMurCoding
    {
        /// <summary>
        /// построение кода Гилберта-Мура
        /// </summary>
        /// <returns></returns>
        public static List<CodeInformationCell> Code()
        {
            var sortDict = DictionaryFerquencySort<char>(keyPair => keyPair.Key,SortParametr.Ascending);
            var cumulyativs = CumulyativsCalculate(sortDict);
            List<CodeInformationCell> listOut = Method(sortDict, cumulyativs);
            return listOut;
        }

        static List<CodeInformationCell> Method(Dictionary<char, double> d, Dictionary<char, double> q)
        {
            List<CodeInformationCell> listOut = new List<CodeInformationCell>();

            foreach (var temp in q)
            {
                int lenght = (int)(-Math.Log(d[temp.Key], 2) + 1) + 1;
                String code = BinaryBaseValue(temp.Value, lenght);
                listOut.Add(new CodeInformationCell(temp.Key, d[temp.Key], code));
            }
            return listOut;
        }

        static Dictionary<char, double> CumulyativsCalculate(Dictionary<char, double> d)
        {
            var cumDict = new Dictionary<char, double>();
            double sum = 0.0;

            foreach (var temp in d)
            {
                cumDict.Add(temp.Key, sum + temp.Value * 0.5);
                sum += temp.Value;
            }

            return cumDict;
        }
    }
}
