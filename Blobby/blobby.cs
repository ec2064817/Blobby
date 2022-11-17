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

        private const int FOOTMARGIN = 3;
        private Rectangle m_feetPos;

        public blobby(Texture2D standSprite, int xpos, int ypos)
        {
            m_StandingSprite = standSprite;
            m_pos = new Vector2(xpos, ypos);

            m_WalkSpeed = 1f;
            m_vel = Vector2.Zero;

            CollRect = new Rectangle(xpos, ypos, standSprite.Width, standSprite.Height);

            m_feetPos = new Rectangle(CollRect.X + FOOTMARGIN,
                CollRect.Y + CollRect.Height - 2, 
                CollRect.Width - (FOOTMARGIN*2),
                2);
        }

        public void UpdateMe(KeyboardState kb, Rectangle screenSize, float gravity, int ground, List<FloatingPlatform> plats)
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

            if (CollRect.Bottom < ground)
            {
                if (m_vel.Y < gravity * 15)
                {
                    m_vel.Y += gravity;
                }

                for (int i = 0; i < plats.Count; i++)
                {
                    if (plats[i].Surface.Intersects(m_feetPos))
                    {
                        if (m_vel.Y > 0)
                        {
                            m_vel.Y = 0;
                            m_pos.Y = plats[i].Surface.Top -
                                CollRect.Height + 1;
                        }
                    }
                }
                
            }
            else
            {
                m_vel.Y = 0;
                m_pos.Y = ground - CollRect.Height;
            }

            if ((kb.IsKeyDown(Keys.W)) && m_vel.Y == 0) 
            {
                m_vel.Y = -5;
            }

            m_feetPos.X = CollRect.X + FOOTMARGIN;
            m_feetPos.Y = CollRect.Y + CollRect.Height - 2;  
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_StandingSprite, m_pos, null, Color.White);
        }
    }
}
