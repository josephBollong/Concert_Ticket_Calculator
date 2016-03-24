using Concert_Ticket_Calculator.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert_Ticket_Calculator
{
    public class Engine
    {
        private static readonly String CRLF = Environment.NewLine;

        private readonly List<Seat> arySeat;
         
        public Engine()
        {
            arySeat = new List<Seat>();
        }
        //private List<String> getRowTotals()
        //{
        //    System.Globalization.CultureInfo locale = new System.Globalization.CultureInfo("en-US");
        //    IEnumerator<Seat> itr = arySeat.GetEnumerator();
        //    List<String> _outputs = new List<string>();

        //    while (itr.MoveNext != null)
        //    {

        //    }
        //    {

        //    }
        //}
    }
}
