using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EEE : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject chooseLevel;
    public AudioSource aS;
    public AudioClip[] ac;
    public int diff;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //when getting back destroy this;
    }
    public void Statto(int diff_)
    {
        diff = diff_;
        Debug.Log(diff);
        SceneManager.LoadScene(1);
        aS.clip = ac[diff + 1];
        aS.Play();
        mainMenu.SetActive(false);
        chooseLevel.SetActive(false);
        //starts gaem
    }
    public void Choose()
    {
        chooseLevel.SetActive(true);
    }
    public void ChooseQuit()
    {
        chooseLevel.SetActive(false);
    }
    public void CSTART()
    {
        credits.SetActive(true);
    }
    public void CQUIT()
    {
        credits.SetActive(false);
    }
}
