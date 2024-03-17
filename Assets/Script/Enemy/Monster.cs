using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using JetBrains.Annotations;
using Random = UnityEngine.Random;


public class Monster : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public int atk;

    float HP
    {
        get
        {
            return hp;
        }

        set
        {
            hp = maxHp;
        }
    }

    int ATK
    {
        get
        {
            return atk;
        }
        set
        {
            atk = value;
        }
    }


    public GameObject boxPrefab;

    // 플레이어 추적하기 위해 트랜스폼 컴포넌트 설정
    public Transform targetPlayer;
    private Transform targetDrone;

    //내비개이션+걸어다니면서 
    public NavMeshAgent agent;

    public bool isDead = false;
    public bool isSeekPlayer = false;
    public bool isSeekDrone = false;

    //애니매이터 컴포넌트 호출
    public Animator monsterCreature1;

    public Rigidbody rb;

    public BoxCollider col;

    public System.Action onDie;

    public GameObject bullet;

    // Start is called before the first frame update
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

        targetDrone = GameObject.FindGameObjectWithTag("Drone").transform;

        col = GetComponent<BoxCollider>();
    }


    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && isDead == false)
        {
            this.hp -= collision.transform.GetComponent<Bullet>().Damage;
            Debug.Log("남은" + hp);
            if (this.hp <= 0)
            {
                isDead = true;
                isSeekPlayer = false;
                this.hp = 0;
                StartCoroutine(Die());
            }
        }
    }

    public virtual IEnumerator Die()
    {
        int random;
        random = Random.Range(0, 5);
        Debug.Log("아이템" + random);

        agent.SetDestination(agent.transform.position);
        this.monsterCreature1.SetTrigger("Death"); //애니메이션 "Death" 출력
        if (random < 1)
        {
            this.DropItem(); //DropItem 함수 실행
            this.onDie(); //onDie이벤트 활성화

        }
        Destroy(gameObject, 2.5f); //게임오브젝트 3초후 파괴.
        yield return new WaitForSeconds(2f); //2초 기다림
    }

    public virtual void DropItem()
    {
        //var 변수는 무조건 지역변수로만 선언해야하고 초기화작업을 바로 해야 사용 가능
        var itemGo = Instantiate<GameObject>(this.boxPrefab); // Instantiate 함수는 플레이중 게임오브젝트 생성한다.
        itemGo.transform.position = this.gameObject.transform.position; //itemGo의 위치는 생성된 아이템프리팹 위치.
        itemGo.SetActive(false); //itemgo를 비활성화 (object.SetActive(false) << 오브젝트를 비활성화시킴.)
        this.onDie = () => //onDie 이벤트 발생시킴
        {
            itemGo.SetActive(true); //itemgo 활성화.
        };
    }

    IEnumerator DroneDisappear()
    {
        yield return new WaitForSeconds(7);
        isSeekDrone = false;
    }

    protected void FreezeRotation()
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        FreezeRotation();
        if (this.hp <= 0 && this.isDead == true)
        {
            return;
        }
        if (isSeekPlayer == true)
        {
            isSeekDrone = false;
            monsterCreature1.SetFloat("Locomotion", 0.5f);
            //Debug.Log("대상 추적 확인!");
            agent.SetDestination(targetPlayer.position);
            return;
        }
        else if (isSeekDrone == true)
        {
            monsterCreature1.SetFloat("Locomotion", 0.5f);
            //Debug.Log("대상 추적 확인!");
            agent.SetDestination(targetDrone.position);
            StartCoroutine(DroneDisappear());
        }
        else if (isSeekPlayer == false)
        {
            monsterCreature1.SetFloat("Locomotion", 0f);
            //Debug.Log("대상 놓침 확인!");
            agent.SetDestination(transform.position);
        }
        else if (isSeekDrone == false)
        {
            monsterCreature1.SetFloat("Locomotion", 0f);
            //Debug.Log("대상 놓침 확인!");
            agent.SetDestination(transform.position);
        }

    }

}
