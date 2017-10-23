using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Player.Interface;

namespace Battleships.ExamplePlayer
{
    class Ship
    {
        public IGridSquare StartSquare { get; private set; }
        public IGridSquare EndSquare { get; private set; }

        public bool IsValid => (!IsDiagonal() && !IsOutsideGrid());

        private bool IsDiagonal()
        {
            return (StartSquare.Column != EndSquare.Column) || (StartSquare.Row != EndSquare.Row);
        }

        private bool IsOutsideGrid()
        {
            return StartSquare.Column < 1 || StartSquare.Column > 10 || StartSquare.Row < 'A' || StartSquare.Row > 'J'
                   || EndSquare.Column < 1 || EndSquare.Column > 10 || EndSquare.Row < 'A' || EndSquare.Row > 'J';
        }
    }
}
