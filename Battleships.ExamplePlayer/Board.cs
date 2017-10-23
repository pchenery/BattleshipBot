using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Player.Interface;

namespace Battleships.ExamplePlayer
{
    class Board
    {
        private HashSet<IGridSquare> board = new HashSet<IGridSquare>();

        public void CreateBoard()
        {
            board = new HashSet<IGridSquare>();
            for (int i = 65; i < 76; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    board.Add(new GridSquare((char)(i), j));
                }
                
            }
        }

    }

}
