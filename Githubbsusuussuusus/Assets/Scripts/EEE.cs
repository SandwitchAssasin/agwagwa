using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EEE : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject MUSpanell;
    public GameObject chooseLevel;
    public AudioSource aS;
    public AudioSource aSFX;
    public AudioClip amx;
    public AudioClip amsx;
    public AudioClip[] ac;
    public int diff;
    GameObject enem;
    public Sprite[] sprites;
    public GameObject card;
    public List<Card> cardos;
    public List<Card> enemyDeck;
    public List<Card> enemyHand;
    public List<Card> enemyHandheCanUSE;
    public int cardCount;
    public float money;
    public float enemyMoney;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI EmoneyText;
    public TextMeshProUGUI drawTimeText;
    public TextMeshProUGUI EdrawTimeText;
    public TextMeshProUGUI EhandCountText;
    public List<int> esk;
    public float aaah = 0;
     public float Eaaah = 0;
    float Timef = 0;
    public Color colour;
    public Color UNcolour;
    public Color UNNNNcolour;
    int heh = 0;
    int ps = 0;
    int p = 1;
    int dc = 0;
    bool ak = false;
    public TextMeshProUGUI[] HinaSpin;//M-1 Grand Prix reference!!!!!!1!
    public TextMeshProUGUI HinaMOMENTO;
    public string[] info;
    public AudioClip[] aC;
    public AudioSource sus;
    public float DrawTime;
    public float EDrawTime;
    bool bv = false;
    public int moneyLimit;
    public GameObject winPanel;
    public GameObject losePanel;
    bool bgn = false;
    public List<Card> playerDecks1;
    public List<Card> playerDecks2;
    public List<Card> playerDecks3;
    public List<Card> playerDecks4;
    public List<Card> enemyDecks1;
    public List<Card> enemyDecks2;
    public List<Card> enemyDecks3;
    public List<Card> enemyDecks4;
    public Slider audioSlider;
    void Awake()
    {
        money = 100;
        enemyMoney = 100;
        //when getting back destroy this;
        Debug.Log(GameObject.FindGameObjectsWithTag("Cansus"));
        foreach (GameObject cux in GameObject.FindGameObjectsWithTag("Cansus"))
        {
            if (cux != this.gameObject && !bgn)
            {
                cux.GetComponent<EEE>().gwagwa();
            }
        }
        DontDestroyOnLoad(this.gameObject);
        bgn = true;
    }
    public void gwagwa()
    {
        money = 100;
        enemyMoney = 100;
        StartCoroutine("ghgh");
        Debug.Log("anxietyyy");
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        mainMenu.SetActive(true);
        sus.clip = aC[0];
        sus.Play();
        moneyText.gameObject.SetActive(false);
        EmoneyText.gameObject.SetActive(false);
        drawTimeText.gameObject.SetActive(false);
        EdrawTimeText.gameObject.SetActive(false);
        EhandCountText.gameObject.SetActive(false);
        bv = false;
        enemyHand.Clear();
        enemyHandheCanUSE.Clear();
    }
    public IEnumerator ghgh()
    {
        Debug.Log("aaa");
        for (int i = 0; i < 600; i++)
        {
            Debug.Log(80 * 564 ^ 3);
        }
        StartCoroutine("del");
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator ah()
    {
        Time.timeScale = 1;
        Debug.Log("aaadsdsd");
        yield return new WaitForSeconds(0.1f);
        enem = GameObject.Find("enmemuy");
        Debug.Log(enem);
        Debug.Log("aaadsdsd");
        enem.GetComponent<SpriteRenderer>().sprite = sprites[diff];
        for (int i = 0; i < 3; i++)
        {
            Draw();
            EDraw();
        }
    }
    public void BackFromMusic()
    {
        MUSpanell.SetActive(false);
        ak = false;
        if (heh != 0)
        {
            for (int i = 0; i < 5; i++) // zmien na 6
            {
                HinaSpin[i].color = UNcolour;
                if (HinaSpin[i].fontStyle == FontStyles.Bold)
                {
                    HinaSpin[i].fontStyle ^= FontStyles.Bold;
                }
            }
            p = 0;
            dc = 0;
            if (ps != 0)
            {
                sus.clip = aC[0];
                sus.Play();
            }
        }
        if (ps != 0 && heh == 0)
        {
            sus.clip = aC[0];
            sus.Play();
        }
        for (int i = 0; i < 5; i++) // tu tez
        {
            HinaSpin[i].color = UNcolour;
            if (HinaSpin[i].fontStyle == FontStyles.Bold)
            {
                HinaSpin[i].fontStyle ^= FontStyles.Bold;
            }
        }
        heh = 0;
        ps = 0;
    }
    public void Playo(bool a)
    {
        if (a = true)
        {
            aSFX.clip = amx;
            aSFX.Play();
        }
        else
        {
            aSFX.clip = amsx;
            aSFX.Play();
        }
    }
    public void EDraw()
    {
        if (enemyHand.Count <= 5)
        {
            enemyHand.Add(enemyDeck[Random.Range(0, enemyDeck.Count)]);
        }
    }
    public void Draw()
    {
        if (cardCount <= 5)
        {
            cardCount += 1;
            GameObject gus = Instantiate(card, transform.position, Quaternion.identity);
            gus.GetComponent<CardDisplay>().card = cardos[Random.Range(0, cardos.Count)];
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
    public void Music()
    {
        MUSpanell.SetActive(true);
        ak = true;
        p = 1;
        HinaSpin[ps].color = UNcolour;
        HinaSpin[ps].fontStyle ^= FontStyles.Bold;
        ps = heh;
        HinaSpin[heh].color = colour;
        HinaSpin[heh].fontStyle = FontStyles.Bold;
        sus.clip = aC[heh];
    }
    public void Statto(int diff_)
    {
        diff = diff_;
        SceneManager.LoadScene(1);
        aS.clip = ac[diff + 1];
        aS.Play();
        mainMenu.SetActive(false);
        chooseLevel.SetActive(false);
        cardCount = 0;
        bv = true;
        StartCoroutine("ah");
        if (diff == 0)
        {
            cardos = playerDecks1;
            enemyDeck = enemyDecks1;
        }
        if (diff == 1)
        {
            cardos = playerDecks2;
            enemyDeck = enemyDecks2;
        }
        if (diff == 2)
        {
            cardos = playerDecks3;
            enemyDeck = enemyDecks3;
        }
        if (diff == 3)
        {
            cardos = playerDecks4;
            enemyDeck = enemyDecks4;
        }
        //starts gaem
        moneyText.gameObject.SetActive(true);
        EmoneyText.gameObject.SetActive(true);
        drawTimeText.gameObject.SetActive(true);
        EdrawTimeText.gameObject.SetActive(true);
        EhandCountText.gameObject.SetActive(true);
    }
    void enemyUses(Card usedCard)
    {
        if (usedCard.name == "Money shot")
        {
            enemyMoney += 50;
        }
        if (usedCard.name == "Double draw")
        {
            EDraw();
            EDraw();
        }
        if (usedCard.name == "Time set")
        {
            EDrawTime *= 0.9f;
        }
        if (usedCard.name == "Steal")
        {
            StartCoroutine("Stealo");
        }
        if (usedCard.name == "Investment")
        {
            StartCoroutine("Inv");

        }
        if (usedCard.name == "Hotel centre")
        {
            EDraw();
            EDraw();
            EDraw();

            StartCoroutine("hot");
        }
        if (usedCard.name == "Red stop")
        {
            EDraw();
            if (money >= 100)
            {
                money -= 100;
            }
            else
            {
                money = 0;
            }
        }
        if (usedCard.name == "A book?")
        {
            StartCoroutine("Bok");
        }
        if (usedCard.name == "Weird hat")
        {
            enemyMoney += 150;
        }
        if (usedCard.name == "FREEEZE!!!")
        {
            aaah -= 10;
        }
    }
    private IEnumerator Bok()
    {
        yield return new WaitForSeconds(6f);
        EDraw();
        if (enemyMoney <= 200)
        {
            enemyMoney += 100;
        }
    }
    private IEnumerator Inv()
    {
        yield return new WaitForSeconds(12f);
        enemyMoney += 200;
        EDraw();
        EDraw();

    }
    private IEnumerator hot()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            enemyMoney += 25;
        }
    }
    private IEnumerator Stealo()
    {
        yield return new WaitForSeconds(5f);
        enemyMoney += 75;
        if (money >= 75)
        {
            money -= 75;
        }
        else
        {
            money = 0;
        }
    }
    private IEnumerator agh()
    {
        foreach (Card item in enemyHand)
        {
            if (enemyMoney >= item.cost)
            {
                enemyHandheCanUSE.Add(item);
            }
        }
        while (enemyHandheCanUSE.Count != 0)
        {
            if (Random.Range(0, 1) == 0)
            {
                Card inUse = enemyHandheCanUSE[Random.Range(0, enemyHandheCanUSE.Count - 1)];
                enemyHand.Remove(inUse);
                GameObject bob = Instantiate(card, transform.position, Quaternion.identity);
                enemyUses(inUse);
                bob.GetComponent<CardDisplay>().card = inUse;
                bob.GetComponent<CardDisplay>().isEnemies = true;
                enemyMoney -= inUse.cost;
                enemyHandheCanUSE.Clear();
                foreach (Card item in enemyHand)
                {
                    if (enemyMoney >= item.cost)
                    {
                        enemyHandheCanUSE.Add(item);
                    }
                }
                yield return new WaitForSeconds(2.5f);
            }
        }
        yield return new WaitForSeconds(0.5f);
    }
    void Lose()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }
    void GetNext()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }
    public void GetBackToMenu()
    {
        foreach (GameObject cux in GameObject.FindGameObjectsWithTag("Card"))
        {
            Destroy(cux);
        }
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    private IEnumerator del()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Cansus"));
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("Cansus"));
            foreach (GameObject cux in GameObject.FindGameObjectsWithTag("Cansus"))
            {
                if (cux != this.gameObject)
                {
                    Destroy(cux);
                }
            }
        }
        yield return new WaitForSeconds(0.67f);
    }
    void Update()
    {
        aS.volume = audioSlider.value;
        aSFX.volume = audioSlider.value;
        if (money >= moneyLimit)
        {
            GetNext();
        }
        else if (enemyMoney >= moneyLimit)
        {
            Lose();
        }
        if (3 - Timef <= 0)
        {
            StartCoroutine("agh");
            Timef = 0;
        }
        moneyText.text = "Money: " + money.ToString();
        EmoneyText.text = "Enemy's money: " + enemyMoney.ToString();
        EhandCountText.text = "Hand size: " + enemyHand.Count.ToString();
        if (bv)
        {
            aaah += Time.deltaTime;
            Eaaah += Time.deltaTime;
            Timef += Time.deltaTime;
        }
        drawTimeText.text = "Draw time: " + (Mathf.Round(DrawTime - aaah)).ToString();
        EdrawTimeText.text = "Draw time: " + (Mathf.Round(EDrawTime - Eaaah)).ToString();
        if (aaah >= DrawTime && bv)
            {
                aaah = 0;
            Draw();
            money += 75;
            }
        if (Eaaah >= EDrawTime && bv)
        {
            Eaaah = 0;
            EDraw();
            enemyMoney += 75;
        }
        if (ak)
        {
            HinaMOMENTO.text = info[heh];
            if (heh != ps)
            {
                HinaSpin[heh].color = UNNNNcolour;
            }
            if (dc == 0)
            {
                HinaSpin[heh].fontStyle = FontStyles.Bold;
                HinaSpin[heh].color = colour;
                dc = 1;
            }
            if (p == 0)
            {
                sus.clip = aC[heh];
                HinaSpin[heh].fontStyle = FontStyles.Bold;
                HinaSpin[heh].color = colour;
                sus.Play();
                p = 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (heh < (aC.Length - 1))
                {
                    if (heh != ps)
                    {
                        HinaSpin[heh].color = UNcolour;
                    }
                    heh++;
                }
                else
                {
                    if (heh != ps)
                    {
                        HinaSpin[heh].color = UNcolour;
                    }
                    heh = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (heh > 0)
                {
                    if (heh != ps)
                    {
                        HinaSpin[heh].color = UNcolour;
                    }
                    heh--;
                }
                else
                {
                    if (heh != ps)
                    {
                        HinaSpin[heh].color = UNcolour;
                    }
                    heh = 4; // zmien tu na 5
                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                p = 0;
                HinaSpin[ps].color = UNcolour;
                HinaSpin[ps].fontStyle ^= FontStyles.Bold;
                ps = heh;
                HinaSpin[heh].color = colour;
                HinaSpin[heh].fontStyle = FontStyles.Bold;
                sus.clip = aC[heh];
            }
        }
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
