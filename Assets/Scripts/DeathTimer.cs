using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class DeathTimer : MonoBehaviour
{
    private float deathTimer;
    private float deathTimerMax = 6;

    [SerializeField] private GameObject TimeBar;
    [SerializeField] private GameObject WindowDead;

    private void Start()
    {
        if (SaveGame.Exists("Stacks"))
            deathTimer = deathTimerMax + Item.GetDeathTimer(SaveGame.Load<int>("Stacks", 0)); // LOADING ITEM STAT
        else
            deathTimer = deathTimerMax + Item.GetDeathTimer(0);

        WindowDead.SetActive(false);
        TimeBar.transform.GetChild(0).GetComponent<Image>().fillAmount = 1;
    }
    private void Update()
    {
        deathTimer -= Time.deltaTime; // COUNTING DOWN

        TimeBar.transform.GetChild(0).GetComponent<Image>().fillAmount = deathTimer / deathTimerMax;

        if (deathTimer <= 0) // IF DEATH
        {
            FindObjectOfType<Player_Controller>().playerDead = true;
            FindObjectOfType<Player_Controller>().GetComponent<LineRenderer>().enabled = false;
            WindowDead.SetActive(true);
        }
    }

    public void ReviveStates()
    {
        if (SaveGame.Exists("Stacks")) // ITEM STACK
            deathTimer = deathTimerMax + Item.GetDeathTimer(SaveGame.Load<int>("Stacks", 0));
        else
            deathTimer = deathTimerMax;

        WindowDead.SetActive(false);
        FindObjectOfType<Player_Controller>().playerDead = false;
        FindObjectOfType<Player_Controller>().GetComponent<LineRenderer>().enabled = true;
        FindObjectOfType<GameManager>().InstantiateParticle(FindObjectOfType<GameManager>().particleDidntPicked, FindObjectOfType<Player_Controller>().transform.position);
    }

    public void ResetTimer()
    {
        deathTimer = deathTimerMax;
    }
}
