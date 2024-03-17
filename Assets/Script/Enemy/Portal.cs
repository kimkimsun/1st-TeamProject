using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Player player;


    void Start()
    {
        player = FindObjectOfType<Player>();
        gameObject.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            player.transform.position = new Vector3(109f, 2f, -189f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
