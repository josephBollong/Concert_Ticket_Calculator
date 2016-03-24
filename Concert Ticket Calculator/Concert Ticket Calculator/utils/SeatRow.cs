using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concert_Ticket_Calculator.utils
{
    class SeatRow {
        Label label;
        TextBox count;
        TextBox price;

        public SeatRow(String _name) {
            label = new Label();
            label.Text = _name;
            count = new TextBox();
            price = new TextBox();
        }

        public String getName() {
            return label.Text;
        }

        public Label getLabel() {
            return label;
        }
        
        public TextBox getCount() {
            return count;
        }

        public TextBox getPrice() {
            return price;
        }

        public void reset() {
            count.Clear();
            price.Clear();
        }

    }
}
