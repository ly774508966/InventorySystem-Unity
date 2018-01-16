using UnityEngine;
using UnityEngine.UI;

public class CreateItem : MonoBehaviour {

    public Equipment item;
    public Equipment item1;
    public Equipment item2;
    public static Text generalText;
    public static Text playerStatsText;

    private bool isUpgradeable​;
    private bool isDisenchantable;
    private string armor = "armor";
    private string damage = "damage";
    private string selected = "0";
    private string itemName = "ItemName";
    

    public Sprite[] sprites;

    // Use this for initialization
    void Start () {

        generalText = GameObject.FindWithTag("GeneralTextArea").GetComponent<Text>();
        playerStatsText = GameObject.FindWithTag("PlayerStatsText").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Inventory.instance.Add(item);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Inventory.instance.Add(item1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Inventory.instance.Add(item2);
        }

    }

    void OnGUI()
    {

        string[] options = new string[4];
        options = System.Enum.GetNames(typeof(EquipmentSlot));


        itemName = GUILayout.TextArea(itemName, 15, GUILayout.Height(30));
        isUpgradeable​ = GUILayout.Toggle(isUpgradeable​, "Upgradable", GUILayout.Height(25));
        isDisenchantable = GUILayout.Toggle(isDisenchantable, "Disenchantable", GUILayout.Height(25));
        armor = GUILayout.TextArea(armor, 15, GUILayout.Height(30));
        damage = GUILayout.TextArea(damage, 15, GUILayout.Height(30));
        GUILayout.TextField("0 - Weapon / 1 - Head / 2 - Shield / 3 - Chest");
        selected = GUILayout.TextArea(selected, 15, GUILayout.Height(30));

        //GUILayout.SelectionGrid(selected, options, options.Length, GUILayout.Toggle);
        //GUILayout.TextArea()


        if (GUILayout.Button("Create", GUILayout.Height(25)))
        {
            CreateNewItem();
        }
    }

    public void CreateNewItem()
    {
        Equipment newEquipment = new Equipment();

        if (itemName != null || itemName.Equals(""))
        {
            newEquipment.name = itemName;
        }
        else
        {
            newEquipment.name = "NewItem";
        }

        newEquipment.armorModifier = int.Parse(armor);
        newEquipment.damageModifier = int.Parse(damage);

        newEquipment.isDisenchantable = isDisenchantable;
        newEquipment.isUpgradeable​ = isUpgradeable​;
        newEquipment.icon = sprites[UnityEngine.Random.Range(0, 7)];

        //for equipmentSlot
        if (int.Parse(selected) == 0)
        {
            newEquipment.equipSlot = EquipmentSlot.Weapon;
        }
        else if (int.Parse(selected) == 1)
        {
            newEquipment.equipSlot = EquipmentSlot.Head;
        }
        else if (int.Parse(selected) == 2)
        {
            newEquipment.equipSlot = EquipmentSlot.Shield;
        }
        else if (int.Parse(selected) == 3)
        {
            newEquipment.equipSlot = EquipmentSlot.Chest;
        }

        Inventory.instance.Add(newEquipment);

        generalText.text = newEquipment.name + " Created..\n" + "Armor : "+ newEquipment.armorModifier + "\n Damage : " + newEquipment.damageModifier + "\n Disenchantable : " +
            newEquipment.isDisenchantable + "\n Upgradeable : " + newEquipment.isUpgradeable​ + "\n ItemType : " + newEquipment.equipSlot;

    } 

}
