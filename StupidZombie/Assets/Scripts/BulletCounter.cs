using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BulletCounter : MonoBehaviour
{
    public GameObject bullet, holder, gameover;
    public Text score_panel;
    int Bulletcnt = 0, levelNo = 0, zombiecnt, Score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Bulletcnt = PlayerPrefs.GetInt("Bulletcnt", 0);
        levelNo = PlayerPrefs.GetInt("levelNo", 1);
        PlayerPrefs.SetInt("Bulletcnt", Bulletcnt);
        for (int i = 0; i < Bulletcnt; i++)
        {
            GameObject g = Instantiate(bullet, holder.transform);
            g.tag = "temBullet";
        }
    }
    void destroy()
    {
        GameObject[] t = GameObject.FindGameObjectsWithTag("temBullet");
        Bulletcnt = PlayerPrefs.GetInt("Bulletcnt", 0);
        Destroy(t[Bulletcnt]);
    }
    public void reset()
    {
        gameover.SetActive(false);
        SceneManager.LoadScene("Play " + levelNo);
        Score = PlayerPrefs.GetInt("Score", 0);
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
    }
    void gameOveractive()
    {
        gameover.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        zombiecnt = PlayerPrefs.GetInt("zombiecnt", 1);
        Score = PlayerPrefs.GetInt("Score", 0);
        score_panel.text = Score.ToString();
        if (Bulletcnt > 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                destroy();
            }
        }
        else
        {
            if (zombiecnt > 0)
            {
                Invoke("gameOveractive", 4f);
            }
        }
    }
}
