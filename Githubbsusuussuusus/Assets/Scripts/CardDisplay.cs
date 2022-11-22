using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
   public Card card;
   private string namet;
    private int costt;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI nameText;
    void Awake()
    {
        namet = card.name;
        costt = card.cost;
       nameText.text = namet;
        costText.text = costt.ToString();
    }

}
