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
    public class HiddenLevelItemFactory
    {
        //Hidden level textures
        public Texture2D hPipe;
        public Texture2D exitPipeEntrance;
        public Texture2D exitPipe;
        public Texture2D hBrickBlock;
        public Texture2D hRockBlock;
        public Texture2D hUsedBlock;
        public Texture2D hShadedBlock;
        public Texture2D hHiddenBlock;
        public Texture2D hBrickBlockFallingRight;
        public Texture2D hBrickBlockFallingLeft;

        private static HiddenLevelItemFactory instance = new HiddenLevelItemFactory();

        public static HiddenLevelItemFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private HiddenLevelItemFactory() { }
        public void LoadAllTextures(ContentManager content)
        {
            hPipe = content.Load<Texture2D>("pipe");
            exitPipeEntrance = content.Load<Texture2D>("ExitHiddenPipe");
            exitPipe = content.Load<Texture2D>("ExitExtraPipe");
            hBrickBlock = content.Load<Texture2D>("HiddenLevelBrickBlock");
            hRockBlock = content.Load<Texture2D>("HiddenLevelRockBlock");
            hUsedBlock = content.Load<Texture2D>("HiddenLevelUsedBlock");
            hShadedBlock = content.Load<Texture2D>("HiddenLevelShadedBlock");
            hHiddenBlock = content.Load<Texture2D>("HiddenLevelHiddenBlock");
            hBrickBlockFallingRight = content.Load<Texture2D>("HiddenLevelBrickBlockPiecesFallingRight");
            hBrickBlockFallingLeft = content.Load<Texture2D>("HiddenLevelBrickBlockPiecesFallingLeft");

        }

        public IItems CreateBrickBlock(Vector2 pos)
        {
            return new BrickBlockItem(hBrickBlock, pos);
        }
        public IItems CreateCoinBlock(Vector2 pos)
        {
            return new CoinBlockItem(hBrickBlock, pos);
        }
        public IItems CreateRockBlock(Vector2 pos)
        {
            return new RockBlockItem(hRockBlock, pos);
        }

        public IItems CreatePipe(Vector2 pos)
        {
            return new PipeItem(hPipe, pos);
        }
        public IItems CreateHiddenBlock(Vector2 pos)
        {
            return new HiddenBlockItem(hHiddenBlock, pos);
        }
       
        public IItems CreateUsedBlock(Vector2 pos)
        {
            return new UsedBlockItem(hUsedBlock, pos);
        }
        public IItems CreateShadedBlock(Vector2 pos)
        {
            return new ShadedBlockItem(hShadedBlock, pos);
        }
        public IItems CreateBrickBlockPiecesExplodingHighRight(Vector2 pos)
        {
            return new BrickBlockPiecesExplodingHighRightItem(hBrickBlockFallingRight, pos);
        }
        public IItems CreateBrickBlockPiecesExplodingLowRight(Vector2 pos)
        {
            return new BrickBlockPiecesExplodingLowRightItem(hBrickBlockFallingRight, pos);
        }
        public IItems CreateBrickBlockPiecesExplodingHighLeft(Vector2 pos)
        {
            return new BrickBlockPiecesExplodingHighLeftItem(hBrickBlockFallingLeft, pos);
        }
        public IItems CreateBrickBlockPiecesExplodingLowLeft(Vector2 pos)
        {
            return new BrickBlockPiecesExplodingLowLeftItem(hBrickBlockFallingLeft, pos);
        }
    }
}
