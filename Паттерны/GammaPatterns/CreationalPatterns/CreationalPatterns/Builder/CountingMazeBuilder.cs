namespace CreationalPatterns.Builder
{
    using System;

    public class CountingMazeBuilder : IMazeBuilder
    {
        private int roomsCount = 0;

        public void BuildDoor(int roomFrom, int roomTo)
        {
        }

        public void BuildMaze()
        {
        }

        public void BuildRoom(int room)
        {
            this.roomsCount++;
        }

        public int RoomsCount
        {
            get
            {
                return this.roomsCount;
            }
        }
    }
}

