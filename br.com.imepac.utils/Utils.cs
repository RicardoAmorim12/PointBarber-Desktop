using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioVisual.br.com.imepac.utils
{
    class Utils
    {
        public static String convertDateToJson(string date)
        {
            //objetivo:2016 - 05 - 01T10: 00:00.000Z
            //05/24/2019 18:05:37
            return date.Replace("/", "-") + "000Z";
        }
    }
}
