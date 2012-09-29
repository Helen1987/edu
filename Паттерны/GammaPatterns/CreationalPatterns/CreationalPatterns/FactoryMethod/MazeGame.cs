namespace CreationalPatterns.FactoryMethod
{
    using CreationalPatterns.MazePart;
    using System;

    public class MazeGame
    {
        public Maze CreateMaze()
        {
            Maze maze = this.MakeMaze();
            Room r1 = this.MakeRoom(1);
            Room r2 = this.MakeRoom(2);
            Door theDoor = this.MakeDoor(r1, r2);
            maze.AddRoom(r1);
            maze.AddRoom(r2);
            r1.SetSide(Direction.North, this.MakeWall());
            r1.SetSide(Direction.East, theDoor);
            r1.SetSide(Direction.South, this.MakeWall());
            r1.SetSide(Direction.West, this.MakeWall());
            r2.SetSide(Direction.North, this.MakeWall());
            r2.SetSide(Direction.East, this.MakeWall());
            r2.SetSide(Direction.South, this.MakeWall());
            r2.SetSide(Direction.West, theDoor);
            return maze;
        }

        public virtual Door MakeDoor(Room room1, Room room2)
        {
            return new Door(room1, room2);
        }

        public virtual Maze MakeMaze()
        {
            return new Maze();
        }

        public virtual Room MakeRoom(int room)
        {
            return new Room(room);
        }

        public virtual Wall MakeWall()
        {
            return new Wall();
        }
    }
}

