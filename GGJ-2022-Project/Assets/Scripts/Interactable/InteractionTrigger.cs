using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractionTrigger : Interactable
{
    public UnityEvent OnTriggerEvent;

    private void Start() { if (OnTriggerEvent == null) { OnTriggerEvent = new UnityEvent(); } }

    public override void DoInteraction() {
        if(!enabled)
            return;
        
        base.DoInteraction();
        OnTriggerEvent.Invoke();
    }
}
