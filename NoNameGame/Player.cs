using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNameGame
{
    class Player : BaseDate
    {
        public int speed; //обычная скорость
        public int buff;

        //стартовая инициализация
        public Player()
        {
            size.x = 10;      //длина модельки игрока
            size.y = 10;     //ширина
            pos.x = 10;     //стартовая позиция игрока х
            pos.y = FormSize.y/2;     //стартовая позиция игрока y
            speed = 4;
            buff = 2;
        }

        //перемещение игрока
        public void Move(int x, int y)
        {
            if (pos.x + 10 + x < FormSize.x && pos.x - 2 + x > 0)
                pos.x += x;
            if (pos.y + 10 + y < FormSize.y && pos.y - 2 + y > 0)
                pos.y += y;
        }

    }
}
