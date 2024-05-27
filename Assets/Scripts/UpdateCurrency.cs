using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class UpdateCurrency : MonoBehaviour
{
    [SerializeField] private Text TextCurrency;
    private void Update()
    {
        if (TextCurrency.text != SaveGame.Load<int>("CoinsAmount", 0).ToString())
        {
            TextCurrency.text = SaveGame.Load<int>("CoinsAmount", 0).ToString();
        }
    }
}
