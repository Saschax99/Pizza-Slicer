using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class ItemUsables : MonoBehaviour // ÖFTER KLICKEN AUF DIE ITEMS WENN MAX DANN ALREADY MAX BOUGHT DING USW.
{
    private bool[] UsableBoughts = new bool[2]; // LAST IS EXCLUSIVE
    [SerializeField] private List<GameObject> ItemUsablesList = new List<GameObject>();
    private GameObject TextItemInfo;

    private void Start()
    {
        TextItemInfo = GameObject.Find("Canvas/TextItemInfo");
        LoadItemStatsAndChange(true); // LOADING STATS OF ITEMS
    }
    #region Items
    public void ItemUsables02xMultiplier()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.TwoXmultiplier) // BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.TwoXmultiplier))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.TwoXmultiplier));
            bool[] allboughts = new bool[2];
            allboughts[0] = true;
            SaveGame.Save<bool[]>("usableBoughts", allboughts);
            SaveGame.Save<int>("CoinsMultiplier", 2); // FUNKTION
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.TwoXmultiplier); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.TwoXmultiplier)// NOT ENOUGHT BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.TwoXmultiplier)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.TwoXmultiplier);
        }
    }
    public void ItemUsables1BiggerTargets()
    {
        if (SaveGame.Load<int>("CoinsAmount", 0) >= Item.GetCost(Item.ItemType.BiggerTargets) // BUY
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.BiggerTargets))) // If not already bought
        {
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - Item.GetCost(Item.ItemType.BiggerTargets));
            bool[] allboughts = new bool[2];
            allboughts[1] = true;
            SaveGame.Save<bool[]>("usableBoughts", allboughts);
            SaveGame.Save<float>("biggerTargets", 1.1f); // FUNKTION
            LoadItemStatsAndChange(false);
            ShowWindow("Successfully Bought ", Item.ItemType.BiggerTargets); // WINDOW
        }
        else if (SaveGame.Load<int>("CoinsAmount", 0) < Item.GetCost(Item.ItemType.BiggerTargets)// NOT ENOUGHT BALANCE
            && !GetBackBought(Item.GetBoughtIndex(Item.ItemType.BiggerTargets)))
        {
            ShowWindow("Not enough balance for ", Item.ItemType.BiggerTargets);
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
        if (SaveGame.Exists("usableBoughts"))
        {
            bool[] BoughtCheck = SaveGame.Load<bool[]>("usableBoughts");

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
        bool[] usableboughts = new bool[2];

        if (SaveGame.Exists("usableBoughts"))
        {
            usableboughts = SaveGame.Load<bool[]>("usableBoughts", 0);
        }
        else
        {
            usableboughts = UsableBoughts;
        }

        for (int i = 0; i < ItemUsablesList.Count; i++)
        {
            if (loadStats)
            {
                ItemUsablesList[i].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = Item.GetCost(Item.GetLoad(i, false, true)).ToString();
                ItemUsablesList[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Item.GetName(Item.GetLoad(i, false, true)); // NAME OF ITEM
            }

            if (usableboughts[i] == true)
            {
                ItemUsablesList[i].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = "Bought"; // TEXT FROM CURRENCY
                ItemUsablesList[i].transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false); // DISABLE CURRENCY IMAGE
            }
        }
    }
    #endregion
}