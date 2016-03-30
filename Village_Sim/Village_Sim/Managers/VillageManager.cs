using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Village_Sim.Sprites;

namespace Village_Sim.Managers {
    public class VillageManager {

        public List<Villager> Villagers { get; set; }
        private Game game;

        public VillageManager(VillageSim vs) {
            game = vs;
        }

        public void Update(GameTime gameTime) {
            foreach (Villager v in Villagers) {
                if (v.Age <= 15 && v.VillagerState != VillagerState.Child) {
                    v.VillagerState = VillagerState.Child;
                }
                else if (v.Age <= 50 && v.VillagerState != VillagerState.Adult) {
                    v.VillagerState = VillagerState.Adult;
                }
                else if (v.Age > 50 && v.VillagerState != VillagerState.Old && v.VillagerState != VillagerState.Dead) {
                    v.VillagerState = VillagerState.Old;
                }
                else {
                    v.VillagerState = VillagerState.Dead;
                }
            }
        }

    }
}
