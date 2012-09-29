namespace CreationalPatterns.Builder
{
    using CreationalPatterns.MazePart;
    using System;

    public class StandartMazeBuilder : IMazeBuilder
    {
        private Maze maze;

        public void BuildDoor(int room1, int room2)
        {
            Room r1 = this.maze[room1];
            Room r2 = this.maze[room2];
            Door newDoor = new Door(r1, r2);
            r1.SetSide(this.CommonWall(r1, r2), newDoor);
            r2.SetSide(this.CommonWall(r2, r1), newDoor);
        }

        public void BuildMaze()
        {
            this.maze = new Maze();
        }

        public void BuildRoom(int room)
        {
            if (this.maze[room] == null)
            {
                Room newRoom = new Room(room);
                this.maze.AddRoom(newRoom);
                newRoom.SetSide(Direction.West, new Wall());
                newRoom.SetSide(Direction.South, new Wall());
                newRoom.SetSide(Direction.North, new Wall());
                newRoom.SetSide(Direction.East, new Wall());
            }
        }

        private Direction CommonWall(Room r1, Room r2)
        {
            return Direction.West;
        }

        public Maze GetMaze()
        {
            return this.maze;
        }
    }
}

