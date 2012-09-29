namespace CreationalPatterns.Prototype
{
    using CreationalPatterns.MazePart;
    using System;

    public class RoomP : Room
    {
        private int roomNumber;

        public RoomP()
        {
        }

        public RoomP(RoomP room)
        {
            this.roomNumber = room.roomNumber;
        }

        public virtual RoomP Clone()
        {
            return new RoomP(this);
        }

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public virtual void Initialize(int number)
        {
            this.roomNumber = number;
        }
    }
}

