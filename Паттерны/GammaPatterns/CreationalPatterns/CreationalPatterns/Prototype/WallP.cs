namespace CreationalPatterns.Prototype
{
    using CreationalPatterns.MazePart;
    using System;

    public class WallP : Wall
    {
        public WallP()
        {
        }

        public WallP(WallP wall)
        {
        }

        public virtual WallP Clone()
        {
            return new WallP(this);
        }

        public override void Enter()
        {
            throw new NotImplementedException();
        }
    }
}

