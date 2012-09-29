namespace CreationalPatterns.FactoryMethod
{
    using CreationalPatterns.MazePart;
    using System;

    public class BombedMazeGame : MazeGame
    {
        public override Room MakeRoom(int room)
        {
            return new RoomWithABomb(room);
        }

        public override Wall MakeWall()
        {
            return new BombedWall();
        }
    }
}

