
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one instance of inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 20;

    public List<Equipment> items = new List<Equipment>();

    public bool Add(Equipment item)
    {
        
        if (items.Count >= space)
        {

            CreateItem.generalText.text = "Not enough space in inventory";
            return false;
        }

        items.Add(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        return true;

    }
    public void Remove (Equipment item){

        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }

    public void Upgrade(Equipment item)
    {
        item.armorModifier = item.armorModifier + 1;
        item.damageModifier = item.damageModifier + 1;
        item.upgradeLevel = item.upgradeLevel + 1;
    }

    public void Change(int firstS, int secondS)
    {
        try
        {
            Equipment tempItem = new Equipment();
            tempItem = items[firstS];
            items[firstS] = items[secondS];
            items[secondS] = tempItem;
        }
        catch
        {
            CreateItem.generalText.text = "there is no item for swapping";
            //Debug.Log("sth is going wrong in changing");
        }


        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

    }

}
