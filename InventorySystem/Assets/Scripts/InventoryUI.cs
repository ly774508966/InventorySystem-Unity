
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public Transform characterItems;



    Inventory inventory;

    InventorySlot[] slots;
    InventorySlot[] slots1; // for character

    // Use this for initialization
    void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        slots1 = characterItems.GetComponentsInChildren<InventorySlot>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if(EquipmentManager.instance.currentEquipment[i] != null)
            {
                slots1[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
                Image img = slots1[i].transform.GetChild(0).GetChild(0).GetComponent<Image>();
                img.sprite = EquipmentManager.instance.currentEquipment[i].icon;
            }
            else
            {
                slots1[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
            }

        }

        CreateItem.playerStatsText.text = "Player Stats\n" + "Armor : " + GameObject.FindWithTag("Player").GetComponent<CharacterStats>().armor.GetValue() +
    "\nDamage : " + GameObject.FindWithTag("Player").GetComponent<CharacterStats>().damage.GetValue();


    }

}
