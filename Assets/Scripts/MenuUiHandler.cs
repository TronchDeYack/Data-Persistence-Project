using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUiHandler : MonoBehaviour
{

    public void OnUpdateName (string s)
    {
        PlayerDataManager.Instance.playerName = s;
    }

    public void OnStartGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitGame ()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    private void Awake()
    {
        PlayerDataManager.Instance.LoadPlayerData();
    }
}
