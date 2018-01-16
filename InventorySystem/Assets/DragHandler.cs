using UnityEngine.EventSystems;
using UnityEngine;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;
    public static GameObject onDropped;
    public static int secondSlotIndex;
    public static bool isSwap;

    public static int processForDragging;

    int firstSlotIndex;

    Vector3 startPosition;
    Transform firstSlot;

    void Start()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;

        firstSlot = transform.parent;

        firstSlotIndex = int.Parse(firstSlot.parent.name);

        // reaching slot gameobject
        // transform.parent.parent.GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        

        transform.position = startPosition;

        if(processForDragging == 1) // disenchant
        {
            if (Inventory.instance.items[firstSlotIndex].isDisenchantable) {
                Inventory.instance.items[firstSlotIndex].RemoveFromInventory();
                CreateItem.generalText.text = Inventory.instance.items[firstSlotIndex].name + " disenchanted";
            }
            else
            {
                CreateItem.generalText.text = Inventory.instance.items[firstSlotIndex].name + " is not disenchantable";
            }
            
        }
        else if (processForDragging == 2) // upgrade
        {

            if (Inventory.instance.items[firstSlotIndex].isUpgradeable​)
            {
                Inventory.instance.Upgrade(Inventory.instance.items[firstSlotIndex]);
                CreateItem.generalText.text = Inventory.instance.items[firstSlotIndex].name + " upgraded";
            }
            else{
                CreateItem.generalText.text = Inventory.instance.items[firstSlotIndex].name + " is not upgradable";
            }
                
        }
        else if(processForDragging == 3) // swap
        {
            Inventory.instance.Change(firstSlotIndex, secondSlotIndex);
        }
        else if (processForDragging == 4) // equip
        {

            if (Inventory.instance.items[firstSlotIndex].equipSlot.ToString().Equals(onDropped.transform.name))
            {
                EquipmentManager.instance.Equip(Inventory.instance.items[firstSlotIndex]);
                Inventory.instance.Remove(Inventory.instance.items[firstSlotIndex]);
            }
            else
            {
                //give a message
            }

        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
        itemBeingDragged = null;


    }
}
