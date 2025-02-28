using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour
{
    public GameObject bullet, gunPoint;
    AudioSource a;
    LineRenderer line;
    public AudioClip c;
    int[] levelBullet = { 3, 4 };
    int Bulletcnt = 0, levelNo = 0, zombiecnt, Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();
        line = GetComponent<LineRenderer>();
        levelNo = PlayerPrefs.GetInt("levelNo", 1);
        Bulletcnt = levelBullet[levelNo - 1];
        PlayerPrefs.SetInt("Bulletcnt", Bulletcnt);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 gunPos = transform.position;
        line.SetPosition(0, gunPoint.transform.position);
        line.SetPosition(1, mousePos);
        Vector2 offset = new Vector2(mousePos.x - gunPos.x, mousePos.y - gunPos.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Bulletcnt > 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                a.clip = c;
                a.Play();
                fireBullet();
                Bulletcnt = PlayerPrefs.GetInt("Bulletcnt", 0);
                Bulletcnt--;
                PlayerPrefs.SetInt("Bulletcnt", Bulletcnt);
            }
        }
        zombiecnt = GameObject.FindGameObjectsWithTag("Zombie").Length;
        PlayerPrefs.SetInt("zombiecnt", zombiecnt);
        if (zombiecnt == 0)
        {
            Invoke("win", 3f);
        }
    }
    void win()
    {
        SceneManager.LoadScene("Win");
        Score = PlayerPrefs.GetInt("Score", 0);
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
    }
    void fireBullet()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gunPoint.transform.position).normalized;
        GameObject b = Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody2D>().AddForce(dir * 1500);
        Destroy(b, 3f);
    }
}
