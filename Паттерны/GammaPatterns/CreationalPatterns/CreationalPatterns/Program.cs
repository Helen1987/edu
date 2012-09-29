namespace CreationalPatterns
{
    using CreationalPatterns.AbstractFactory;
    using CreationalPatterns.Builder;
    using CreationalPatterns.FactoryMethod;
    using CreationalPatterns.MazePart;
    using CreationalPatterns.Prototype;
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            CreationalPatterns.MazeGame game = new CreationalPatterns.MazeGame();
            Maze maze = game.CreateMaze();
            MazeFactory factory = new EnchantedMazeFactory();
            maze = game.CreateMaze(factory);
            CountingMazeBuilder builder = new CountingMazeBuilder();
            game.CreateMaze(builder);
            Console.WriteLine("Rooms in maze is {0}", builder.RoomsCount);
            maze = new BombedMazeGame().CreateMaze();
            MazePrototypeFactory pFactory = new MazePrototypeFactory(new MazeP(), new RoomP(), new DoorP(), new BombedWallP());
            maze = game.CreateMaze(pFactory);
        }
    }
}

