using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace kernel32
{
    class Program
    {
        public static List<Span> listS = new SpanDAO().readAll();
        static void Main(string[] args)
        {
            int i = 0;
            while (true)
            {
                i++;
                Console.WriteLine(i);

                //Thread.Sleep(new TimeSpan(0,20,0));     

                //StreamWriter sw = new StreamWriter("C:\\xampp\\test.txt",false);
                //sw.WriteLine( new SpanDAO().check(listS));
                string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                StreamReader sr = new StreamReader("C:\\xampp\\test.txt"); ;
                string c = sr.ReadLine();
                int count = c != null ? int.Parse(c) : 1;
                Thread.Sleep(500);
                sr.Close();
                Thread.Sleep(500);
                StreamWriter sw;

                if (user == "HOME-PC\\HOME")
                {
                    if (new SpanDAO().check(listS))
                    {
                        //int min = 15 / count;

                        Random r = new Random(DateTime.Now.GetHashCode());

                        int min = 0;
                        if (count < 3)
                        {
                            min = r.Next(15, 35);
                        }
                        else {
                            if (count > 7)
                            {
                                min = 25;
                            }
                            else
                            min = 25 / count;
                        }
                        count += 2;
                        //if (count > 2)
                        //    count++;
                        sw = new StreamWriter("C:\\xampp\\test.txt", false);
                        
                        sw.WriteLine(count);
                        sw.Close();
                        Thread.Sleep(new TimeSpan(0, min, 0));
                        if (min % 2 == 0)
                        {
                            Process.Start("shutdown", "/s /t 0");
                        }
                        else
                        {
                            Process.Start("shutdown", "/r /t 0");
                        }

                    }

                }
                else
                {
                    sw = new StreamWriter("C:\\xampp\\test.txt", false);
                    sw.WriteLine("1");
                    Thread.Sleep(500);
                    sw.Close();
                }
                // sw.Close();
            }
        }


    }
}
