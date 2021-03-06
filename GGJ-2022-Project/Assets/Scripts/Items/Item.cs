using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "FerrousWheel/Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public GameObject Prefab;
}
