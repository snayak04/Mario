using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ItemCreator
    {
        public static Vector2 currPosition { get; set; }
        public static List<IItems> LoadItems()
        {
            List<IItems> items = new List<IItems>();
            List<String[]> loading = LevelLoader.ReturnLevel();
            int x =0, y=0;
            foreach(String[] row in loading)
            {

                foreach(String column in row)
                {
                    IItems block=null;
                    currPosition = new Vector2(x*ItemFactory.Instance.brickBlock.Width, y*ItemFactory.Instance.brickBlock.Height);

                    switch(column)
                    {
                        case "sb":
                            block = ItemFactory.Instance.CreateShadedBlock(currPosition);
                            break;
                        case "hsb":
                            block = HiddenLevelItemFactory.Instance.CreateShadedBlock(currPosition);
                            break;
                        case "greenmushroom":
                            block = ItemFactory.Instance.CreateMysteryBlockGreenMushroom(currPosition);
                            break;
                        case "redmushroom":
                            block = ItemFactory.Instance.CreateMysteryBlockRedMushroom(currPosition);
                            break;
                        case "flower":
                            block = ItemFactory.Instance.CreateMysteryBlockFlower(currPosition);
                            break;
                        case "star":
                            block = ItemFactory.Instance.CreateMysteryBlockStar(currPosition);
                            break;
                        case "coin":
                            block = ItemFactory.Instance.CreateMysteryBlockCoin(currPosition);
                            break;
                        case "bb":
                            block = ItemFactory.Instance.CreateBrickBlock(currPosition);
                            break;
                        case "hbb":
                            block = HiddenLevelItemFactory.Instance.CreateBrickBlock(currPosition);
                            break;
                        case "cb":
                            block = ItemFactory.Instance.CreateCoinBlock(currPosition);
                            break;
                        case "hcb":
                            block = HiddenLevelItemFactory.Instance.CreateCoinBlock(currPosition);
                            break;
                        case "fb":
                            block = ItemFactory.Instance.CreateRockBlock(currPosition);
                            break;
                        case "hfb":
                            block = HiddenLevelItemFactory.Instance.CreateRockBlock(currPosition);
                            break;
                        case "p":
                            block = ItemFactory.Instance.CreatePipe(new Vector2(currPosition.X - 10, currPosition.Y - ItemFactory.Instance.brickBlock.Height));
                            break;
                        case "hp":
                            block = HiddenLevelItemFactory.Instance.CreatePipe(new Vector2(currPosition.X - 10, currPosition.Y - HiddenLevelItemFactory.Instance.hBrickBlock.Height));
                            break;
                        case "hb":
                            block = ItemFactory.Instance.CreateHiddenBlock(currPosition);
                            break;
                        case "tp":
                            block = ItemFactory.Instance.CreateTransitionPipe(new Vector2(currPosition.X - 10, currPosition.Y - ItemFactory.Instance.brickBlock.Height));
                            break;
                        case "tpu":
                            block = ItemFactory.Instance.CreateUpsideDownTransitionPipe(new Vector2(currPosition.X - 10, currPosition.Y - ItemFactory.Instance.brickBlock.Height));
                            break;
                        case "flag":
                            currPosition = new Vector2(x * ItemFactory.Instance.brickBlock.Width, (y+1) * ItemFactory.Instance.brickBlock.Height);
                            block = ItemFactory.Instance.CreateFlagPole(currPosition);
                            break;
                        default:
                            break;
                    }

                    if(block != null)
                    {
                        items.Add(block);
                    }
                    x++;
                }

                x = 0;
                y++;
            }

            return items;
        }
    }
}
