using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    public Card[] cardos;
    public int cardCount;
    public float money;
    public float enemyMoney;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI EmoneyText;
    public TextMeshProUGUI drawTimeText;
    public List<int> esk;
    float aaah = 0;
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
    bool bv = false;
    void Awake()
    {
        money = 100;
        enemyMoney = 100;
        DontDestroyOnLoad(this.gameObject);
        //when getting back destroy this;
    }
    public IEnumerator ah()
    {
        yield return new WaitForSeconds(0.1f);
        enem = GameObject.Find("enmemuy");
        Debug.Log(enem);
        enem.GetComponent<SpriteRenderer>().sprite = sprites[diff];
        for (int i = 0; i < 3; i++)
        {
            Draw();
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
        StartCoroutine("ah");
        //starts gaem
        moneyText.gameObject.SetActive(true);
        EmoneyText.gameObject.SetActive(true);
        drawTimeText.gameObject.SetActive(true);
        bv = true;
    }
    void Update()
    {
        moneyText.text = "Money: " + money.ToString();
        EmoneyText.text = "Enemy's money: " + enemyMoney.ToString();
        if (bv)
        {
            aaah += Time.deltaTime;
        }
        drawTimeText.text = "Draw time: " + (Mathf.Round(DrawTime - aaah)).ToString();
        if (aaah >= DrawTime && bv)
            {
                aaah = 0;
            Draw();
            money += 75;
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
