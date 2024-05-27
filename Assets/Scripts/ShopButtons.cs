using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void BackToStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
