using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kernel32
{
    class SpanDAO
    {
        List<Span> listS = new List<Span>();
        public List<Span> readAll() {
            listS.Add(new Span { day = DayOfWeek.Monday, bottom = 19, top = 25 });
            listS.Add(new Span { day = DayOfWeek.Tuesday, bottom = 12, top = 18 });
            //listS.Add(new Span { day = DayOfWeek.Tuesday, bottom = 19, top = 25 });
            listS.Add(new Span { day = DayOfWeek.Wednesday, bottom = 12, top = 18 });
            listS.Add(new Span { day = DayOfWeek.Thursday, bottom = 19, top = 25 });
            //False positive
            listS.Add(new Span { day = DayOfWeek.Thursday, bottom = 13, top = 14});
            //
            listS.Add(new Span { day = DayOfWeek.Friday, bottom = 12, top = 18 });
            //listS.Add(new Span { day = DayOfWeek.Saturday, bottom = 6, top = 11 });
            listS.Add(new Span { day = DayOfWeek.Sunday, bottom = 6, top = 11 });
            listS.Add(new Span { day = DayOfWeek.Sunday, bottom = 12, top = 18 });
            return listS;
        }

       public bool check(List<Span> listS)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            foreach (Span sp in listS)
            {
                if (DateTime.Now.DayOfWeek.Equals(sp.day))
                {
                    if (DateTime.Now.Hour >= sp.bottom && DateTime.Now.Hour <= sp.top)
                    {
                        Console.WriteLine("nd");
                        return true;
                    }
                }
            }
            Console.WriteLine("co");
            return false;
        }
    }
}
