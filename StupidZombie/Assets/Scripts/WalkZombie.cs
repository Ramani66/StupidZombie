using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkZombie : MonoBehaviour
{
    Animator a;
    float speed = 0.02f;
    int Score = 0;
    string dir = "ltr";
    public bool isWalk;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalk)
        {
            if (dir == "ltr")
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                a.SetBool("isWalk", true);
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            }
            if (dir == "rtl")
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                a.SetBool("isWalk", true);
                transform.position = new Vector2(transform.position.x - speed, transform.position.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "right-wall")
        {
            dir = "rtl";
        }
        if (c.gameObject.tag == "left-wall")
        {
            dir = "ltr";
        }
        if (c.gameObject.tag == "Bullet")
        {
            if (gameObject.tag != "ZombieDie")
            {
                Score = PlayerPrefs.GetInt("Score", 0);
                Score = Score + 100;
                PlayerPrefs.SetInt("Score", Score);
            }
            a.SetBool("isDead", true);
            dir = "dead";
            gameObject.tag = "ZombieDie";
        }
    }
}
