using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village_Sim.Sprites {
    public class Sprite {

        private readonly Texture2D _texture;
        protected Rectangle MovementBounds;

        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle BoundingBox { get { return new Rectangle((int)Position.X, (int)Position.Y, 32, 32); } }

        public Sprite(Texture2D texture, Vector2 position, Rectangle movementBounds) {
            _texture = texture;
            Position = position;
            MovementBounds = movementBounds;
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public virtual void Update(GameTime gameTime) {

        }

    }
}
