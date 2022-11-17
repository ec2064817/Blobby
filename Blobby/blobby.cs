using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blobby
{
    internal class blobby
    {
        private Texture2D m_StandingSprite;
        private Vector2 m_pos;

        private float m_WalkSpeed;
        private Vector2 m_vel;

        public Rectangle CollRect;

        private const int collBorder = 4;

        public blobby(Texture2D standSprite, int xpos, int ypos)
        {
            m_StandingSprite = standSprite;
            m_pos = new Vector2(xpos, ypos);

            m_WalkSpeed = 1f;
            m_vel = Vector2.Zero;

            CollRect = new Rectangle(xpos, ypos, standSprite.Width, standSprite.Height);
        }

        public void UpdateMe(KeyboardState kb, Rectangle screenSize)
        {
            if(m_pos.X + CollRect.Width < 0)
                m_pos.X = screenSize.Width - 1;
            if (m_pos.X > screenSize.Width)
                m_pos.X = 1 - CollRect.Width;

            m_vel.X = 0;
            if (kb.IsKeyDown(Keys.D))
            {
                m_vel.X = m_WalkSpeed;
            }
            else if (kb.IsKeyDown(Keys.A))
            {
                m_vel.X = -m_WalkSpeed;
            }

            m_pos += m_vel;
            CollRect.X = (int)m_pos.X;
            CollRect.Y = (int)m_pos.Y;

        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_StandingSprite, m_pos, null, Color.White);
        }
    }
}
