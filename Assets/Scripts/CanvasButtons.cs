using UnityEngine;

public class CanvasButtons : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    private void Start()
    {
        if (Time.timeScale == 0) Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    public void PauseMenuOpen()
    {
        if (!PauseMenu.activeSelf)
        {
            PauseMenu.SetActive(true);
            FindObjectOfType<Player_Controller>().isPaused = true;
            FindObjectOfType<Player_Controller>().transform.GetComponent<LineRenderer>().enabled = false;
            Time.timeScale = 0;
        }
    }
    public void PauseMenuClose()
    {
        if (PauseMenu.activeSelf)
        {
            Time.timeScale = FindObjectOfType<GameManager>().timescale;
            Invoke("ClosePauseMenu", .667f);
        }
    }
    private void ClosePauseMenu()
    {
        PauseMenu.SetActive(false);
        FindObjectOfType<Player_Controller>().isPaused = false;
        FindObjectOfType<Player_Controller>().transform.GetComponent<LineRenderer>().enabled = true;
    }
}
