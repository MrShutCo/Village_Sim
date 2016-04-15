using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Village_Sim.Sprites;
using Village_Sim.Helpers;

namespace Village_Sim {
    public class Simulation {

        //Maybe place handlers and stuff?
        Dictionary<string, Texture2D> Textures;

        Spawn Spawn;

        List<Sprite> Sprites;

        public Simulation(Dictionary<string, Texture2D> textures) {
            //Initialize stuff later
            Textures = textures;
            Sprites = new List<Sprite>();
            Spawn = new Spawn();
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (Sprite s in Sprites) {
                s.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime) {
            Sprites.AddRange(Spawn.SpawnSprite(Textures["Villager"], 10));
            foreach (Sprite s in Sprites) {
                s.Update(gameTime);
                
            }
        }

    }
}
