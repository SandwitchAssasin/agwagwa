using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EEE : MonoBehaviour
{
    public GameObject credits;
    public GameObject chooseLevel;
    public int diff;
    public void Statto(int diff_)
    {
        diff = diff_;
        Debug.Log(diff);
        SceneManager.LoadScene(1);
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
