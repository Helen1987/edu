namespace CreationalPatterns
{
    using CreationalPatterns.AbstractFactory;
    using CreationalPatterns.Builder;
    using CreationalPatterns.MazePart;
    using System;

    public class MazeGame
    {
        public void CreateComplexMaze(IMazeBuilder builder)
        {
            for (int i = 0; i < 100; i++)
            {
                builder.BuildRoom(i);
            }
        }

        public Maze CreateMaze()
        {
            Maze maze = new Maze();
            Room r1 = new Room(1);
            Room r2 = new Room(2);
            Door theDoor = new Door(r1, r2);
            maze.AddRoom(r1);
            maze.AddRoom(r2);
            r1.SetSide(Direction.North, new Wall());
            r1.SetSide(Direction.East, theDoor);
            r1.SetSide(Direction.South, new Wall());
            r1.SetSide(Direction.West, new Wall());
            r2.SetSide(Direction.North, new Wall());
            r2.SetSide(Direction.East, new Wall());
            r2.SetSide(Direction.South, new Wall());
            r2.SetSide(Direction.West, theDoor);
            return maze;
        }

        public Maze CreateMaze(MazeFactory mazeFActory)
        {
            Maze maze = mazeFActory.MakeMaze();
            Room r1 = mazeFActory.MakeRoom(1);
            Room r2 = mazeFActory.MakeRoom(2);
            Door theDoor = mazeFActory.MakeDoor(r1, r2);
            maze.AddRoom(r1);
            maze.AddRoom(r2);
            r1.SetSide(Direction.North, mazeFActory.MakeWall());
            r1.SetSide(Direction.East, theDoor);
            r1.SetSide(Direction.South, mazeFActory.MakeWall());
            r1.SetSide(Direction.West, mazeFActory.MakeWall());
            r2.SetSide(Direction.North, mazeFActory.MakeWall());
            r2.SetSide(Direction.East, mazeFActory.MakeWall());
            r2.SetSide(Direction.South, mazeFActory.MakeWall());
            r2.SetSide(Direction.West, theDoor);
            return maze;
        }

        public void CreateMaze(IMazeBuilder builder)
        {
            builder.BuildMaze();
            builder.BuildRoom(1);
            builder.BuildRoom(2);
            builder.BuildDoor(1, 2);
        }
    }
}

