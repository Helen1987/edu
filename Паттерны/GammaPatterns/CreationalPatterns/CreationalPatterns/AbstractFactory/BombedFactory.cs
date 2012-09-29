namespace CreationalPatterns.AbstractFactory
{
    using CreationalPatterns.MazePart;
    using System;

    public class BombedFactory : MazeFactory
    {
        public override Room MakeRoom(int i)
        {
            return new RoomWithABomb(i);
        }

        public override Wall MakeWall()
        {
            return new BombedWall();
        }
    }
}

