using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameJamTest.Assets;
using GameJamTest.Screens;

namespace GameJamTest.GameObjects
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Arsenal : GameJamComponent
    {
        private Animation theArsenal;
        public Arsenal(Game game, GameScreen screen)
            : base(game, screen, new Vector2((Game1.SCREEN_WIDTH / 2) - 120, Game1.SCREEN_HEIGHT / 2))
        {
            this.width = 80;
            this.height = 80;
            scale = 3;
            this.Layer = Layer.FRONT;
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            theArsenal = new Animation(this.Game.Content, "Sprites/Arsenal2", this.width, this.height, 4, 15);
            theArsenal.EnableRepeating();
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            theArsenal.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            theArsenal.Draw((this.Game as Game1).SpriteBatch, position, 0.0f, this.scale);
            base.Draw(gameTime);
        }
    }
}
