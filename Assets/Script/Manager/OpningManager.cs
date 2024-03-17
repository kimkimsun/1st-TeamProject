using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpningManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
