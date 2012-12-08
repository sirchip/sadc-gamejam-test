﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace GameJamTest.Assets
{
    class Backgrounds
    {
        //backgrounds
        public Texture2D texture;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, new Color(255,255,255,255));
        }
    }

    class Scrolling : Backgrounds
    {
        public Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }

        public void Update(int speed)
        {
            rectangle.X -= speed;
        }
    }

    public class ParallaxBackground
    {
        private static Scrolling scroll1, scroll2, scroll3, scroll4;
        private static Texture2D staticBackground;

        public static void Initialize(ContentManager content)
        {
            scroll1 = new Scrolling(content.Load<Texture2D>("Backgrounds/starfield1"), new Rectangle(0, 0, 800, 500));
            scroll2 = new Scrolling(content.Load<Texture2D>("Backgrounds/starfield1"), new Rectangle(800, 0, 800, 500));
            scroll3 = new Scrolling(content.Load<Texture2D>("Backgrounds/starfield2"), new Rectangle(0, 0, 800, 500));
            scroll4 = new Scrolling(content.Load<Texture2D>("Backgrounds/starfield2"), new Rectangle(800, 0, 800, 500));
            staticBackground = content.Load<Texture2D>("Backgrounds/black");
        }

        public static void Update(GameTime gameTime)
        {
            if (scroll1.rectangle.X + scroll1.texture.Width <= 0)
            {
                scroll1.rectangle.X = scroll2.rectangle.X + scroll2.texture.Width;
            }
            if (scroll2.rectangle.X + scroll2.texture.Width <= 0)
            {
                scroll2.rectangle.X = scroll1.rectangle.X + scroll1.texture.Width;
            }
            if (scroll3.rectangle.X + scroll3.texture.Width <= 0)
            {
                scroll3.rectangle.X = scroll4.rectangle.X + scroll4.texture.Width;
            }
            if (scroll4.rectangle.X + scroll4.texture.Width <= 0)
            {
                scroll4.rectangle.X = scroll3.rectangle.X + scroll3.texture.Width;
            }
            scroll1.Update(3);
            scroll2.Update(3);
            scroll3.Update(1);
            scroll4.Update(1);
        }

        public static void Draw(Game game)
        {
            SpriteBatch spriteBatch = (game as Game1).SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.Draw(staticBackground, new Rectangle(0, 0, game.GraphicsDevice.PresentationParameters.BackBufferWidth, game.GraphicsDevice.PresentationParameters.BackBufferHeight), Color.White);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            scroll3.Draw(spriteBatch);
            scroll4.Draw(spriteBatch);
            scroll1.Draw(spriteBatch);
            scroll2.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
