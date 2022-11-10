using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blobby
{
    internal class Leaf
    {
        private Texture2D _txr;

        Vector2 _pos;
        Vector2 _vel;
        float _rot;
        float _rotSpeed;

        public Leaf(Texture2D txr, int maxX, int maxY)
        {
            _txr = txr;
            _pos = new Vector2(Game1.RNG.Next(-250, 0), Game1.RNG.Next(0, 240));
            _vel = new Vector2((float)Game1.RNG.NextDouble() + 0.25f, 0);
            _rot = 0;
            _rotSpeed = (float)(Game1.RNG.NextDouble() - 0.5f) / 10;


        }

        public void UpdateMe(int maxX, int maxY)
        {
            _pos = _pos + _vel;
            _rot = _rot + _rotSpeed;

            if (_pos.X > maxX)
            {
                _pos = new Vector2(Game1.RNG.Next(-250, 0), Game1.RNG.Next(0, 240));
                _vel = new Vector2((float)Game1.RNG.NextDouble() + 0.25f, 0);
                _rotSpeed = (float)(Game1.RNG.NextDouble() - 0.5f) / 10;
            }


        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(_txr, _pos, null, Color.White * 0.75f,
                _rot, Vector2.Zero, _vel.X,
                SpriteEffects.None, 0);
            
        }
    }
}
