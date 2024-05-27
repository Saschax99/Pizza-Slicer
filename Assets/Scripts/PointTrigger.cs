using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using BayatGames.SaveGameFree;

public class PointTrigger : MonoBehaviour
{
    [SerializeField] private List<Sprite> TargetSprites = new List<Sprite>();
    [SerializeField] private PhysicsMaterial2D Bouncy;

    GameManager gamemanager;

    private float objectWidthTrigger;
    private float objectHeightTrigger;

    private int movementState = 0;
    private bool targetDead = false;

    private float TargetScale;
    private int whichMove = 0;
    private float destroyAfterSec = 5f;
    private float destroyTimer;

    private bool executeOnce = false;
    private float offsetMotion = 1.1f;
    private bool alreadyMotion, executeOnceAnimator = false;

    private int TargetValue = 1;

    private int ObjectTargetIndex = 0;
    private int coinsMultiplier = 1;

    private float Scale;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();

        if (SaveGame.Exists("CoinsMultiplier"))
            coinsMultiplier = SaveGame.Load<int>("CoinsMultiplier", 1);
        else
            coinsMultiplier = 1;

        if (SaveGame.Exists("biggerTargets"))
            Scale = SaveGame.Load<float>("biggerTargets", .8f);
        else
            Scale = .8f;

        Scale = Scale * gamemanager.sizeTargetMultiplier;
        transform.localScale = new Vector3(Scale, Scale);

        destroyTimer = Time.time;

        TargetScale = transform.localScale.x; // get scale of target for increase decrease

        objectWidthTrigger = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeightTrigger = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2

        #region Which Mode Configurations
        if (gamemanager.Currency >= 10 && gamemanager.Currency < 20) // IF 10 - 20 wave
            movementState = 1;

        if (gamemanager.Currency >= 20 && gamemanager.Currency < 30) // IF 20 - 30 wave
            movementState = 2;
        if (gamemanager.Currency >= 30 && gamemanager.Currency < 40) // IF 30 - 40 wave
            movementState = 3;
        if (gamemanager.Currency >= 40 /*&& gamemanager.Currency < 40*/) // IF 30 - 40 wave
            movementState = 4;
        #endregion

        whichMove = Random.Range(0, 2);

        if (Random.Range(0, 11) == 10)
        {
            if (Random.Range(0, 4) == 3)
            {
                transform.GetComponent<Animator>().SetTrigger("Highlight50");
                TargetValue = 50;
                ObjectTargetIndex = 1;
            }
            else
            {
                transform.GetComponent<Animator>().SetTrigger("Highlight10");
                TargetValue = 10;
                ObjectTargetIndex = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ifPlayertCollected();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ifPlayertCollected();
        }
    }
    private void ifPlayertCollected()
    {
        if (!FindObjectOfType<Player_Controller>().playerDead)
        {
            transform.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            FindObjectOfType<DeathTimer>().ResetTimer();

            gamemanager.InstantiateTarget(false);


            if (ObjectTargetIndex == 1)
            {
                gamemanager.InstantiateParticle(gamemanager.particleDust, transform.position); // and POPUP
                gamemanager.Currency += (TargetValue * coinsMultiplier) * gamemanager.coinMultiplier;
            }
            else
            {
                gamemanager.InstantiateParticle(gamemanager.particleDust, transform.position); // and POPUP
                gamemanager.Currency += (TargetValue * coinsMultiplier) * gamemanager.coinMultiplier;
            }
            FindObjectOfType<Popup>().transform.GetComponent<TextMesh>().text = "+" + ((TargetValue * coinsMultiplier) * gamemanager.coinMultiplier).ToString();
            targetDead = true;
        }
    }

