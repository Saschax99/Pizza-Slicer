using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class ItemSkinColor : MonoBehaviour
{
    private bool[] Boughts = new bool[9]; // LAST IS EXCLUSIVE

    [SerializeField] private List<GameObject> ItemSkinColors = new List<GameObject>();

    private GameObject TextItemInfo;

    private void Start()
    {
        TextItemInfo = GameObject.Find("Canvas/TextItemInfo");
        LoadItemStatsAndChange(true); // LOADING STATS OF ITEMS
    }
    #region Items
    public void SkinColor0White()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.Saw1Skin) // BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw1Skin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.Saw1Skin));
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[0] = true;
            }
            else
            {
                allboughts[0] = true;
            }

            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.Saw1Skin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.Saw1Skin) // NOT ENOUGHT BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw1Skin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.Saw1Skin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw1Skin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.Saw1Skin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.Saw1Skin);
        }
    }
    public void SkinColor1Black()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.Saw2Skin)// BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw2Skin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.Saw2Skin));
            //var allboughts = SaveGame.Load<bool[]>("Boughts", 0);
            //allboughts[1] = true;
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[1] = true;
            }
            else
            {
                allboughts[1] = true;
            }

            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.Saw2Skin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.Saw2Skin) // NOT ENOUGH BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw2Skin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.Saw2Skin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw2Skin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.Saw2Skin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.Saw2Skin);
        }
    }

    public void SkinColor2Blue()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.Saw3Skin)// BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw3Skin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.Saw3Skin));
            //var allboughts = SaveGame.Load<bool[]>("Boughts", 0);
            //allboughts[2] = true;
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[2] = true;
            }
            else
            {
                allboughts[2] = true;
            }

            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.Saw3Skin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.Saw3Skin) // NOT ENOUGH BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw3Skin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.Saw3Skin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.Saw3Skin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.Saw3Skin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.Saw3Skin);
        }
    }
    public void SkinColor3Brown()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.SmileySkin)// BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.SmileySkin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.SmileySkin));
            //var allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
            //allboughts[3] = true;
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[3] = true;
            }
            else
            {
                allboughts[3] = true;
            }
            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.SmileySkin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.SmileySkin)// NOT ENOUGH BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.SmileySkin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.SmileySkin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.SmileySkin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.SmileySkin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.SmileySkin);
        }
    }
    public void SkinColor4LightBlueSkin()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.Smiley2Skin)// BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.Smiley2Skin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.Smiley2Skin));
            //var allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
            //allboughts[4] = true;
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[4] = true;
            }
            else
            {
                allboughts[4] = true;
            }
            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.Smiley2Skin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.Smiley2Skin)// NOT ENOUGH BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.Smiley2Skin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.Smiley2Skin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.Smiley2Skin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.Smiley2Skin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.Smiley2Skin);
        }
    }
    public void SkinColor5GreenSkin()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.LightRedSkin)// BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightRedSkin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.LightRedSkin));
            //var allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
            //allboughts[5] = true;
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[5] = true;
            }
            else
            {
                allboughts[5] = true;
            }
            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.LightRedSkin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.LightRedSkin)// NOT ENOUGH BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightRedSkin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.LightRedSkin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightRedSkin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.LightRedSkin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.LightRedSkin);
        }
    }
    public void SkinColor6OrangeSkin()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.LightGreenSkin)// BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightGreenSkin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.LightGreenSkin));
            //var allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
            //allboughts[6] = true;
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[6] = true;
            }
            else
            {
                allboughts[6] = true;
            }
            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.LightGreenSkin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.LightGreenSkin)// NOT ENOUGH BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightGreenSkin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.LightGreenSkin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightGreenSkin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.LightGreenSkin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.LightGreenSkin);
        }
    }
    public void SkinColor7RedSkin()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.LightOrangeSkin)// BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightOrangeSkin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.LightOrangeSkin));
            //var allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
            //allboughts[7] = true;
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[7] = true;
            }
            else
            {
                allboughts[7] = true;
            }
            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.LightOrangeSkin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.LightOrangeSkin)// NOT ENOUGH BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightOrangeSkin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.LightOrangeSkin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.LightOrangeSkin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.LightOrangeSkin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.LightOrangeSkin);
        }
    }
    public void SkinColor8YellowSkin()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.BlackSkin)// BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.BlackSkin))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.BlackSkin));
            //var allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
            //allboughts[8] = true;
            bool[] allboughts = new bool[9];
            if (SaveGame.Exists("Boughts"))
            {
                allboughts = SaveGame.Load<bool[]>("Boughts", 0); // setting a internal variable so it doesnt overwrite existings boughts, just load them :)
                allboughts[8] = true;
            }
            else
            {
                allboughts[8] = true;
            }
            SaveGame.Save<bool[]>("Boughts", allboughts);
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.BlackSkin); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.BlackSkin)// NOT ENOUGH BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.BlackSkin)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.BlackSkin);
        }
        if (GetBackBought(Item.GetBoughtIndex(Item.ItemType.BlackSkin))) // ACTIVATE
        {
            SaveGame.Save<int>("Active", Item.GetBoughtIndex(Item.ItemType.BlackSkin));
            LoadItemStatsAndChange(false);
            ShowWindow("Activated ", Item.ItemType.BlackSkin);
        }
    }
    #endregion

    #region Side Functions
    private void ShowWindow(string text, Item.ItemType item)
    {
        TextItemInfo.GetComponent<Animator>().SetTrigger("Show");
        TextItemInfo.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = text + Item.GetName(item);
    }

    private bool GetBackBought(int whichSkinIndex)
    {
        if (SaveGame.Exists("Boughts"))
        {
            bool[] BoughtCheck = SaveGame.Load<bool[]>("Boughts");

            if (BoughtCheck[whichSkinIndex] == true)
            {
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    private void LoadItemStatsAndChange(bool loadStats)
    {
        bool[] boughts = new bool[9];

        if (SaveGame.Exists("Boughts"))
        {
            boughts = SaveGame.Load<bool[]>("Boughts");
        }
        else
        {
            boughts = Boughts;
        }
        for (int i = 0; i < ItemSkinColors.Count; i++)
        {
            if (loadStats)
            {
                ItemSkinColors[i].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = Item.GetCost(Item.GetLoad(i, false)).ToString();
                ItemSkinColors[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Item.GetName(Item.GetLoad(i, false)); // NAME OF ITEM
            }

            if (boughts[i] == true)
            {
                if (SaveGame.Load<int>("Active", 0) == i)
                {
                    ItemSkinColors[i].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "Active"; // TEXT FROM CURRENCY
                    ItemSkinColors[i].transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false); // DISABLE CURRENCY IMAGE
                }
                else
                {
                    ItemSkinColors[i].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "Bought"; // TEXT FROM CURRENCY
                    ItemSkinColors[i].transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false); // DISABLE CURRENCY IMAGE
                }
            }
        }
    }
    #endregion
}
