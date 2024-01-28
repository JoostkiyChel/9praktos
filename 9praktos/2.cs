using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9praktos
{
    public class Food
    {
        public (int x, int y) Position { get; set; }

        public Food((int x, int y) position)
        {
            Position = position;
        }
    }
}
