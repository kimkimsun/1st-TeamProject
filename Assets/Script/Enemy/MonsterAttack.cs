using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack: MonoBehaviour
{
    public Player player;
    public Monster monster;
    BoxCollider col;

    public bool isHit = false;

    private void Start()
    {
        player = Player.FindObjectOfType<Player>();
        col=gameObject.GetComponent<BoxCollider>();
    }

    private IEnumerator ResetCol()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1f);
        col.enabled = true;
    }

    private void OnTriggerEnter(Collider nail)
    {
        isHit = true;
        if (nail.gameObject.tag == "Player" && isHit == true)
        {
            player.Hp -= monster.atk;
            StartCoroutine(ResetCol());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isHit = false;
    }
}
