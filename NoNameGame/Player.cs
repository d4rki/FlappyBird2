using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNameGame
{
    class Player : BaseDate
    {
        public int speed; //скорость модельки

        //стартовая инициализация
        public Player()
        {
            size.x = 2;      //длина модельки игрока
            size.y = 2;     //ширина
            pos.x = 10;     //стартовая позиция игрока х
            pos.y = 10;     //стартовая позиция игрока y
            speed = 1;
        }

        //перемещение игрока
        public void Move(int x, int y)
        {
            if (pos.x + 2 + x < FormSize.x)
                pos.x += x;
            if (pos.y + 2 + y < FormSize.y)
                pos.y += y;
        }

    }
}
