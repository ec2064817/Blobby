using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobby
{
    internal class StaticGraphic
    {
       public Vector2 m_pos;
       public Texture2D m_txr;

        public StaticGraphic(Texture2D txr, int xpos, int ypos)
        {
            m_pos = new Vector2(xpos, ypos);
            m_txr = txr;
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(m_txr, m_pos, Color.White);
        }
    }
}
