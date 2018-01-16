
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    public string itemName = "New Item";
    public Sprite icon = null;
    public int upgradeLevel = 1;
    
    public bool isDisenchantable = true;
    public bool isUpgradeable​ = true;

    public virtual void Use()
    {
      //  Debug.Log("Using " + name);
    }




}
