using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
    public int ItemHeld;
    [TextArea]
    public string ItemInfo;
    public bool Tool;
    public bool Equip;
}
