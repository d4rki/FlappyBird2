using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoNameGame
{
    public partial class Form2 : Form
    {
        DateTime date1;
        Player pl;
        public Form2()
        {
            InitializeComponent();

            //запуск таймера
            date1 = DateTime.Now;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

            //стартовая инициализация
            pl = new Player(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date1.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);
            label2.Text = String.Format("{0:HH:mm:ss:fff}", stopWatch);

            //здесь же, наверное, прописать изменения скорости и шанса на движущиеся препятствия
        }
    }
}
