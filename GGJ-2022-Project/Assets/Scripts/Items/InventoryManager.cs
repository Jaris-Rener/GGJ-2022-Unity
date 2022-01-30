using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager instance;
    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("Already instance of Inventory Manager");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> Inventory = new List<Item>();
    public int InventorySlots = 8;

    public delegate void OnAddedItem(Item addedItem);
    public static event OnAddedItem OnAddedItemCallback;

    public delegate void OnRemovedItem(int removedItem);
    public static event OnRemovedItem OnRemovedItemCallback;

    public void AddItem(Item item) {
        if(Inventory.Count < InventorySlots) {
            Inventory.Add(item);
            if (OnAddedItemCallback != null) { OnAddedItemCallback(item); }
        }
    }

    [ContextMenu("Test Use")]
    public void TestUse()
    {
        UseItem(0, new Vector3(0, 0, 0));
    }

    public GameObject UseItem(int slot, Vector3 spawnLocation) {
        GameObject placedItem = Instantiate(Inventory[slot].Prefab, spawnLocation, Quaternion.identity);
        if (OnRemovedItemCallback != null) { OnRemovedItemCallback(slot); }
        Inventory.RemoveAt(slot);
        return placedItem;
    }
}
