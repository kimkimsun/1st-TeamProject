using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    public static int prevStageIndex;
    public void OnClickYesBnt()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void OnClickNoBnt()
    {
        SceneManager.LoadScene(prevStageIndex);
    }
}
