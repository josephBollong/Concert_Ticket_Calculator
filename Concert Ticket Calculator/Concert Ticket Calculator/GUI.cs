using Concert_Ticket_Calculator.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concert_Ticket_Calculator
{
    public partial class GUI : Form
    {
        private static readonly int FRAME_X = 150;
        private static readonly int FRAME_Y = 250;
        private static readonly int DEFAULT_ROWS = 3;

        private List<SeatRow> rows;

        public TextBox txtOutput;

        Engine engine = new Engine();

        private Button btnCancel;
        private Button btnOk;
        private Button btnReset;
        private Button btnChange;
        private TableLayoutPanel pnlRows;

        public GUI()
        {
            this.Text = "Concert Ticket Calculator";
            this.Location = new Point(FRAME_X, FRAME_Y);
            this.AutoSize = true;

            rows = new List<SeatRow>();

            btnOk = new Button();
            btnOk.Text = "Calculate!";
            btnOk.Click += new EventHandler(onCalculate);

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Click += new EventHandler(disposeFrame);

            btnReset = new Button();
            btnReset.Text = "Reset";
            btnReset.Click += new EventHandler(resetFrame);

            btnChange = new Button();
            btnChange.Text = "Change";
            btnChange.Click += new EventHandler(onChange);

            Label lblCount = new Label();
            lblCount.Text = "Seat Count";

            Label lblPrice = new Label();
            lblPrice.Text = "Price ($)";

            Label lblData = new Label();
            lblData.Text = "Enter Data";

            Label lblReport = new Label();
            lblReport.Text = "Report";

            pnlRows = new TableLayoutPanel();
            pnlRows.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pnlRows.AutoSize = true;
            pnlRows.ColumnCount = 3;
            pnlRows.RowCount = 6;


            Panel rowLayout = new Panel();
           

            txtOutput = new TextBox();
            txtOutput.Multiline = true;
            txtOutput.Size = new Size(8, 50);
            txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            txtOutput.Font = new Font("Courier", 14, FontStyle.Regular);
            txtOutput.WordWrap = true;
            txtOutput.ReadOnly = true;
            txtOutput.BackColor = System.Drawing.SystemColors.Window;

            Panel panelButton = new Panel();
            panelButton.BorderStyle = System.Windows.Forms.BorderStyle.None;
            panelButton.Controls.Add(btnChange);
            panelButton.Controls.Add(btnReset);
            panelButton.Controls.Add(btnCancel);
            panelButton.Controls.Add(btnOk);


            pnlRows.Controls.Add(lblCount, 2, 1);
            pnlRows.Controls.Add(lblCount, 3, 1);
            pnlRows.Controls.Add(lblData, 1, 2);
            pnlRows.Controls.Add()
            pnlRows.Controls.Add(panelButton, 2, 6);
            pnlRows.SetRowSpan(pnlRows, 2);
            this.Controls.Add(pnlRows);
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void onCalculate(object sender, EventArgs e)
        {
            List<Seat> _seats = getSeats();
            //engine.addSeats(_seats);
            txtOutput.Clear();
            //setReportOutput(engine.getReport());
            //engine.clearSeats();
        }

        private void disposeFrame(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetFrame(object sender, EventArgs e)
        {
            InputDialog frm = new InputDialog();

        }
        public void clearRows()
        {
            rows.Clear();
        }

        private void onChange(object sender, EventArgs e)
        {
            changeRows(Microsoft.VisualBasic.Interaction.InputBox("Please enter number of rows.", "Enter a number", DEFAULT_ROWS.ToString(), -1));
        }

        private void changeRows(String input)
        {
            if (input != null)
            {
                    try
                    {
                        MainApp.seatCount = Int32.Parse(input);
                        this.Close();
                        MainApp.Main();
                    }
                    catch (ArgumentException ex) {
                        System.Windows.Forms.MessageBox.Show( "\"" + input + "\"" + " is not a valid number. Please enter a valid number");
                        changeRows(Microsoft.VisualBasic.Interaction.InputBox("Please enter number of rows.", "Enter a number", DEFAULT_ROWS.ToString(), -1));
                    }
                    
                
            } else
            {
                return;
            }
        }

        public void changeRows()
        {
            changeRows(DEFAULT_ROWS.ToString());
        }

        private void setRowCount(Int32 _rows)
        {
            int x = 1;

            MainApp.seatCount = _rows;

            while (x <= _rows)
            {
                SeatRow _row = new SeatRow(getSeatName(x));
                pnlRows.Controls.Add(_row.getLabel());
                pnlRows.Controls.Add(_row.getCount());
                pnlRows.Controls.Add(_row.getPrice());
                rows.Add(_row);
                x++;
            }
        }

        private String getSeatName(Int32 _number)
        {
            return "Row " + _number + ":";
        }

        public void setReportOutput(String _output)
        {
            txtOutput.Text = _output;
        }

        public List<Seat> getSeats()
        {
            List<Seat> _seats = new List<Seat>();

            foreach (SeatRow _row in rows)
            {
                
                String _name = _row.getName();
                String _price = _row.getPrice().ToString();
                String _count = _row.getCount().ToString();

                Int32 _countValue;

                if (System.Text.RegularExpressions.Regex.IsMatch(_count, "[0-9]+"))
                {
                    _countValue = Int32.Parse(_count);
                } else
                {
                    _countValue = 0;
                }

                Double _priceValue;
                if (System.Text.RegularExpressions.Regex.IsMatch(_price, "[0-9+(\\.[0-9]+)?"))
                {
                    _priceValue = Double.Parse(_price);
                } else
                {
                    _priceValue = 0.0;
                }

                Seat _seat = new Seat(_name, _priceValue, _countValue);

                _seats.Add(_seat);
            }
            

            return _seats;
        }
    }
}
