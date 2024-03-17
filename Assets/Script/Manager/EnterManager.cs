using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterManager : MonoBehaviour
{
    public SpawnPoint spawnManager;

    public Monster_Main mainBoss;

    BoxCollider col;

    public bool isCheck;

    private void Start()
    {
        col = gameObject.GetComponent<BoxCollider>();
        spawnManager = gameObject.GetComponent<SpawnPoint>();

   

        isCheck = true;
    }

    IEnumerator Once()
    {
        if (spawnManager.open == true)
        {
            mainBoss.gameObject.SetActive(true);
            mainBoss.StartCoroutine(mainBoss.AttackPattern());
            // 보스 입구는 중간보스 세마리 모두 처치시 입구 collider 가 Trigger 체크 되도록
            col.isTrigger = true;
        }
        yield return null;
        isCheck = false;
        StopCoroutine(Once());
    }


    private void Update()
    {
        if (isCheck == true && spawnManager.open == true)
        {
            StartCoroutine(Once());
        }
    }



}
