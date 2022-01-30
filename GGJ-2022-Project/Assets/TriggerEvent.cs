using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public string EventName;
    public bool Completed;

    public void Trigger()
    {
        if (SaveManager.Instance.SaveData.Interactions.ContainsKey(EventName))
        {
            SaveManager.Instance.SaveData.Interactions[EventName] = Completed;
        }
        else
        {
            SaveManager.Instance.SaveData.Interactions.Add(EventName, Completed);
        }

        SaveManager.Instance.Save();
    }
}