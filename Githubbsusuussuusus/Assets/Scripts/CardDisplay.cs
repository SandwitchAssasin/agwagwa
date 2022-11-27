using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public Card card;
   private string namet;
    private int costt;
    public GameObject canv;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI nameText;
    public Image sus;
    public int cont;
    public Vector3 ah;
    public float m;
    public int f;
    bool isHovered;
    public TextMeshProUGUI desText;
    public GameObject buh;
    bool isWaiting = false;
    public bool isEnemies = false;
    float ghaw = 0;
    void Awake()
    {
        m = 5;
        f = 0;
        canv = GameObject.Find("Canvas");
        if (isEnemies)
        {
            buh.GetComponent<Button>().interactable = false;
        }
    }
    public void OnCliccko()
    {
        if (canv.GetComponent<EEE>().money >= costt)
        {
            canv.GetComponent<EEE>().Playo(true);
            canv.GetComponent<EEE>().money -= costt;
            if (namet == "Money shot")
            {
                canv.GetComponent<EEE>().money += 50;
                Destroy(gameObject);
                canv.GetComponent<EEE>().esk.Add(cont);
                canv.GetComponent<EEE>().cardCount -= 1;
            }
            if (namet == "Double draw")
            {
                StartCoroutine("DobleDraw");
            }
            if (namet == "Time set")
            {
                canv.GetComponent<EEE>().DrawTime *= 0.9f;
                Destroy(gameObject);
                canv.GetComponent<EEE>().esk.Add(cont);
                canv.GetComponent<EEE>().cardCount -= 1;
            }
            if (namet == "Steal")
            {
                StartCoroutine("Stealo");
            }
            if (namet == "Investment")
            {
                StartCoroutine("Inv");
            }
            if (namet == "Hotel centre")
            {
                StartCoroutine("hot");
            }
            if (namet == "Red stop")
            {
                StartCoroutine("red");
            }
            if (namet == "A book?")
            {
                StartCoroutine("book");
            }
        }
    }
    private IEnumerator hot()
    {
        canv.GetComponent<EEE>().esk.Add(cont);
        canv.GetComponent<EEE>().cardCount -= 1;
        isWaiting = true;
        yield return new WaitForSeconds(0.35f);
        canv.GetComponent<EEE>().Draw();
        canv.GetComponent<EEE>().Draw();
        canv.GetComponent<EEE>().Draw();
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            canv.GetComponent<EEE>().money += 25;
        }
        Destroy(gameObject);

        canv.GetComponent<EEE>().Playo(false);
    }
    private IEnumerator book()
    {
        canv.GetComponent<EEE>().esk.Add(cont);
        canv.GetComponent<EEE>().cardCount -= 1;
        isWaiting = true;
        yield return new WaitForSeconds(6f);
        canv.GetComponent<EEE>().Draw();
        if (canv.GetComponent<EEE>().money <= 200)
        {
            canv.GetComponent<EEE>().money += 100;
        }
        Destroy(gameObject);

        canv.GetComponent<EEE>().Playo(false);
    }
    private IEnumerator Inv()
    {
        canv.GetComponent<EEE>().esk.Add(cont);
        canv.GetComponent<EEE>().cardCount -= 1;
        isWaiting = true;
        yield return new WaitForSeconds(12f);
        canv.GetComponent<EEE>().money += 200;
        canv.GetComponent<EEE>().Draw();
        canv.GetComponent<EEE>().Draw();
        Destroy(gameObject);

        canv.GetComponent<EEE>().Playo(false);
    }
    private IEnumerator Stealo()
    {
        canv.GetComponent<EEE>().esk.Add(cont);
        canv.GetComponent<EEE>().cardCount -= 1;
        isWaiting = true;
        yield return new WaitForSeconds(5f);
        canv.GetComponent<EEE>().money += 75;
        if (canv.GetComponent<EEE>().enemyMoney >= 75)
        {
            canv.GetComponent<EEE>().enemyMoney -= 75;
        }
        else 
        {
            canv.GetComponent<EEE>().enemyMoney = 0;
        }
        Destroy(gameObject);

        canv.GetComponent<EEE>().Playo(false);
    }
    private IEnumerator red()
    {
        canv.GetComponent<EEE>().esk.Add(cont);
        canv.GetComponent<EEE>().cardCount -= 1;
        if (canv.GetComponent<EEE>().enemyMoney >= 100)
        {
            canv.GetComponent<EEE>().enemyMoney -= 100;
        }
        else
        {
            canv.GetComponent<EEE>().enemyMoney = 0;
        }
        yield return new WaitForSeconds(0.35f);
        canv.GetComponent<EEE>().Draw();
        Destroy(gameObject);
    }
    private IEnumerator DobleDraw()
    {
        canv.GetComponent<EEE>().esk.Add(cont);
        canv.GetComponent<EEE>().cardCount -= 1;
        yield return new WaitForSeconds(0.35f);
        canv.GetComponent<EEE>().Draw();
        canv.GetComponent<EEE>().Draw();
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        if (!isEnemies)
        {
            if (!isWaiting)
            {
                if (isHovered)
                {
                    m = 70;
                    f = 2;
                    buh.transform.localScale = new Vector3(1.55f, 1.55f, 1f);
                }
                else
                {
                    m = 20;
                    f = 0;
                    buh.transform.localScale = new Vector3(0.92f, 0.92f, 1f);
                }
            }
            else
            {
                buh.GetComponent<Button>().interactable = false;
                buh.transform.localScale = new Vector3(1.25f, 1.25f, 1f);
                transform.Rotate(0f, 0f, 5f);
                m = 150;
                f = 1;
            }
            buh.transform.position = new Vector3(660 - cont * 96, m, 0);
        }
        else
        {
            f = 3;
            buh.transform.localScale = new Vector3(1.75f, 1.75f, 1f);
            ghaw += Time.deltaTime;
            buh.transform.position = new Vector3(660 - (ghaw * 207f), 170, 0);
            if (ghaw >= 3)
            {
                Destroy(gameObject);
            }
        }
        namet = card.name;
        costt = card.cost;
        nameText.text = namet;
        desText.text = card.des;
        costText.text = costt.ToString();
        sus.GetComponent<Image>().sprite = card.gus; //czemu do cholery to sie nazywa sprite jak jest w edytorze napisane source image wtf
        GetComponent<Canvas>().sortingOrder = f;
        GetComponent<Canvas>().overrideSorting = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }
}
