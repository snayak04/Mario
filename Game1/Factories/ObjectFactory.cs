using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class ObjectFactory
    {
        public static ITextureAtlas flowerAtlas;
        public static ITextureAtlas coinAtlas;
        public static ITextureAtlas greenMushroomAtlas;
        public static ITextureAtlas redMushroomAtlas;
        public static ITextureAtlas starAtlas;
        public static ITextureAtlas disappearingCoinAtlas;

        private static ObjectFactory instance = new ObjectFactory();

        public static ObjectFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ObjectFactory()
        {

        }
        public void LoadAllTextures(ContentManager content)
        {
            flowerAtlas = new FourFrameTextureAtlas(content.Load<Texture2D>("Flower"));
            coinAtlas = new ThreeFrameTextureAtlas(content.Load<Texture2D>("Coin"));
            starAtlas = new FourFrameTextureAtlas(content.Load<Texture2D>("Star"));
            greenMushroomAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("GreenMushroom"));
            redMushroomAtlas = new SingleFrameTextureAtlas(content.Load<Texture2D>("RedMushroom"));
            disappearingCoinAtlas = new FourFrameTextureAtlas(content.Load<Texture2D>("CoinDisappearing"));
        }

        public IObject CreateFlower(Vector2 pos)
        {
            return new FlowerObject(flowerAtlas, pos);
        }

        public IObject CreateCoin(Vector2 pos)
        {
            return new CoinObject(coinAtlas, pos);
        }

        public IObject CreateStar(Vector2 pos)
        {
            return new StarObject(starAtlas, pos);
        }

        public IObject CreateRedMushroom(Vector2 pos)
        {
            return new RedMushroomObject(redMushroomAtlas, pos);
        }

        public IObject CreateGreenMushroom(Vector2 pos)
        {
            return new GreenMushroomObject(greenMushroomAtlas, pos);
        }
        public IObject CreateDisappearingCoin(Vector2 pos)
        {
            return new DisappearingCoinObject2(disappearingCoinAtlas, pos);
        }
    }

}
