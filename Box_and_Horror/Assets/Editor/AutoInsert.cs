using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(HorrorProductionManager))]
public class AutoInsert : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        HorrorProductionManager horrorProductionManager = (HorrorProductionManager)FindObjectOfType(typeof(HorrorProductionManager));
        if(GUILayout.Button("AutoInsert"))
        {
            horrorProductionManager.HorrorProductionsInsert(HorrorProductionsSearch());
            EditorUtility.SetDirty(horrorProductionManager);
            AssetDatabase.SaveAssets();
        }
    }

    public List<HorrorProductionSettings> HorrorProductionsSearch()
    {
        List<HorrorProductionSettings> result = new List<HorrorProductionSettings>();

        string folderPath ="Assets/Resources/HorrorProductions";
        string[] files = Directory.GetFiles(folderPath);

        foreach(string str in files)
        {
            if(Path.GetExtension(str) == ".asset")
            {
                HorrorProductionSettings horrorProductionSettings = AssetDatabase.LoadAssetAtPath(str, typeof(HorrorProductionSettings)) as HorrorProductionSettings;
                result.Add(horrorProductionSettings);
            }
        }

        return result;
    }
}
