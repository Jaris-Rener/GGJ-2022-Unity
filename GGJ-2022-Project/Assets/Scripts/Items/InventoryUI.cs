using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    #region Singleton
    public static InventoryUI instance;
    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("Already instance of Inventory UI");
            return;
        }
        instance = this;
    }
    #endregion

    public Slot[] Slots;

    [System.Serializable] public class Slot {
        public Image ImageRenderer;
        public Item Item;
    }

    private void Start() { 
        InventoryManager.OnAddedItemCallback += AddedItemUI;
        InventoryManager.OnRemovedItemCallback += RemoveItemUI;
        //Slots = new Slot[InventoryManager.instance.InventorySlots];
    }

    void AddedItemUI(Item item) {
        foreach (var slot in Slots) {
            if(slot.Item == null) {
                slot.Item = item;
                slot.ImageRenderer.enabled = true;
                slot.ImageRenderer.sprite = item.Icon;
                break;
            }
        }
    }

    void RemoveItemUI(int slot) {
        Slots[slot].Item = null;
        Slots[slot].ImageRenderer.enabled = false;
    }
}
