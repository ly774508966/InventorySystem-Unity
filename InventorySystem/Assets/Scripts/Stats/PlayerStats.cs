using UnityEngine;

public class PlayerStats : CharacterStats
{

    // Use this for initialization
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void Update()
    {
       // CreateItem.playerStatsText.text = gameObject.GetComponent<CharacterStats>().armor.GetValue() + "";//"Player Damage : " + transform.GetComponent<Stat>().GetValue();

    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {

        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.armorModifier);
        }
        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.armorModifier);
        }

    }
}
