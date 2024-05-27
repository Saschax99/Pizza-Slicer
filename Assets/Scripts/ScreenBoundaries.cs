using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenBoundaries : MonoBehaviour
{
    [HideInInspector] public Vector2 screenBounds;
    [HideInInspector] public float objectWidth;
    [HideInInspector] public float objectHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }
    void LateUpdate()
    {
        //Vector3 viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        //transform.position = viewPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!FindObjectOfType<Player_Controller>().playerDead && !setOff)
        {
            if (collision.gameObject.tag == "WallTop")
            {
                Camera.main.transform.GetComponent<Animator>().SetTrigger("Top");
            }
            if (collision.gameObject.tag == "WallBottom")
            {
                Camera.main.transform.GetComponent<Animator>().SetTrigger("Bottom");
            }
            if (collision.gameObject.tag == "WallLeft")
            {
                Camera.main.transform.GetComponent<Animator>().SetTrigger("Left");
            }
            if (collision.gameObject.tag == "WallRight")
            {
                Camera.main.transform.GetComponent<Animator>().SetTrigger("Right");
            }
        }
    }
    private float timer = 0;
    private float offset = .2f;
    [HideInInspector] public bool setOff = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TriggerReset")
        {
            timer = Time.time;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "TriggerReset" && timer != 0)
        {
            if (Time.time >= timer + offset)
            {
                setOff = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TriggerReset")
        {
            setOff = false;
        }
    }
}
