using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUsables : MonoBehaviour
{
    [SerializeField] private PhysicsMaterial2D Bouncy;

    private float ObjectUsableIndex;
    GameManager gamemanager;

    private float TargetScale;
    private int TargetValue = 1;
    private float offsetMotion = 1.1f;
    private float destroyAfterSec = 5f;
    private float destroyTimer;
    private bool executeOnce = false;
    private bool alreadyMotion, executeOnceAnimator = false;

    public int WhatEffect;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();

        TargetScale = transform.localScale.x; // get scale of target for increase decrease

        WhatEffect = Random.Range(0, 5);

        transform.GetComponent<Animator>().SetTrigger("Highlight50");

        TimeTime = Time.time / Time.time; // Resetting the timer
    }
    private float TimeTime;
    private void Update()
    {
        if (TimeTime >= destroyTimer + destroyAfterSec / 2 && !executeOnceAnimator) // BLINK
        {
            transform.GetComponent<Animator>().SetTrigger("Blink");
            executeOnceAnimator = true;
        }
        if (TimeTime >= destroyTimer + destroyAfterSec) // DESTROY
        {
            Destroy(transform.gameObject);
            gamemanager.InstantiateParticle(gamemanager.particleDidntPicked, transform.position); // and POPUP
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

    private bool increase = false;
    private bool decrease = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            ifPlayertCollected();
    }

    private void ifPlayertCollected()
    {
        if (!FindObjectOfType<Player_Controller>().playerDead)
        {
            gamemanager.Effect(Item.GetUsableState(WhatEffect));
            Destroy(transform.gameObject);
            gamemanager.InstantiateParticle(gamemanager.particleDust, transform.position); // and POPUP

            var Info = GameObject.Find("Canvas/TextUsableInfo").GetComponent<Animator>();
            Info.SetTrigger("Show");
            Info.GetComponent<Text>().text = Item.GetName(Item.GetUsableState(WhatEffect));

            gamemanager.UItimerUsable.SetActive(true);
            gamemanager.startTimerUsable = true;
        }
    }
}
