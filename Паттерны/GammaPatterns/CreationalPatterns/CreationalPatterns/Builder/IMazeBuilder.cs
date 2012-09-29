namespace CreationalPatterns.Builder
{
    using System;

    public interface IMazeBuilder
    {
        void BuildDoor(int doorFrom, int doorTo);
        void BuildMaze();
        void BuildRoom(int i);
    }
}

