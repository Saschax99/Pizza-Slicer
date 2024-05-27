using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class CanvasPause : MonoBehaviour
{
    [SerializeField] private bool deadWindow;

    [SerializeField] private Text ReviveCosts;

    private void Update()
    {
        if (deadWindow)
        {
            if (transform.GetChild(1).GetChild(3).GetComponent<Text>().text != FindObjectOfType<GameManager>().Currency.ToString("0"))
            {
                transform.GetChild(1).GetChild(3).GetComponent<Text>().text = FindObjectOfType<GameManager>().Currency.ToString("0");
            }
        }
    }

    private void OnEnable()
    {
        if (deadWindow)
        {
            ReviveCosts.text = (SaveGame.Load<int>("CoinsAmount") * .25).ToString("0");
        }
    }

    public void Revive()
    {
        if (SaveGame.Exists("CoinsAmount") && SaveGame.Load<int>("CoinsAmount", 0) > 0)
        {
            var tenperc = SaveGame.Load<int>("CoinsAmount") * .25; // get 25% of wallet
            SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) - (int)tenperc);
        }
        FindObjectOfType<DeathTimer>().ReviveStates();
    }
    public void RestartGame()
    {
        SaveCoins();
        SceneManager.LoadScene(1);
    }
    public void Shop()
    {
        SaveCoins();
        SceneManager.LoadScene(2);

    }
    public void Quit()
    {
        SaveCoins();
        SceneManager.LoadScene(0);
    }

    private void SaveCoins()
    {
        Debug.Log(FindObjectOfType<GameManager>().Currency);
        Debug.Log(SaveGame.Load<int>("CoinsAmount", 0));
        SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) + FindObjectOfType<GameManager>().Currency);
        Debug.Log(SaveGame.Load<int>("CoinsAmount", 0));
    }
}