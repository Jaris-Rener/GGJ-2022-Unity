namespace UnityTemplateProjects
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using Newtonsoft.Json;
    using UnityEngine;
    using Debug = UnityEngine.Debug;

    public class SaveManager : MonoBehaviour
    {
        public string FileExtension => "json";
        public string FilePath => $"SaveFile.{FileExtension}";
        public string SavePath => $"{Application.persistentDataPath}/{FilePath}";

        public SaveData SaveData = new SaveData()
        {
            Interactions =
            {
                { "CoolEvent", false },
                { "TestItem", true },
                { "AnEventThatHappened", true },
                { "DidntHappen", false },
            }
        };

#if UNITY_EDITOR
        [ContextMenu("Open Save Folder")]
        public void OpenSaveFolder()
        {
            print(Application.persistentDataPath);
            Process.Start("explorer.exe", $"{Application.persistentDataPath}/".Replace('/', '\\'));
        }
#endif

        [ContextMenu("Save")]
        public void Save()
        {
            var json = JsonConvert.SerializeObject(SaveData, Formatting.Indented);
            File.WriteAllText(SavePath, json);
            print("saved game");
        }

        [ContextMenu("Load")]
        public void Load()
        {
            var json = File.ReadAllText(SavePath);
            SaveData = JsonConvert.DeserializeObject<SaveData>(json);
            print("loaded game");
            foreach (var pair in SaveData.Interactions)
            {
                print($"{pair.Key} - {pair.Value}");
            }
        }
    }

    public class SaveData
    {
        public readonly Dictionary<string, bool> Interactions = new Dictionary<string, bool>();
    }
}