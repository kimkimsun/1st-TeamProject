using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

   
    public void OnClickQuitButton()
    {
        SceneManager.LoadScene("Exit");
        ExitManager.prevStageIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnClickSettingButton()
    {
        SceneManager.LoadScene("Setting");
        ExitManager.prevStageIndex = SceneManager.GetActiveScene().buildIndex;
    }

}
