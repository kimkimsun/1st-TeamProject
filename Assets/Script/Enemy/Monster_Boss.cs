using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.AI;
using JetBrains.Annotations;
using Random = UnityEngine.Random;


public class Monster_Boss : Monster
{
    SpawnPoint spwanPoint;
    Monster_Main boss;
    public Portal portal;
    public Player player;

    public GameObject shield;
    public Slider bossHpBar;
    public GameObject bossHp;

    //스타트 함수는 상속이 불가능!
    void Start()
    {
        //몬스터의 애니매이터 컴포넌트를 입력시킴!
        monsterCreature1 = gameObject.GetComponent<Animator>();

        //타겟(플레이어)의 위치를 입력시킴
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        //내비메쉬 컴포넌트 가져옴: 추적 활성화, 비활성화용
        agent = GetComponent<NavMeshAgent>();

        //리지드바디 컴포넌트 가져옴: 속도 고정용
        rb = GetComponent<Rigidbody>();

        portal = FindObjectOfType<Portal>(true);

        spwanPoint = FindObjectOfType<SpawnPoint>();

        boss=FindObjectOfType<Monster_Main>();

        shield.SetActive(true);


    }


    public override IEnumerator Die()
    {
        this.isDead = true; //isDead 활성화
        this.DropItem(); //DropItem 함수 실행
        this.onDie(); //onDie이벤트 활성화
        agent.SetDestination(agent.transform.position);
        this.monsterCreature1.SetTrigger("Death"); //애니메이션 "Death" 출력
       if(spwanPoint.open==true)
        {
            boss.safeDestroy--;
        }
        spwanPoint.goToBoss++;

        if(spwanPoint.goToBoss==3)
        {
            spwanPoint.open=true;

            Debug.Log("차원문");
            portal.transform.position = targetPlayer.transform.position;
            portal.transform.position += (targetPlayer.transform.forward * 5f);
            portal.transform.position += (targetPlayer.transform.up * 1.5f);
            shield.SetActive(false);
            portal.gameObject.SetActive(true);
        }
        Destroy(gameObject, 3.0f); //게임오브젝트 3초후 파괴.

        yield return new WaitForSeconds(2f); //2초 기다림

    }

    public override void DropItem()
    {
        //var 변수는 무조건 지역변수로만 선언해야하고 초기화작업을 바로 해야 사용 가능
        var itemGo = Instantiate<GameObject>(this.boxPrefab); // Instantiate 함수는 플레이중 게임오브젝트 생성한다.
        itemGo.transform.position = this.gameObject.transform.position; //itemGo의 위치는 생성된 아이템프리팹 위치.
        itemGo.SetActive(false); //itemgo를 비활성화 (object.SetActive(false) << 오브젝트를 비활성화시킴.)
        this.onDie = () => //onDie 이벤트 발생시킴: 람다식 함수
        {
            itemGo.SetActive(true); //itemgo 활성화.
        };
    }

    void Update()
    {
        
        FreezeRotation();

        if (isSeekPlayer == true)
        {
            monsterCreature1.SetFloat("Locomotion", 0.5f);
            //Debug.Log("대상 추적 확인!");
            agent.SetDestination(targetPlayer.position);
            return;
        }
        else if (isSeekPlayer == false)
        {
            monsterCreature1.SetFloat("Locomotion", 0f);
            //Debug.Log("대상 놓침 확인!");
            agent.SetDestination(transform.position);
        }
        bossHpBar.value = hp / maxHp;
    }
}
