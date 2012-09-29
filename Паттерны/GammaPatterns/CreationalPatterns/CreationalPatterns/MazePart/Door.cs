namespace CreationalPatterns.MazePart
{
    using System;

    public class Door : MapSite
    {
        private bool isOpen;
        private Room room1;
        private Room room2;

        public Door()
        {
        }

        public Door(Room room1, Room room2)
        {
            this.room1 = room1;
            this.room2 = room2;
        }

        public override void Enter()
        {
            throw new NotImplementedException();
        }

        public Room OtherSideFrom(Room room)
        {
            return ((room == this.room1) ? this.room2 : this.room1);
        }
    }
}

