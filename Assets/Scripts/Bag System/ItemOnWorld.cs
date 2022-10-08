using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("please get E");
            if (other.gameObject.CompareTag("Player"))
            {
                AddNewItem(thisItem);
                Destroy(gameObject);

            }
        }
        
    }


    public void AddNewItem(Item thisItem)
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            thisItem.ItemHeld = 1;
            //playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
            for(int i=0;i < playerInventory.itemList.Count; i++)
            {
                if(playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.ItemHeld += 1;
        }

        InventoryManager.RefreshItem();
    }
    
}
