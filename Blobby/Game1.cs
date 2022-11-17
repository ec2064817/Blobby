using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Blobby
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpinningCoin coin;
        Baddie badguy;
        blobby p1Char;

        SpriteFont debugFont;

        KeyboardState kb;

        public static readonly Random RNG = new Random();

        StaticGraphic background;
        List<FloatingPlatform> platforms;

        const int Leafs = 32;
        Leaf[] _leaf;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 320;
            _graphics.PreferredBackBufferHeight = 240;
        }

        protected override void Initialize()
        {
            _leaf = new Leaf[Leafs];

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new StaticGraphic(Content.Load<Texture2D>("area_bkg"), 0, 0);

            debugFont = Content.Load<SpriteFont>("debugFont");

            platforms = new List<FloatingPlatform>();
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 10, 70));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 30, 140));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 50, 185));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 75, 150));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 85, 100));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 140, 80));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 150, 120));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 190, 90));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 240, 60));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 200, 155));
            platforms.Add(new FloatingPlatform(Content.Load<Texture2D>("platform"), 250, 150));

            for (int i = 0; i < Leafs; i++)
            {
                _leaf[i] = new Leaf(Content.Load<Texture2D>("tinyleaf"), _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }

            badguy = new Baddie(Content.Load<Texture2D>("baddieball"), _graphics.PreferredBackBufferWidth - 32, 100, 0.5f);
            
            p1Char = new blobby(Content.Load<Texture2D>("snipe_stand_right"), 0, 100);


            coin = new SpinningCoin(Content.Load<Texture2D>("spinning_coin_gold"), 100, 100, 8, 24);
            ResetCoin();
        }

        protected override void Update(GameTime gameTime)
        {
            kb = Keyboard.GetState();

            for (int i = 0; i < _leaf.Length; i++)
            {
                _leaf[i].UpdateMe(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            }

            

            badguy.UpdateMe(coin);

            if (coin.CollRect.Intersects(badguy.CollRect))
            {
                ResetCoin();
            }

            p1Char.UpdateMe(kb, GraphicsDevice.Viewport.Bounds);

            base.Update(gameTime);
        }

        private void ResetCoin()
        {
            int chosenPlatform = RNG.Next(platforms.Count);

            coin.MoveTo(
                platforms[chosenPlatform].Surface.Center.X - 8,
                platforms[chosenPlatform].Surface.Top - 16);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            background.DrawMe(_spriteBatch);

            for (int i = 0; i < platforms.Count; i++)
            {
                platforms[i].DrawMe(_spriteBatch);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                for (int i = 0; i < platforms.Count; i++)
                {
                    _spriteBatch.DrawString(debugFont, "Plat:" + i.ToString() + "\n" + platforms[i].m_pos.ToString() + "\n" + "W" + platforms[i].m_txr.Width.ToString() + "H" + platforms[i].m_txr.Height.ToString(), platforms[i].m_pos, Color.White);
                }
                
            }

            badguy.DrawMe(_spriteBatch);

            p1Char.DrawMe(_spriteBatch);

            coin.DrawMe(_spriteBatch, gameTime);

            for (int i = 0; i < _leaf.Length; i++)
            {
                _leaf[i].DrawMe(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}