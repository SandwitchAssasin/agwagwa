using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Card", menuName = "Card/GwaGwa")]
public class Card : ScriptableObject
{
    public new string name;
    public int cost;
}
