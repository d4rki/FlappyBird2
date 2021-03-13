using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNameGame
{
    class MovedBarier : Barier
    {

        private int speed;          //скорость движения по вертикали
        private int direction;
        public MovedBarier()
        {
            Generate();     //генерируем стартовые условия

            //и оставшиеся
            Random rnd = new Random();

            //скорость перемещения по вертикали и направление
            speed = rnd.Next(0, 4);
            direction = rnd.Next(0, 2);
        }

        public void MoveY(int sp)
        {
            pos.x -= sp;
            if (direction == 0)
                pos.y -= speed;
            else
                pos.y += speed;
        }

    }
}
