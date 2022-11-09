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

        public Baddie(Texture2D txr, int xpos, int ypos, float baseSpeed)
        {
            m_txr = txr;
            m_pos = new Vector2(xpos, ypos);

            m_baseSpeed = baseSpeed;
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_txr, m_pos, Color.White);
        }
    }
}
