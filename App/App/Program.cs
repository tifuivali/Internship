using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace App
{
    class Program
    {



        static TimeSpan ts_i;

        static void Main(string[] args)
        {
           
            Timer timer2;
          
            timer2 = new Timer();
        
            timer2.Interval = 10000;
           
            timer2.Elapsed += Timer2_Elapsed;
            float mx = 1000000;
            ts_i = DateTime.Now.TimeOfDay;
            timer2.Start();
            Console.WriteLine("Wait...");
            for (int i=0;i<mx;i++)
            {
               
                Console.Write("\rYour Progresss [" + String.Format("{0:0.00}]", (i / mx) * 100));
                
            }
          
            timer2.Stop();
            Console.WriteLine();
            Console.WriteLine("Time:");
            TimeSpan ts_f = DateTime.Now.TimeOfDay - ts_i;
            Console.WriteLine("Minutes:" + ts_f.Minutes + " Seconds:" + ts_f.Seconds + " Miliseconds:" + ts_f.Milliseconds);

            Console.ReadKey();
        }

        private static void Timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine();
            TimeSpan ts_f = DateTime.Now.TimeOfDay - ts_i;
            Console.WriteLine("Minutes:" + ts_f.Minutes + " Seconds:" + ts_f.Seconds + " Miliseconds:" + ts_f.Milliseconds);
        }

      
    }
}
