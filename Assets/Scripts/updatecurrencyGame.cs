using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class updatecurrencyGame : MonoBehaviour
{
    [SerializeField] private Text TextCurrency;
    private void OnEnable()
    {
        if (TextCurrency.text != SaveGame.Load<int>("CoinsAmount", 0).ToString())
        {
            TextCurrency.text = SaveGame.Load<int>("CoinsAmount", 0).ToString();
        }
    }
}
