namespace Battleships.ExamplePlayer
{
    using Battleships.Player.Interface;
    using System;
    using System.Collections.Generic;

    public class ExamplePlayer : IBattleshipsBot
    {
        internal IGridSquare LastTarget;
        private readonly HashSet<IGridSquare> shipsHit = new HashSet<IGridSquare>();

        public string Name
        {
            get { return "Trafalgar"; }
        }

        public IEnumerable<IShipPosition> GetShipPositions()
        {
            return new List<IShipPosition>
                   {
                       //RandomShipPosition(5),
                       
                       GetShipPosition('A', 5, 'A', 9),
                       GetShipPosition('C', 5, 'C', 8),
                       GetShipPosition('E', 5, 'E', 7),
                       GetShipPosition('G', 5, 'G', 7),
                       GetShipPosition('I', 5, 'I', 6)
                   };
        }

        //private static ShipPosition RandomShipPosition(int shipLength)
        //{
        //    Random rnd = new Random();
        //    char startRow = (char)rnd.Next(65, 75);
        //    int startColumn = rnd.Next(1, 10 - shipLength);
        //    if 
        //        char endRow = startRow;
        //    int endColumn = startColumn + shipLength;

        //    return new ShipPosition(new GridSquare(startRow, startColumn), new GridSquare(endRow, endColumn));
        //}

        public IGridSquare SelectTarget()
        {
            var nextTarget = GetNextTarget();
            LastTarget = nextTarget;
            return nextTarget;
        }

        public void HandleShotResult(IGridSquare square, bool wasHit)
        {
            if (wasHit)
            {
                shipsHit.Add(square);
            }
        }

        public void HandleOpponentsShot(IGridSquare square) {}

        private static ShipPosition GetShipPosition(char startRow, int startColumn, char endRow, int endColumn)
        {
            return new ShipPosition(new GridSquare(startRow, startColumn), new GridSquare(endRow, endColumn));
        }

        private IGridSquare GetNextTarget()
        {
            if (LastTarget == null)
            {
                return new GridSquare('A', 1);
            }

            var row = LastTarget.Row;
            var col = LastTarget.Column + 1;
            if (LastTarget.Column != 10)
            {
                return new GridSquare(row, col);
            }

            row = (char)(row + 1);
            if (row > 'J')
            {
                row = 'A';
            }
            col = 1;
            return new GridSquare(row, col);
        }
    }
}