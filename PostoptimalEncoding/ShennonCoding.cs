using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PostoptimalEncoding.FunctionsClass;

namespace PostoptimalEncoding
{
    static class ShennonCoding
    {

        /// <summary>
        /// Метод построения кода Шеннона
        /// </summary>
        /// <returns></returns>
        public static List<CodeInformationCell> Code()
        {
            var sortDict = DictionaryFerquencySort<double>(keyPair => keyPair.Value, SortParametr.Descending);
            var cumDict = CumulyativsCalculate(sortDict);
            List<CodeInformationCell> listOut = Method(sortDict, cumDict);
            return listOut;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d">отсортированный частотный словрь</param>
        /// <param name="c">словарь с кумулятивами</param>
        /// <returns></returns>
        static List<CodeInformationCell> Method(Dictionary<char, double> d, Dictionary<char, double> c)
        {
            List<CodeInformationCell> list = new List<CodeInformationCell>();

            foreach (var o in c)
            {
                int lenght = (int)(-Math.Log(d[o.Key], 2) + 1);
                String code = BinaryBaseValue(o.Value, lenght);
                list.Add(new CodeInformationCell(o.Key, d[o.Key], code));
            }

            return list;
        }

        /// <summary>
        /// расчет кумулятив
        /// </summary>
        /// <param name="dictionary">отсортированный словарь по убыванию</param>
        /// <returns></returns>
        private static Dictionary<char, double> CumulyativsCalculate(IDictionary<char, double> dictionary)
        {
            Dictionary<char, double> cumulyativs = new Dictionary<char, double>();

            double v = 0.0;

            foreach (var d in dictionary)
            {
                cumulyativs.Add(d.Key, v);
                v += d.Value;
            }
            return cumulyativs;
        }
    }
}
