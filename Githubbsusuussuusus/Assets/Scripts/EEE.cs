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
    GameObject enem;
    public Sprite[] sprites;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //when getting back destroy this;
    }
    public IEnumerator ah()
    {
        yield return new WaitForSeconds(0.1f);
        enem = GameObject.Find("enmemuy");
        Debug.Log(enem);
        enem.GetComponent<SpriteRenderer>().sprite = sprites[diff];
    }
    public void Statto(int diff_)
    {
        diff = diff_;
        SceneManager.LoadScene(1);
        aS.clip = ac[diff + 1];
        aS.Play();
        mainMenu.SetActive(false);
        chooseLevel.SetActive(false);
        StartCoroutine("ah");
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
