using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    public GameObject card;
    public Card[] cardos;
    public int cardCount;
    public float money;
    public TextMeshProUGUI moneyText;
    public List<int> esk;
    void Awake()
    {
        money = 100;
        DontDestroyOnLoad(this.gameObject);
        //when getting back destroy this;
    }
    public IEnumerator ah()
    {
        yield return new WaitForSeconds(0.1f);
        enem = GameObject.Find("enmemuy");
        Debug.Log(enem);
        enem.GetComponent<SpriteRenderer>().sprite = sprites[diff];
        for (int i = 0; i < 10; i++)
        {
            Draw();
        }
    }
    public void Draw()
    {
        if (cardCount <= 5)
        {
            cardCount += 1;
            GameObject gus = Instantiate(card, transform.position, Quaternion.identity);
            gus.GetComponent<CardDisplay>().card = cardos[Random.Range(0, cardos.Length)];
            if (esk.Count == 0)
            {
                gus.GetComponent<CardDisplay>().cont = cardCount;
            }
            else
            {
                gus.GetComponent<CardDisplay>().cont = esk[0];
                esk.Remove(esk[0]);
            }
            gus.transform.parent = gameObject.transform;
        }
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
        moneyText.gameObject.SetActive(true);
    }
    void Update()
    {
        moneyText.text = "MONEY: " + money.ToString();
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
