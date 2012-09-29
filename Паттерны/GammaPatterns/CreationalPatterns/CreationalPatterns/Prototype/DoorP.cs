namespace CreationalPatterns.Prototype
{
    using CreationalPatterns.MazePart;
    using System;

    public class DoorP : Door
    {
        private RoomP room1;
        private RoomP room2;

        public DoorP()
        {
        }

        public DoorP(DoorP door)
        {
            this.room1 = door.room1;
            this.room2 = door.room2;
        }

        public virtual DoorP Clone()
        {
            return new DoorP(this);
        }

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public virtual void Initialize(RoomP room1, RoomP room2)
        {
            this.room1 = room1;
            this.room2 = room2;
        }

        public RoomP OtherSideFrom(RoomP room)
        {
            return ((room == this.room1) ? this.room2 : this.room1);
        }
    }
}

