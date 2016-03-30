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
        public List<Villager> villagers = new List<Villager>();
        public VillageSim Game;

        public Spawn(VillageSim game) {
            Game = game;
        }

        public void SpawnVillagers(int spawnCap)
        {
            Random r = new Random();
            for (int i = 0; i < spawnCap; i++)
            {
                Villager v = new Villager(Game.villagerTexture, new Vector2(r.Next(0, 800), r.Next(0, 600)), new Rectangle(0, 0, 0, 0));
                villagers.Add(v);
            }
        }
    }
}
