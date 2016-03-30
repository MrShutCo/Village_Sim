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
        private List<Villager> villagers = new List<Villager>();

        public void SpawnVillagers(Villager villager, int spawnCap)
        {
            for (int i = 0; i < spawnCap; i++)
            {
                villagers.Add(villager);
            }
        }
    }
}
