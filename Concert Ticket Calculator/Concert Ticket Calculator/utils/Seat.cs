using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concert_Ticket_Calculator.utils
{
    public class Seat {
        private readonly String name;
        private readonly Double price;
        private readonly Int32 count;

        public Seat(String name, Double price, Int32 count)
        {
            this.name = name;
            this.price = price;
            this.count = count;
        }

        public String getName()
        {
            return name;
        }
        public Double getCount()
        {
            return count;
        }
    }
    
}
