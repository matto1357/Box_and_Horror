using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum SceneName
{
    none = -1,
    DeploymentBoxTest,
}

public class SceneShortCut : Editor
{
    private static string scenePath = Application.dataPath + "/Scenes/";

    private static string GetScenePath(SceneName scene)
    {
        return scenePath + scene.ToString() + ".unity";
    }


    [MenuItem("SceneShortCuts/DeploymentBoxTest")]
    static public void Open2D_NotesTestScene()
    {
        //セーブ確認
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            // シーン遷移
            EditorSceneManager.OpenScene(GetScenePath(SceneName.DeploymentBoxTest));
        }
    }

}