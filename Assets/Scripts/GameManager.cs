using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int Currency = 0;
    [SerializeField] private GameObject Target;
    public GameObject particleDust, particleDidntPicked;
    [SerializeField] private GameObject TextCurrency;
    [SerializeField] private GameObject UsableEffectTarget;
    private Vector2 screenbounds;
    float objectwidth, objectheight;

    [SerializeField] private Gradient particleColorGradient;
    [HideInInspector] public Color nextColor;

    private float MinSpawnrate_PickupUsable = 15f;
    private float MaxSpawnrate_PickupUsable = 30f;
    private float timeToSpawnUsable;

    public float timescale = 1;
    public float sizeTargetMultiplier = 1;
    public int coinMultiplier = 1;

    private float resetTimerEffects = 7.5f;

    public GameObject UItimerUsable;
    public bool startTimerUsable = false;
    private float deathTimer;

    private void Start()
    {
        screenbounds = FindObjectOfType<ScreenBoundaries>().screenBounds;
        objectwidth = FindObjectOfType<ScreenBoundaries>().objectWidth;
        objectheight = FindObjectOfType<ScreenBoundaries>().objectHeight;

        InstantiateTarget(true); // MAYBE LATER INSTANTIATE NOT DIRECTLY ON PLAYER

        timeToSpawnUsable = SetRandomValue(MinSpawnrate_PickupUsable, MaxSpawnrate_PickupUsable);
    }
    private void Update()
    {
        if (TextCurrency.GetComponent<Text>().text != Currency.ToString())
        {
            TextCurrency.GetComponent<Text>().text = Currency.ToString();
        }

        if (!FindObjectOfType<Player_Controller>().playerDead)
        {
            if (Time.time >= timeToSpawnUsable)
            {
                Debug.Log("SpawnUsable");
                Vector3 randomPos = new Vector3(Random.Range(screenbounds.x * -1 + objectwidth, screenbounds.x - objectwidth),
                Random.Range(screenbounds.y * -1 + objectheight, screenbounds.y - objectheight), 0);

                Instantiate(UsableEffectTarget, randomPos, Quaternion.identity);
                timeToSpawnUsable = Time.time + SetRandomValue(MinSpawnrate_PickupUsable, MaxSpawnrate_PickupUsable);
                deathTimer = resetTimerEffects; // resetting deathtimer
            }
            if (startTimerUsable)
            {
                deathTimer -= Time.unscaledDeltaTime;
                UItimerUsable.GetComponent<Image>().fillAmount = deathTimer / resetTimerEffects;
            }
        }
    }

    private float SetRandomValue(float min, float max)
    {
        return Random.Range(min, max);
    }

    public void InstantiateTarget(bool onStart)
    {
        if (!onStart)
        {
            Vector3 randomPos = new Vector3(Random.Range(screenbounds.x * -1 + objectwidth, screenbounds.x - objectwidth),
                Random.Range(screenbounds.y * -1 + objectheight, screenbounds.y - objectheight), 0);
            Instantiate(Target, randomPos, Quaternion.identity);
        }
        else if(onStart)
        {
            Vector3 randomPos = new Vector3(Random.Range(screenbounds.x * -1 + objectwidth, screenbounds.x - objectwidth),
                Random.Range(2, screenbounds.y - objectheight), 0);
            Instantiate(Target, randomPos, Quaternion.identity);
        }
    }
    public void InstantiateParticle(GameObject particleGameobject, Vector3 transformPos)
    {
        Instantiate(particleGameobject, transformPos, Quaternion.identity);
    }

    private void OnApplicationQuit()
    {
        Debug.Log(Currency);
        Debug.Log(SaveGame.Load<int>("CoinsAmount", 0));
        SaveGame.Save<int>("CoinsAmount", SaveGame.Load<int>("CoinsAmount", 0) + Currency);
        Debug.Log(SaveGame.Load<int>("CoinsAmount", 0));
    }

    public void Effect(Item.ItemType itemtype)
    {
        switch (itemtype)
        {
            case Item.ItemType.Usable_DecreaseTime:
                timescale = .333f;
                Time.timeScale = timescale;
                Debug.Log(timescale + " decrease");
                StartCoroutine(decreasetime(0));
                break;
            case Item.ItemType.Usable_BiggerTargets:
                sizeTargetMultiplier = 1.5f;
                StartCoroutine(decreasetime(1));
                break;
            case Item.ItemType.Usable_x2Coins:
                coinMultiplier = 2;
                StartCoroutine(decreasetime(2));
                break;
            case Item.ItemType.Usable_IncreaseTime:
                timescale = 2f;
                Time.timeScale = timescale;
                Debug.Log(timescale + " increase");
                StartCoroutine(decreasetime(3));
                break;
            case Item.ItemType.Usable_SmallerTargets:
                sizeTargetMultiplier = .5f;
                StartCoroutine(decreasetime(4));
                break;
            default:
                break;
        }
    }
    IEnumerator decreasetime(int whichEffect)
    {
        yield return new WaitForSecondsRealtime(resetTimerEffects);

        switch (whichEffect)
        {
            case 0:
                timescale = 1;
                Time.timeScale = timescale;
                break;
            case 1:
                sizeTargetMultiplier = 1;
                break;
            case 2:
                coinMultiplier = 1;
                break;
            case 3:
                timescale = 1;
                Time.timeScale = timescale;
                break;
            case 4:
                sizeTargetMultiplier = 1;
                break;
        }

        UItimerUsable.SetActive(false);
        startTimerUsable = false;

    }
}
