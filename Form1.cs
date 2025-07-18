using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project19_InstantTableStatus
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Db19Project20Entities context = new Db19Project20Entities();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var buttons = this.Controls.OfType<Button>().ToList();
            foreach(var btn in buttons)
            {
                this.Controls.Remove(btn);
            }

            var values = context.TblTables.ToList();

            int buttonWidth = 100;
            int buttonHeight = 50;
            int padding = 10;
            int xOffset = 10;
            int yOffset = 10;

            // 4 sütun ve 3 satır olacak şekilde 12 masa olarak düşündük.
            for (int i = 0; i < values.Count; i++)
            {
                var item = values[i];
                Button btn = new Button();
                btn.Text = item.TableNumber.ToString();
                btn.Size = new Size(buttonWidth, buttonHeight); // butonun size degerleri
                btn.Location = new Point(xOffset + (i % 4) * (buttonWidth + padding),
                    yOffset + (i / 4) * (buttonHeight + padding));

                btn.BackColor = bool.Parse(item.Status.ToString()) ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                this.Controls.Add(btn);
            }
        }
    }
}
