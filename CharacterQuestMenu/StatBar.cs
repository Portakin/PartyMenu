using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterQuestMenu
{
    public partial class StatBar : UserControl
    {
        //Timer T = new Timer();
        string Label;// text stating what the level of the stat is
        int CurrentBarValue;//bar won't necessarly fill completely
        public int MAXIMUM_VALUE { get; set; } = 100; 

        public StatBar()
        {
            InitializeComponent();
            label1.ForeColor = Color.Black;
            //this.ForeColor = SystemColors.Highlight; // Set the default color of the Pbar 
        }

    protected float percent = 0.0f; // Protected because we don't want this to be accessed from the outside
                                    // Create a Value property for the Pbar

        public void buildBar(string rating, int limit, Color barColor)
        {
            this.Value = 0;
            this.ForeColor = barColor;
            label1.ForeColor = Color.Black;
            Label = rating;
            CurrentBarValue = limit;
            timer1.Start();                
        }
        //overloaded for stat bar that dont overwrite label with specific text (health bars)
        public void buildBar(int limit, Color barColor)
        {
            this.Value = 0;
            this.ForeColor = barColor;
            label1.ForeColor = Color.Black;
            Label = limit.ToString() + "%";
            CurrentBarValue = limit;
            timer1.Start();
        }

        public float Value
    {
        get
        {
            return percent;
        }
        set
        {
            // Maintain the Value between 0 and 100
            if (value < 0) value = 0;
            else if (value > MAXIMUM_VALUE) value = MAXIMUM_VALUE;
            percent = value;
            label1.Text = value.ToString();
            // Redraw the Pbar every time the Value changes
            this.Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Brush b = new SolidBrush(this.ForeColor); // Create a brush that will draw the background of the Pbar
                                                  // Create a linear gradient that will be drawn over the background. FromArgb means you can use the Alpha value which is the transparency
        LinearGradientBrush lb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.White), Color.FromArgb(50, Color.Black), LinearGradientMode.ForwardDiagonal);
        // Calculate how much has the Pbar to be filled for "x" %
        int width = (int)((percent / 100) * this.Width);
        e.Graphics.FillRectangle(b, 0, 0, width, this.Height);
        e.Graphics.FillRectangle(lb, 0, 0, width, this.Height);
        b.Dispose(); lb.Dispose();
    }

    private void Pbar_SizeChanged(object sender, EventArgs e)
    {
        // Maintain the label in the center of the Pbar
        label1.Location = new Point(this.Width / 2 - 21 / 2 - 4, this.Height / 2 - 15 / 2);
    }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Value >= CurrentBarValue)
            {
                label1.Text = Label;
                timer1.Stop();
            }
            else
            {
                label1.Text = this.Value.ToString() + "%";
                Value+=4;
            }               
        }
    }
}