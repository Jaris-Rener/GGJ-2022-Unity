using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string PromptLine;
    public float radius = 5f;
    public Item Item;

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void DoInteraction() {
        Debug.Log("Interaction");
    }
}
