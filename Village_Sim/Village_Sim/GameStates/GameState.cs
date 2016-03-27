using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village_Sim.GameStates {

    public abstract class GameState {

        #region Variables

        protected VillageSim Game;

        #endregion

        #region Constructor

        protected GameState(VillageSim game) {
            Game = game;
        }

        #endregion

        #region Abstract Methods

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        #endregion

    }

}
