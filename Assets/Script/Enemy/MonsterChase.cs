using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public Monster monster;

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            monster.isSeekPlayer = true;
        }
        if(other.gameObject.tag == "Drone")
        {
            monster.isSeekDrone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            monster.isSeekPlayer = false;
        }
        if (monster.gameObject.tag == "Drone")
        {
            monster.isSeekDrone = false;
        }
    }

    private void Update()
    {
       
    }

}
