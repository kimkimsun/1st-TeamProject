using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject mainBoss;
   

    private void Update()
    {
       if(playerObj.gameObject.GetComponent<Player>().Hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

       else if(mainBoss.gameObject.GetComponent<Monster_Main>().hp <= 0)
        {
            SceneManager.LoadScene("HappyEnding");
        }
       
    }
}