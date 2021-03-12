using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNameGame
{
    class MovedBarier : Barier
    {

        int speed;          //скорость движения
        public MovedBarier()
        {
            Generate();     //генерируем стартовые условия

            //и оставшиеся
            Random rnd = new Random();

            //скорость перемещения по вертикали
            speed = rnd.Next(-5, 5);
        }

        public void MoveY(int sp)
        {
            pos.x -= sp;
            pos.y += speed;
        }

    }
}
