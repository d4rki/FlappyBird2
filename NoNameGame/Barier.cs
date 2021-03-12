using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNameGame
{
    //шаблонный класс для всех типов препятствий
    class Barier : BaseDate
    {
        //protected int chance = 100;        //шанс появления статичного препятствия (максимум = 100)

        protected void Generate()
        {
            Random rnd = new Random();

            //генерация начальной позиции препятствия
            pos.x = FormSize.x;
            pos.y = rnd.Next(0, FormSize.y);

            //генерация размера препятствия
            size.x = rnd.Next(10, 300);
            size.y = rnd.Next(10, 300);
        }

        public void Move(int sp)
        {
            pos.x -= sp;
        }
    }
}
