using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ButtonClick()
    {
        if (SceneManager.GetActiveScene().name == "GameStart")
        {
            //メインシーンへ飛ぶ
            SceneManager.LoadScene("Main");
        }
        if (SceneManager.GetActiveScene().name == "GameClear")
        {
            //スタートシーンへ飛ぶ
            SceneManager.LoadScene("GameStart");
        }
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            //スタートシーンへ飛ぶ
            SceneManager.LoadScene("GameStart");
        }

    }
}
