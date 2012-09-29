namespace CreationalPatterns.FactoryMethod
{
    using CreationalPatterns.MazePart;
    using System;

    public class EnchantedMazeGame : MazeGame
    {
        protected Spell CastSpell()
        {
            return new Spell();
        }

        public override Door MakeDoor(Room room1, Room room2)
        {
            return new DoorNeedingSpell(room1, room2);
        }

        public override Room MakeRoom(int room)
        {
            return new EnchantedRoom(room);
        }
    }
}

