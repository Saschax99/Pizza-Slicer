using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class CanvasStart : MonoBehaviour
{
    [SerializeField] private GameObject SettingsWindow;
    [SerializeField] private GameObject ButtonCredits;

    #region Settings
    public void OpenSettings()
    {
        GameObject.Find("Canvas/HomeScreen/Button_Credits").GetComponent<Button>().interactable = false;
        SettingsWindow.SetActive(true);
    }
    public void CloseSettings()
    {
        Invoke("CloseSettingsTimer", .667f);
    }
    private void CloseSettingsTimer()
    {
        GameObject.Find("Canvas/HomeScreen/Button_Credits").GetComponent<Button>().interactable = true;
        SettingsWindow.SetActive(false);
    }

    public void SupportFriendYT()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCeanU7Hoyau0RdDC3RAfDGg");
    }
    public void SupportBTC()
    {
        Application.OpenURL("https://www.blockchain.com/btc/payment_request?address=1LaQABhjMmyduu7p1Twz7Wx3Ndsz83n3ae&amount=0.00029468");
    }

    #endregion

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Shop()
    {
        SceneManager.LoadScene(2);
    }
}
