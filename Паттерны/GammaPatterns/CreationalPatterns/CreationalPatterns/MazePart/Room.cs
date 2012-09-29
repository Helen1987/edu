namespace CreationalPatterns.MazePart
{
    using System;

    public class Room : MapSite
    {
        private int roomNumber;
        private MapSite[] sides;

        public Room()
        {
        }

        public Room(int number)
        {
            this.roomNumber = number;
            this.sides = new MapSite[4];
        }

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public MapSite GetSide(Direction direction)
        {
            return this.sides[(int) direction];
        }

        public void SetSide(Direction direction, MapSite mapSite)
        {
            this.sides[(int) direction] = mapSite;
        }
    }
}

