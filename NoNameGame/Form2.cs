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
        int road = 5;           //направление движения игрока
        int chance = 100;       //шанс на статичное препятствие
        int chance_down = 150;  //тики до снижения вероятности статичного препятствия
        int speed_up = 1500;     //тики до уведичения скорости
        List<StaticBarier> st_bar;  //статичные препятствия
        List<MovedBarier> mv_bar;   //движущиеся препятствия
        int adding = 50;           //добваление нового куска препятствия
        bool end = false;          //конец

        Bitmap buf;
        Graphics g;
        public Form2(String name)
        {
            InitializeComponent();
            label1.Text = name;

            //запуск таймера
            date1 = DateTime.Now;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

            //стартовая инициализация
            pl = new Player();
            st_bar = new List<StaticBarier>();
            mv_bar = new List<MovedBarier>();
            st_bar.Add(new StaticBarier());
        }

        //обновление экрана
        private void BoardRefrech()
        {
            //Функция отрисовки
            buf = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = this.CreateGraphics();
            g = Graphics.FromImage(buf);

            //положение игрока
            g.FillRectangle(new SolidBrush(Color.Black), pl.GetPos().x, pl.GetPos().y, pl.GetSize().x, pl.GetSize().y);

            //положение препятствий
            for (int i = 0; i < st_bar.Count; i++)
            {
                try
                {
                    g.FillRectangle(new SolidBrush(Color.Blue), st_bar[i].GetPos().x, st_bar[i].GetPos().y, st_bar[i].GetSize().x, st_bar[i].GetSize().y);
                }
                catch { };
            }
            for (int i = 0; i < mv_bar.Count; i++)
            {
                try
                {
                    g.FillRectangle(new SolidBrush(Color.Blue), mv_bar[i].GetPos().x, mv_bar[i].GetPos().y, mv_bar[i].GetSize().x, mv_bar[i].GetSize().y);
                }
                catch { };
            }

            //загрузка изображения и очищение памяти
            pictureBox1.Image = buf;
            pictureBox1.Refresh();
            GC.Collect();

            //проверка конца игры
            for (int i = pl.GetPos().x; i < pl.GetSize().x + pl.GetPos().x; i++)
                for (int j = pl.GetPos().y; j < pl.GetSize().y + pl.GetPos().y; j++)
                    if (buf.GetPixel(i, j).ToArgb() == Color.Blue.ToArgb())
                        end = true;

            if (end)
            {
                //State st = new State(label1.Text, label2.Text);  временно не работает
                MessageBox.Show(
                    "Ваше время: " + label2.Text,
                    "Конец игры",
                    MessageBoxButtons.OK
                    );
               this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date1.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);
            label2.Text = String.Format("{0:HH:mm:ss:fff}", stopWatch);

            //передвижение игрока
            switch (road)
            {
                case 0:
                    pl.Move(0, -pl.speed);
                    break;
                case 1:
                    pl.Move(0, pl.speed);
                    break;
                case 2:
                    pl.Move(-pl.speed, 0);
                    break;
                case 3:
                    pl.Move(pl.speed, 0);
                    break;
            }

            //передвижение препятствий
            for (int i = 0; i < st_bar.Count; i++)
            {
                st_bar[i].Move(pl.speed);
            }

            for (int i = 0; i < mv_bar.Count; i++)
            {
                mv_bar[i].Move(pl.speed);
                mv_bar[i].MoveY(pl.speed);
            }

            //очистка ненужных препятствий
            if (st_bar.Count != 0)
                if (st_bar[0].GetPos().x + st_bar[0].GetSize().x < 0)
                    st_bar.RemoveAt(0);
            if (mv_bar.Count != 0)
                if (mv_bar[0].GetPos().x + mv_bar[0].GetSize().x < 0 || mv_bar[0].GetPos().y + mv_bar[0].GetSize().y < 0 || mv_bar[0].GetPos().y > pictureBox1.Height)
                    mv_bar.RemoveAt(0);

            if (!end)
                BoardRefrech();

            //добавление нового препятствия
            adding--;
            if (adding == 0)
            {
                Random rnd = new Random();
                int ch = rnd.Next(0, 99);
                if (ch < chance)
                {
                    st_bar.Add(new StaticBarier());
                    adding = 30 - pl.speed + 4;
                }
                else
                {
                    mv_bar.Add(new MovedBarier());
                    adding = 30 - pl.speed + 4;
                }
            }

            //уменьшение шанса статичного препятствия
            chance_down--;
            if (chance_down == 0 && chance > 50)
            {
                chance -= 10;
                chance_down = 150;
            }

            //увеличение скорости
            speed_up--;
            if (speed_up == 0)
            {
                pl.speed++;
                speed_up = 1500;
            }
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    road = 0;
                    break;
                case Keys.S:
                    road = 1;
                    break;
                case Keys.A:
                    road = 2;
                    break;
                case Keys.D:
                    road = 3;
                    break;
            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
            end = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}