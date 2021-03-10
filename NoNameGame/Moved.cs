using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNameGame
{
    class MovedBarier : Barier
    {

        bool direction;     //направление движения (вверх/вниз)
        int speed;          //скорость движения
        public MovedBarier()
        {
            Generate();     //генерируем стартовые условия

            //и оставшиеся
            Random rnd = new Random();

            int tmp = rnd.Next(0, 1);
            if (tmp == 0)
                direction = true;
            else
                direction = false;

            speed = rnd.Next(0, 20);
        }

    }
}
