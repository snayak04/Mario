using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ProjectileFactory
    {
        public static ITextureAtlas fireballAtlas;
        public Texture2D Shell { get; set; }
        public Texture2D HiddenLevelShell { get; set; }
        //more projectile textures to be added later

        private static ProjectileFactory instance = new ProjectileFactory();

        public static ProjectileFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ProjectileFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            fireballAtlas = new FourFrameTextureAtlas(content.Load<Texture2D>("Fireball"));
            Shell = content.Load<Texture2D>("shell");
            HiddenLevelShell = content.Load<Texture2D>("HiddenLevelShell");

        }

        public IProjectile CreateHiddenLevelShell(Vector2 pos)
        {
            pos.Y = pos.Y - HiddenLevelShell.Height;
            return new ShellProjectile(HiddenLevelShell, pos);
        }
        public IProjectile CreateFireball(Vector2 pos, bool isShotRight)
        {
            return new FireballProjectile(fireballAtlas, pos, isShotRight);
        }

        public IProjectile CreateShell(Vector2 pos)
        {
            pos.Y = pos.Y - Shell.Height;
            return new ShellProjectile(Shell, pos);
        }
    }

}
