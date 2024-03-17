using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    Player player;
    private int spellDamage;

    void Start()
    {
        player = FindObjectOfType<Player>();
        spellDamage = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Hp -= spellDamage;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
