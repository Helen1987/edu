namespace CreationalPatterns.Prototype
{
    using CreationalPatterns.AbstractFactory;
    using CreationalPatterns.MazePart;
    using System;

    public class MazePrototypeFactory : MazeFactory
    {
        private DoorP prototypeDoor;
        private MazeP prototypeMaze;
        private RoomP prototypeRoom;
        private WallP prototypeWall;

        public MazePrototypeFactory(MazeP maze, RoomP room, DoorP door, WallP wall)
        {
            this.prototypeRoom = room;
            this.prototypeDoor = door;
            this.prototypeWall = wall;
            this.prototypeMaze = maze;
        }

        public override Door MakeDoor(Room r1, Room r2)
        {
            DoorP newDoor = this.prototypeDoor.Clone();
            newDoor.Initialize(r1 as RoomP, r2 as RoomP);
            return newDoor;
        }

        public override Maze MakeMaze()
        {
            return this.prototypeMaze.Clone();
        }

        public override Room MakeRoom(int i)
        {
            return this.prototypeRoom.Clone();
        }

        public override Wall MakeWall()
        {
            return this.prototypeWall.Clone();
        }
    }
}

