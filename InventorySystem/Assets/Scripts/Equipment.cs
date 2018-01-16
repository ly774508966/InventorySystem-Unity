
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        CreateItem.generalText.text = "Item Name : " + name + "\nArmor : " + armorModifier + "\nDamage : " + damageModifier +
            "\nLevel : " + upgradeLevel + "\nDisenchantable : " + isDisenchantable + "\nUpgradable : " + isUpgradeable​ + "Item Type : " + equipSlot;
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}

public enum EquipmentSlot { Weapon, Head, Shield, Chest }
