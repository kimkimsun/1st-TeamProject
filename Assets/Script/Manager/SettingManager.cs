using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    MainMenuManager mainMenuManager;

   public void OnClickCancelBtn()
    {
        ExitManager.prevStageIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
