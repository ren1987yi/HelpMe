using System.Numerics;

namespace HelpMe.Core
{
    internal class Weapon
    {
        public int Id { get; set; }
        public bool IsRemote { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Power { get; set; }

        public float CheckRange { get; set; }

        public float CoolDownTime { get; set; }


        public WeaponVisual Visual { get; set; }
       
    }

    internal class WeaponVisual
    {
        public string Path { get; set; }
        public float Scale { get; set; }
        public Vector2 Position { get; set; }
    }
}
