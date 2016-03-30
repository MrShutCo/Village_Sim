using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Village_Sim.Helpers;

namespace Village_Sim.Sprites {
    public class Villager : Sprite
    {
 
        public Villager(Texture2D texture, Vector2 position, Rectangle movementBounds)
            : base(texture, position, movementBounds){
            Velocity = Vector2.Zero;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

    }
}
