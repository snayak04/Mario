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
    public class ItemFactory
    {
        //Regular level textures
        public Texture2D pipe;
        public Texture2D transitionPipe;
        public Texture2D upsideDownTransitionPipe;
        public Texture2D brickBlock;
        public Texture2D rockBlock;
        public Texture2D usedBlock;
        public Texture2D mysteryBlock;
        public Texture2D shadedBlock;
        public Texture2D hiddenBlock;
        public Texture2D coin;
        public Texture2D flower;
        public Texture2D brickBlockFallingRight;
        public Texture2D brickBlockFallingLeft;
        public ITextureAtlas flagPole;
        
        private static ItemFactory instance = new ItemFactory();

        public static ItemFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ItemFactory() { }
        public void LoadAllTextures(ContentManager content)
        {
            pipe = content.Load<Texture2D>("pipe");
            transitionPipe = content.Load<Texture2D>("pipe");
            brickBlock = content.Load<Texture2D>("BrickBlock");
            rockBlock = content.Load<Texture2D>("RockBlock");
            usedBlock = content.Load<Texture2D>("UsedBlock");
            mysteryBlock = content.Load<Texture2D>("MysteryBlock");
            shadedBlock = content.Load<Texture2D>("ShadedBlock");
            hiddenBlock = content.Load<Texture2D>("HiddenBlock");
            coin = content.Load<Texture2D>("Coin");
            flower = content.Load<Texture2D>("Flower");
            brickBlockFallingRight = content.Load<Texture2D>("BrickBlockPiecesFallingRight");
            brickBlockFallingLeft = content.Load<Texture2D>("BrickBlockPiecesFallingLeft");
            flagPole = new FiveFrameTextureAtlas(content.Load<Texture2D>("flag8"));
            upsideDownTransitionPipe = content.Load<Texture2D>("UpsideDownTransition");

        }

        public IItems CreateFlagPole(Vector2 pos)
        {
            return new FlagPoleItem(flagPole, pos);
        }
        public IItems CreateTransitionPipe(Vector2 pos)
        {
            return new TransitionPipeItem(transitionPipe, pos);
        }
        public IItems CreateUpsideDownTransitionPipe(Vector2 pos)
        {
            return new TransitionPipeItem(upsideDownTransitionPipe, pos);
        }
        public IItems CreateBrickBlock(Vector2 pos)
        {
            return new BrickBlockItem(brickBlock, pos);
        }
        public IItems CreateCoinBlock(Vector2 pos)
        {
            return new CoinBlockItem(brickBlock, pos);
        }
        public IItems CreateRockBlock(Vector2 pos)
        {
            return new RockBlockItem(rockBlock, pos);
        }

        public IItems CreatePipe(Vector2 pos)
        {
            return new PipeItem(pipe, pos);
        }
        public IItems CreateHiddenBlock(Vector2 pos)
        {
            return new HiddenBlockItem(hiddenBlock, pos);
        }
        public IItems CreateMysteryBlockGreenMushroom(Vector2 pos)
        {
            return new MysteryBlockGreenMushroomItem(mysteryBlock, pos);
        }
        public IItems CreateMysteryBlockRedMushroom(Vector2 pos)
        {
            return new MysteryBlockRedMushroomItem(mysteryBlock, pos);
        }
        public IItems CreateMysteryBlockStar(Vector2 pos)
        {
            return new MysteryBlockStarItem(mysteryBlock, pos);
        }
        public IItems CreateMysteryBlockFlower(Vector2 pos)
        {
            return new MysteryBlockFlowerItem(mysteryBlock, pos);
        }
        public IItems CreateMysteryBlockCoin(Vector2 pos)
        {
            return new MysteryBlockCoinItem2(mysteryBlock, pos);
        }
        public IItems CreateUsedBlock(Vector2 pos)
        {
            return new UsedBlockItem(usedBlock, pos);
        }
        public IItems CreateShadedBlock(Vector2 pos)
        {
            return new ShadedBlockItem(shadedBlock, pos);
        }
        public IItems CreateBrickBlockPiecesExplodingHighRight(Vector2 pos)
        {
            return new BrickBlockPiecesExplodingHighRightItem(brickBlockFallingRight, pos);
        }
        public IItems CreateBrickBlockPiecesExplodingLowRight(Vector2 pos)
        {
            return new BrickBlockPiecesExplodingLowRightItem(brickBlockFallingRight, pos);
        }
        public IItems CreateBrickBlockPiecesExplodingHighLeft(Vector2 pos)
        {
            return new BrickBlockPiecesExplodingHighLeftItem(brickBlockFallingLeft, pos);
        }
        public IItems CreateBrickBlockPiecesExplodingLowLeft(Vector2 pos)
        {
            return new BrickBlockPiecesExplodingLowLeftItem(brickBlockFallingLeft, pos);
        }
    }
}
