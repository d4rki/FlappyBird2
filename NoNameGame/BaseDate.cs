using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoNameGame
{
    //класс с различными базовыми значениями, который будет наследоваться остальными
    class BaseDate
    {
        public struct point
        {
            public int x;
            public int y;
        }

        //длина и ширина экрана
        protected readonly point FormSize = new point() { x = 550, y = 1000 };

        //координаты для чего-либо
        protected point pos;

        //ширина и высота чего-либо
        protected point size;

        //различные геттеры
        public point GetFormSize() { return FormSize; }
        public point GetPos() { return pos; }
        public point GetSize() { return size; }
    }
}
