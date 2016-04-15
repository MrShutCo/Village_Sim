using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Village_Sim.Sprites;

namespace Village_Sim.Helpers
{
    public class Spawn
    {

        public Spawn() {
        }

        public List<Sprite> SpawnSprite(Texture2D texture, int spawnCap)
        {
            List<Sprite> sprites = new List<Sprite>();
            Random r = new Random();
            for (int i = 0; i < spawnCap; i++)
            {
                Sprite v = new Sprite(texture, new Vector2(r.Next(0, 800), r.Next(0, 600)), new Rectangle(0, 0, 0, 0));
                sprites.Add(v);
            }
            return sprites;
        }
    }
}
