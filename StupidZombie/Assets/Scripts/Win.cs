using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject holder, star;
    int levelNo = 0, Bulletcnt = 0, curlevel = 0;
    int[] levelBullet = { 3, 4 };
    // Start is called before the first frame update
    void Start()
    {
        levelNo = PlayerPrefs.GetInt("levelNo", 1);
        curlevel = levelBullet[levelNo - 1];
        Bulletcnt = PlayerPrefs.GetInt("Bulletcnt", 0);
        if ((Bulletcnt) == (curlevel - 1))
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(star, holder.transform);
            }
        }
        else if ((Bulletcnt) == (curlevel - 2))
        {
            for (int i = 0; i < 2; i++)
            {
                Instantiate(star, holder.transform);
            }
        }
        else
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(star, holder.transform);
            }
        }
    }
    public void next()
    {
         levelNo++;
         PlayerPrefs.SetInt("levelNo", levelNo);
         SceneManager.LoadScene("Play " + levelNo);
    }
    public void home()
    {
        SceneManager.LoadScene("Home");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
