using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject IntroPanel;
    public GameObject StartPanel;

    void Start()
    {
        StartCoroutine(DelayTime(1.5f));
    }

    IEnumerator DelayTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        IntroPanel.SetActive(false);
        StartPanel.SetActive(true);
    }

    public void OnclickStartBnt()
    {
        SceneManager.LoadScene("Opening");
        ExitManager.prevStageIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void OnclickSettingBnt()
    {
        SceneManager.LoadScene("Setting");
        ExitManager.prevStageIndex = SceneManager.GetActiveScene().buildIndex;

    }

    public void OnclickExitBnt()
    {
        SceneManager.LoadScene("Exit");
        ExitManager.prevStageIndex = SceneManager.GetActiveScene().buildIndex;

    }


}
