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
    void Awake()
    {
        m = 5;
        f = 0;
        canv = GameObject.Find("Canvas");
    }
    public void OnCliccko()
    {
        if (canv.GetComponent<EEE>().money >= costt)
        {
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
        }
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
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Break();
        }
        if (isHovered)
        {
            m = 70;
            f = 1;
            buh.transform.localScale = new Vector3(1.55f, 1.55f, 1f);
        }
        else
        {
            m = 20;
            f = 0;
            buh.transform.localScale = new Vector3(0.92f, 0.92f, 1f);
        }
        namet = card.name;
        costt = card.cost;
        nameText.text = namet;
        desText.text = card.des;
        costText.text = costt.ToString();
        sus.GetComponent<Image>().sprite = card.gus; //czemu do cholery to sie nazywa sprite jak jest w edytorze napisane source image wtf
        buh.transform.position = new Vector3(660 - cont * 96, m, 0);
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
