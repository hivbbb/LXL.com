using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public GameObject slotGrid;
    public GameObject toolGrid;
    //public slot slotPrefab;
    public GameObject emptySlot;
    public Inventory Bag;
    public Text itemInformation;

    public List<GameObject> slots = new List<GameObject>();
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
     
        
    }
    private void OnEnable()
    {
        RefreshItem();
    }
    /*public static void CreateNewItem(Item item)
    {
        slot newItem = Instantiate(instance.slotPrefab_1, instance.slotGrid_1.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid_1.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.ItemImage;
        newItem.slotNum.text = item.ItemHeld.ToString();
    }*/
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount;i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();

        }
        for (int i = 0; i < instance.Bag.itemList.Count; i++)
        {
            //CreateNewItem(instance.Bag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<slot>().slotID = i;
            instance.slots[i].GetComponent<slot>().SetupSlot(instance.Bag.itemList[i]);

        }
    }
}
