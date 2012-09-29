namespace CreationalPatterns.Prototype
{
    using System;

    public class BombedWallP : WallP
    {
        private bool hasBomb;

        public BombedWallP()
        {
        }

        public BombedWallP(BombedWallP other) : base(other)
        {
            this.hasBomb = other.hasBomb;
        }

        public override WallP Clone()
        {
            return new BombedWallP(this);
        }

        public void Initialize(bool hasBomb)
        {
            this.hasBomb = hasBomb;
        }
    }
}

