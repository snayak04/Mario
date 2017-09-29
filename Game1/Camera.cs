using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Camera
    {
        Vector2 position;
       private Matrix viewMatrix;
        public Matrix ViewMatrix
        {
            get
            {
                return viewMatrix;
            }
        }
        
        public void Update(Vector2 playerPosition)
        {
            position.X = playerPosition.X - 400;
            position.Y = playerPosition.Y -420;
            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }

        //This overloaded method is for the future game1
        public void Update(Point playerPosition)
        {
            position.X = playerPosition.X - 400;
            position.Y = playerPosition.Y - 420;
            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}
