using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ButtonClick()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "GameStart":
                //メインシーンへ飛ぶ
                SceneManager.LoadScene("Main");
                break;

            case "GameClear":
                //スタートシーンへ飛ぶ
                SceneManager.LoadScene("GameStart");
                break;

            case "GameOver":
                //スタートシーンへ飛ぶ
                SceneManager.LoadScene("GameStart");
                break;
        }
    }

    public static void GameStart()
    {        //スタートシーンへ飛ぶ
        Cursor.visible = true;
        SceneManager.LoadScene("GameStart");
    }

    public static void GameOver()
    {
        //ゲームオーバーシーンへ飛ぶ
        SceneManager.LoadScene("GameOver");
    }

    public static void GameClear()
    {
        //ゲームクリアシーンへ飛ぶ
        SceneManager.LoadScene("GameClear");
    }
}
