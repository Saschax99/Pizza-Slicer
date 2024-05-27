using UnityEngine;
using BayatGames.SaveGameFree;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;

    [HideInInspector] public bool playerDead = false;
    [HideInInspector] public bool isPaused = false;

    [SerializeField] private float moveSpeed;
    [SerializeField] Vector2 minPower;
    [SerializeField] Vector2 maxPower;
    private LineRenderer linerenderer;
    Vector2 PlayerForce;
    Vector3 startpoint;
    Vector3 endpoint;

    private ItemAssets itemAssets;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        linerenderer = GetComponent<LineRenderer>();
        itemAssets = FindObjectOfType<ItemAssets>();
    }

    private void ItemsLoad()
    {
        // SPRITE SKIN
        if (SaveGame.Exists("Active"))
            transform.GetComponent<SpriteRenderer>().sprite = itemAssets.SkinColors[SaveGame.Load<int>("Active", 0)];
        else
            transform.GetComponent<SpriteRenderer>().sprite = itemAssets.SkinColors[0];
        // SIZE
        float scaleOneSided;
        if (SaveGame.Exists("Stacks"))
            scaleOneSided = Item.GetScale(SaveGame.Load<int>("Stacks", 0));
        else
            scaleOneSided = Item.GetScale(0);

        transform.localScale = new Vector3(scaleOneSided, scaleOneSided, scaleOneSided);
        // VELOCITY
        if (SaveGame.Exists("Stacks"))
            moveSpeed = moveSpeed + Item.GetVelocity(SaveGame.Load<int>("Stacks", 0));
        else
            moveSpeed = moveSpeed + Item.GetVelocity(0);
    }

    private void Start()
    {
        ItemsLoad();
    }

    private void Update()
    {
        if (!playerDead && !isPaused)
        {
            #region Pull Controls

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                FirstPressStartPoint();
            }
            if (Input.GetMouseButton(0))
            {
                Draging();
            }
            if (Input.GetMouseButtonUp(0))
            {
                ReleaseButton();
            }
#elif UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    FirstPressStartPoint();
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    Draging();
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    ReleaseButton();
                }
            }
#endif
        }
    }
    private void FirstPressStartPoint()
    {
        startpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startpoint.z = 15;
    }
    private void Draging()
    {
        Vector3 currentpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentpoint.z = 15;
        drawLine(startpoint, currentpoint);
    }
    private void ReleaseButton()
    {
        endpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        endpoint.z = 15;

        PlayerForce = new Vector2(Mathf.Clamp(startpoint.x - endpoint.x, minPower.x, maxPower.x), Mathf.Clamp(startpoint.y - endpoint.y, minPower.y, maxPower.y));
        rb.AddForce(PlayerForce * moveSpeed, ForceMode2D.Impulse);
        endLine();
    }
    private void drawLine(Vector3 startpoint, Vector3 endpoint)
    {
        linerenderer.positionCount = 2;
        Vector3[] allpoint = new Vector3[2];
        allpoint[0] = startpoint;
        allpoint[1] = endpoint;
        linerenderer.SetPositions(allpoint);
    }
    private void endLine()
    {
        linerenderer.positionCount = 0;
    }
    #endregion
}