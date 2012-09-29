namespace CreationalPatterns.Prototype
{
    using CreationalPatterns.MazePart;
    using System;

    public class MazeP : Maze
    {
        public MazeP()
        {
        }

        public MazeP(MazeP maze)
        {
        }

        public virtual MazeP Clone()
        {
            return new MazeP(this);
        }

        public virtual void Initialize()
        {
        }
    }
}

