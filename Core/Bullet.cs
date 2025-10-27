using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Core
{
    internal class Bullet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BulletVisual Visual { get; set; }
        
    }

    internal class BulletVisual
    {
        public string Path { get; set; }
        public float Scale { get; set; }
        public Vector2 Position { get; set; }
    }
}
