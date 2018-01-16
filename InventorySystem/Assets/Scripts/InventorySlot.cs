using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{

    public const string disenchantArea = "Disenchant";
    public const string upgradeArea = "Upgrade";
    public const string equipmentArea = "CharacterEquipment";

    public Image icon;

    Equipment item;

    public void OnDrop(PointerEventData eventData)
    {

        if (transform.name.Equals(disenchantArea))
        {
                DragHandler.processForDragging = 1;
        }
        else if(transform.name.Equals(upgradeArea)){

            DragHandler.processForDragging = 2;
        }
        else if (transform.parent.parent.name.Equals(equipmentArea))
        {
            DragHandler.onDropped = transform.gameObject;
            DragHandler.processForDragging = 4;
        }
        
        else//swap
        {
            DragHandler.secondSlotIndex = int.Parse(transform.name);
            DragHandler.processForDragging = 3; //swap 3
        }
        
    }

    public void AddItem(Equipment newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;

    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

    }

    //upgrade item
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

}
