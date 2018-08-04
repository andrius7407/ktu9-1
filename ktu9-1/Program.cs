using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktu9_1
{
    class Program
    {
        public static double[] skaiciuojam (Duomenys[]duomenys, double eiliuSkaicius, double vietuSkaicius)
        {
            double[] rez = new double[2];
            double visoUzimta = 0;
            double visoPinigu = 0;
            for (int i = 0; i < eiliuSkaicius; i++)
            {
                string eile = duomenys[i].vietos;
                string[] kedes = eile.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < vietuSkaicius; j++)
                {
                    int kede = Convert.ToInt32(kedes[j]);
                    if (kede == 1)
                    {
                        visoUzimta++;
                        if (i < 2)
                        {
                            visoPinigu += 100;
                        }
                        else if (i == 2 || i == 3)
                        {
                            visoPinigu += 70;
                        }
                        else
                        {
                            visoPinigu += 40;
                        }
                    }
                }
            }
            rez[0] = visoPinigu;
            rez[1] = visoUzimta;
            return (rez);
        }

        static void Main(string[] args)
        {
            string[] tekstas = 
                System.IO.File.ReadAllLines(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu9-1\ktu9-1\duomenys.txt");
            string pirma = tekstas[0];
            string[] pirmDuom = pirma.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            int eiliuSkaicius = Convert.ToInt32(pirmDuom[0]);
            int vietuSkaicius = Convert.ToInt32(pirmDuom[1]);

            Duomenys[] duomenys = new Duomenys[eiliuSkaicius];
            for(int i = 0; i < eiliuSkaicius; i++)
            {
                string vietos = tekstas[i +1];                
                duomenys[i] = new Duomenys(vietos);
            }

            double[] rez = skaiciuojam(duomenys, eiliuSkaicius, vietuSkaicius);
            double visoPinigu = rez[0];
            double visoUzimta = rez[1];
           
            using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu9-1\ktu9-1\rezultatai.txt"))
            {
                file.WriteLine("{0},  {1:0.00}", visoPinigu, visoPinigu / visoUzimta);
            }
        }
    }
}
