using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobby
{
    internal class Baddie
    {
        private Texture2D m_txr;
        private Vector2 m_pos;

        private float m_baseSpeed;
        private Vector2 m_vel;

        public Rectangle CollRect;

        public Baddie(Texture2D txr, int xpos, int ypos, float baseSpeed)
        {
            m_txr = txr;
            m_pos = new Vector2(xpos, ypos);

            m_baseSpeed = baseSpeed;
            m_vel = Vector2.Zero;

            CollRect = new Rectangle(xpos, ypos, txr.Width, txr.Height);
        }

        public void UpdateMe(SpinningCoin target)
        {
            CollRect.X = (int)m_pos.X;
            CollRect.Y = (int)m_pos.Y;

            m_vel.X = target.CollRect.Center.X - this.CollRect.Center.X;
            m_vel.Y = target.CollRect.Center.Y - this.CollRect.Center.Y;
            m_vel.Normalize();

            m_vel *= m_baseSpeed;

            m_pos += m_vel;

            
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_txr, m_pos, Color.White);
        }
    }
}
