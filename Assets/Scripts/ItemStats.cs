using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class ItemStats : MonoBehaviour // ÖFTER KLICKEN AUF DIE ITEMS WENN MAX DANN ALREADY MAX BOUGHT DING USW.
{
    //private bool[] Boughts = new bool[2]; // LAST IS EXCLUSIVE
    private int[] StacksBoughts = new int[3]; // LAST IS EXCLUSIVE

    [SerializeField] private List<GameObject> ItemStatsList = new List<GameObject>();

    private GameObject TextItemInfo;

    private void Start()
    {
        TextItemInfo = GameObject.Find("Canvas/TextItemInfo");

        if (SaveGame.Exists("Stacks"))
        {
            StacksBoughts = SaveGame.Load<int[]>("Stacks", 0);
        }
        else
        {
            StacksBoughts[0] = 0;
            StacksBoughts[1] = 0;
            StacksBoughts[2] = 0;
            Debug.Log("Not Existing");
        }

        LoadItemStatsAndChange(true); // LOADING STATS OF ITEMS
    }
    #region Items
    public void ItemStats0Size()
    {
        var price = Item.GetCost(Item.ItemType.Size) * Item.GetBuyMultiplier(StacksBoughts[0]);

        if (SaveGame.Load<int>("CoinsAmount", 0) >= (int)price && StacksBoughts[0] < Item.GetMaxStack(Item.ItemType.Size)) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - (int)price);
            StacksBoughts[0]++;
            SaveGame.Save<int[]>("Stacks", StacksBoughts);
            LoadItemStatsAndChange(true);
            ShowWindow("Successfully Bought ", Item.ItemType.Size); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < (int)price && StacksBoughts[0] < Item.GetMaxStack(Item.ItemType.Size))
        {
            TextItemInfo.GetComponent<Animator>().SetTrigger("Show");
            ShowWindow("Not enough balance for ", Item.ItemType.Size);
        }
    }
    public void ItemStats1Velocity()
    {
        var price = Item.GetCost(Item.ItemType.Velocity) * Item.GetBuyMultiplier(StacksBoughts[1]);

        if (SaveGame.Load<int>("CoinsAmount", 0) >= (int)price && StacksBoughts[1] < Item.GetMaxStack(Item.ItemType.Velocity)) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - (int)price);
            StacksBoughts[1]++;
            SaveGame.Save<int[]>("Stacks", StacksBoughts);
            LoadItemStatsAndChange(true);
            ShowWindow("Successfully Bought ", Item.ItemType.Velocity); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < (int)price && StacksBoughts[1] < Item.GetMaxStack(Item.ItemType.Velocity))
        {
            TextItemInfo.GetComponent<Animator>().SetTrigger("Show");
            ShowWindow("Not enough balance for ", Item.ItemType.Velocity);
        }
    }

    public void ItemStats2DeathTimer()
    {
        var price = Item.GetCost(Item.ItemType.Velocity) * Item.GetBuyMultiplier(StacksBoughts[2]);

        if (SaveGame.Load<int>("CoinsAmount", 0) >= (int)price && StacksBoughts[2] < Item.GetMaxStack(Item.ItemType.DeathTimer)) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - (int)price);
            StacksBoughts[2]++;
            SaveGame.Save<int[]>("Stacks", StacksBoughts);
            LoadItemStatsAndChange(true);
            ShowWindow("Successfully Bought ", Item.ItemType.DeathTimer); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < (int)price && StacksBoughts[2] < Item.GetMaxStack(Item.ItemType.DeathTimer))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.DeathTimer);
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
        int[] stacks = new int[3]; // 3 ZAHLEN

        if (SaveGame.Exists("Stacks"))
        {
            stacks = SaveGame.Load<int[]>("Stacks", 0);
        }
        else
        {
            stacks = StacksBoughts;
        }
        for (int i = 0; i < ItemStatsList.Count; i++) // wieder 3
        {
            if (loadStats)
            {
                ItemStatsList[i].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = (Item.GetCost(Item.GetLoad(i, true)) * Item.GetBuyMultiplier(stacks[i])).ToString(); // CHANGED STACKS FROM SATACKBOUGHTS
                ItemStatsList[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Item.GetName(Item.GetLoad(i, true)); // NAME OF ITEM
            }
            if (stacks[i] == Item.GetMaxStack(Item.GetLoad(i, true)))
            {
                ItemStatsList[i].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "Max"; // TEXT FROM CURRENCY
                ItemStatsList[i].transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false); // DISABLE CURRENCY IMAGE
            }
            ItemStatsList[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>().text = stacks[i] + " of " + Item.GetMaxStack(Item.GetLoad(i,true)).ToString();
            float sideValue = (float)stacks[i] / (float)Item.GetMaxStack(Item.GetLoad(i, true));
            ItemStatsList[i].transform.GetChild(1).GetChild(0).GetComponent<Slider>().value = sideValue;
        }
    }
    #endregion
}
