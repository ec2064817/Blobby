using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobby
{
    internal class SpinningCoin
    {
        private Texture2D m_SpriteSheet;
        private Vector2 m_Pos;

        private Rectangle m_animCell;

        private float m_frameTimer;
        private float m_fps;

        public SpinningCoin(Texture2D spriteSheet, int xpos, int ypos, int frameCount, int fps)
        {
            m_SpriteSheet = spriteSheet;
            m_animCell = new Rectangle(0, 0, spriteSheet.Width / frameCount, spriteSheet.Height);
            m_Pos = new Vector2(xpos, ypos);
            m_frameTimer = 1;
            m_fps = fps;
        }   

        public void MoveTo(int xpos, int ypos)
        {
            m_Pos.X = xpos;
            m_Pos.Y = ypos;
        }

        public void DrawMe(SpriteBatch sb, GameTime gt)
        {
            if (m_frameTimer <= 0)
            {
                m_animCell.X = (m_animCell.X + m_animCell.Width);
                if (m_animCell.X >= m_SpriteSheet.Width)
                {
                    m_animCell.X = 0;
                }
                m_frameTimer = 1;
            }
            else
            {
                m_frameTimer -= (float)gt.ElapsedGameTime.TotalSeconds * m_fps;
            }
                

            sb.Draw(m_SpriteSheet, m_Pos, m_animCell, Color.White);
        }
    }
}
