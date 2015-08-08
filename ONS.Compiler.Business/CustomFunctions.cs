using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Business
{
    public static class CustomFunctions
    {
        public static DateTime Hora(string hora)
        {
            string pattern = "H:mm:ss";
            DateTime result = DateTime.Now;
            if (!DateTime.TryParseExact(hora, pattern, null, System.Globalization.DateTimeStyles.None, out result))
            {
                throw new Exception("Erro no parsing da da função Hora() em: " + hora);
            }
            return result;
        }

        public static double Max(params double[] list)
        {
            double result = double.MinValue;
            for (int i = 0; i < list.Length; i++)
            { 
                if(list[i] > result)
                    result = list[i];
            }
            return result;
        }

        public static double Min(params double[] list)
        {
            double result = double.MaxValue;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] < result)
                    result = list[i];
            }
            return result;
        }

        public static double RegressaoLinearA(double x1, double x2, double y1, double y2)
        {
            double a = (y1 - y2) / (x1 - x2);
            double b = y1 - a * x1;
            
            return a;
        }
        public static double RegressaoLinearB(double x1, double x2, double y1, double y2)
        {
            double a = (y1 - y2) / (x1 - x2);
            double b = y1 - a * x1;

            return b;
        }
    }

}