    private void Update()
    {
        if (targetDead)
        {
            if (transform.localScale.x < TargetScale * 1.5f)
                transform.localScale += new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Time.deltaTime * 3.5f;
            if (transform.localScale.x >= TargetScale * 1.5f)
                Destroy(transform.gameObject);
        }

        if (!FindObjectOfType<Player_Controller>().playerDead && !targetDead)
        {
            switch (movementState)
            {
                case 1:
                    if (!executeOnce)
                    {
                        CollideWithOthers(3, 1);
                        executeOnce = true;
                    }
                    break;
                case 2: // DO THIS OR THIS SLOW
                    if (whichMove == 0 && !executeOnce) // 0 to 1
                    {
                        CollideWithOthers(3, 1);
                        executeOnce = true;
                    }
                    else if(whichMove == 1)
                    {
                        alreadyMotion = true;
                        DecreaseSizeTarget();
                    }
                    break;
                case 3: // DO EVERYTHING BUT SLOW
                    if (!executeOnce)
                    {
                        CollideWithOthers(3, 1);
                        executeOnce = true;
                    }
                    alreadyMotion = true;
                    DecreaseSizeTarget();
                    break;
                case 4: // DO EVERYTHING FASTER
                    if (!executeOnce)
                    {
                        CollideWithOthers(10, 2.5f);
                        executeOnce = true;
                    }
                    alreadyMotion = true;
                    DecreaseSizeTarget();
                    break;
            }
            if (Time.time >= destroyTimer + destroyAfterSec / 2 && !executeOnceAnimator) // BLINK
            {
                transform.GetComponent<Animator>().SetTrigger("Blink");
                executeOnceAnimator = true;
            }
            if (Time.time >= destroyTimer + destroyAfterSec) // DESTROY
            {
                gamemanager.InstantiateTarget(false);
                gamemanager.InstantiateParticle(gamemanager.particleDidntPicked, transform.position); // and POPUP

                Destroy(transform.gameObject);
            }
            #region Motion
            transform.Rotate(new Vector3(0, 0, 55 * Time.deltaTime), Space.Self); // ROTATE TARGET
            if (!alreadyMotion)
            {
                if (decrease)
                    transform.localScale -= new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * (Time.deltaTime / 4);
                else if (increase)
                    transform.localScale += new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * (Time.deltaTime / 4);
                if (transform.localScale.x <= TargetScale / offsetMotion)
                {
                    decrease = false;
                    increase = true;
                }
                else if (transform.localScale.x >= TargetScale)
                {
                    decrease = true;
                    increase = false;
                }
            }
            #endregion
        }
    }
    private bool increase = false;
    private bool decrease = true;
    private void DecreaseSizeTarget()
    {
        if (decrease)
        {
            transform.localScale -= new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Time.deltaTime / 2;
        }
        else if (increase)
        {
            transform.localScale += new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * Time.deltaTime / 2;
        }
        if (transform.localScale.x <= TargetScale / 3.25f)
        {
            decrease = false;
            increase = true;
        }
        else if (transform.localScale.x >= TargetScale)
        {
            decrease = true;
            increase = false;
        }
    }
    //if (FindObjectOfType<ScreenBoundaries>().screenBounds.x * -1 + objectWidthTrigger >= transform.position.x) // LEFT SIDE
    //if (FindObjectOfType<ScreenBoundaries>().screenBounds.x - objectWidthTrigger <= transform.position.x) // RIGHT SIDE
    //if (FindObjectOfType<ScreenBoundaries>().screenBounds.y * -1 + objectHeightTrigger >= transform.position.y)
    //if (FindObjectOfType<ScreenBoundaries>().screenBounds.y - objectHeightTrigger <= transform.position.y)
    #region Collide with others
    private void CollideWithOthers(float MovementSpeedX, float MovementSpeedY)
    {
        this.transform.GetComponent<CircleCollider2D>().isTrigger = false;
        this.transform.gameObject.AddComponent<Rigidbody2D>();
        var rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        //rb2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        //rb2d.sharedMaterial = Bouncy;
        this.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-MovementSpeedX, MovementSpeedX), Random.Range(-MovementSpeedY, MovementSpeedY)), ForceMode2D.Impulse);
    }
    #endregion
}
