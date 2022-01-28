using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Focus : MonoBehaviour
{
    #region Singleton
    public static Focus instance;

    private void Awake() {
        if (instance != null) { return; }
        instance = this;
    }
    #endregion

    public TMP_Text InteractionText;
    public RaycastHit hit;
    public LayerMask Mask;

    private Camera cam;

    void Start() {
        cam = Camera.main;
    }

    void Update() {
        var mouse = Mouse.current;
        if (Physics.Raycast(cam.transform.position, (cam.transform.forward), out hit, Mathf.Infinity, Mask)) {
            if (hit.collider.gameObject.GetComponent<Interactable>()) {
                Vector3 closestPoint = hit.collider.ClosestPointOnBounds(this.transform.position);
                if (Vector3.Distance(this.transform.position, closestPoint) < hit.collider.transform.gameObject.GetComponent<Interactable>().radius) {
                    Interactable i = hit.collider.transform.gameObject.GetComponent<Interactable>();
                    InteractionText.text = i.Item.Name;

                    if (mouse.leftButton.wasPressedThisFrame) {
                        hit.collider.transform.gameObject.GetComponent<Interactable>().DoInteraction();
                    }           
                }
            } else { InteractionText.text = null; }
        }
    }
}
