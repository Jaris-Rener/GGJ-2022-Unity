using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    [ContextMenu("Test Pickup")]
    public override void DoInteraction() {
        base.DoInteraction();
        InventoryManager.instance.AddItem(this.Item);
        Destroy(this.gameObject);      
    }
}
