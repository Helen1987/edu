namespace CreationalPatterns.AbstractFactory
{
    using CreationalPatterns.MazePart;
    using System;

    public class EnchantedMazeFactory : MazeFactory
    {
        protected Spell CastSpell()
        {
            return new Spell();
        }

        public override Door MakeDoor(Room r1, Room r2)
        {
            return new DoorNeedingSpell(r1, r2);
        }

        public override Room MakeRoom(int i)
        {
            return new EnchantedRoom(i);
        }
    }
}

