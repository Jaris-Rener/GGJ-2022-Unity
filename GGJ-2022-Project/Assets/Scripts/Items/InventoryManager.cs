using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    [SerializeField] private int InventorySlots = 8;
    public UnityEvent OnItemAdded;

    private void Start() { if (OnItemAdded == null) { OnItemAdded = new UnityEvent(); }         }

    public void AddItem(Item item) {
        if(Inventory.Count < InventorySlots) {
            Inventory.Add(item);
            OnItemAdded.Invoke();
        }
    }

    public void UseItem(int slot, Vector3 spawnLocation) {
        GameObject placedItem = Instantiate(Inventory[slot].Prefab, spawnLocation, Quaternion.identity);
    }
}
