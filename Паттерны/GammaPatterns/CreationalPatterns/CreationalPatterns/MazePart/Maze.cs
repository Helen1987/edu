namespace CreationalPatterns.MazePart
{
    using System;
    using System.Reflection;

    public class Maze
    {
        private int currentIndex;
        private Room[] rooms = new Room[0x19];

        public void AddRoom(Room room)
        {
            if (this.currentIndex < 0x19)
            {
                this.rooms[this.currentIndex++] = room;
            }
        }

        public Room this[int index]
        {
            get
            {
                if ((index < 0x19) && (index < this.currentIndex))
                {
                    return this.rooms[index];
                }
                return null;
            }
        }
    }
}

