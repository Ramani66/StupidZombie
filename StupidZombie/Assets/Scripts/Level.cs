using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void levelselect(int n)
    {
        PlayerPrefs.SetInt("levelNo", n);
        SceneManager.LoadScene("Play " + n);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
