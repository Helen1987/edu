namespace CreationalPatterns.AbstractFactory
{
    using CreationalPatterns.MazePart;
    using System;

    public class MazeFactory
    {
        private static MazeFactory currentFactory;

        protected MazeFactory()
        {
        }

        public static MazeFactory Instance()
        {
            if (currentFactory == null)
            {
                if (Environment.GetEnvironmentVariable("tempV") == "bomb")
                {
                    currentFactory = new BombedFactory();
                }
                else if (Environment.GetEnvironmentVariable("tempV") == "ench")
                {
                    currentFactory = new EnchantedMazeFactory();
                }
                else
                {
                    currentFactory = new MazeFactory();
                }
            }
            return currentFactory;
        }

        public virtual Door MakeDoor(Room r1, Room r2)
        {
            return new Door(r1, r2);
        }

        public virtual Maze MakeMaze()
        {
            return new Maze();
        }

        public virtual Room MakeRoom(int i)
        {
            return new Room(i);
        }

        public virtual Wall MakeWall()
        {
            return new Wall();
        }
    }
}

