using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms;

public class Monster_Main : Monster
{
    public Spell1 skill1;
    public Spell2 skill2;

    bool isCool;
    bool isSafe;

    float currTime; //�ð� ����

    public Transform[] spawnPointNormal;
    public Transform[] spawnPointBoss;

    public GameObject[] monster;
    public FireBarrier barrier;

/*    [SerializeField]
    private string[] effectSounds = new string[3];*/

    int spawnArraySize = 3;
    int monsterArraySize = 4;
    public int safeDestroy = 3;

    public Slider bossHpBar;
    public GameObject bossHp;

    // Start is called before the first frame update
    private void Awake()
    {
        //������ �ִϸ����� ������Ʈ�� �Է½�Ŵ!
        monsterCreature1 = gameObject.GetComponent<Animator>();
        //Ÿ��(�÷��̾�)�� ��ġ�� �Է½�Ŵ
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        //������ٵ� ������Ʈ ������: �ӵ� ������
        rb = GetComponent<Rigidbody>();

        skill1 = FindObjectOfType<Spell1>();
        skill2 = FindObjectOfType<Spell2>();

        col = GetComponent<BoxCollider>();

        barrier = FindObjectOfType<FireBarrier>(true);

        isSafe = true;
    }

    void Start()
    {
        gameObject.SetActive(false);
        barrier.gameObject.SetActive(false);

    }

    private new void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && isDead == false)
        {
            this.hp -= collision.transform.GetComponent<Bullet>().Damage;
            if (this.hp <= 50 && isSafe == true)
            {
                this.hp = 50;
                col.enabled = false;
                barrier.gameObject.SetActive(true);

                Instantiate(monster[monsterArraySize-1], spawnPointBoss[spawnArraySize - 3].position, spawnPointBoss[spawnArraySize - 3].rotation);
                Instantiate(monster[monsterArraySize - 2], spawnPointBoss[spawnArraySize - 3].position, spawnPointBoss[spawnArraySize - 3].rotation);
                Instantiate(monster[monsterArraySize - 3], spawnPointBoss[spawnArraySize - 3].position, spawnPointBoss[spawnArraySize - 3].rotation);
                
            }
            if (this.hp <= 0)
            {
                //SoundManager.instance.PlaySE(effectSounds[2]);
                isDead = true;
                this.hp = 0;
                StopCoroutine(AttackPattern());
                StartCoroutine(Die());
            }
        }
    }

    public IEnumerator AttackPattern()
    {
       
        while (true)
        {
            int random = Random.Range(0, 2);

            switch (random)
            {
                case 0:
                    //SoundManager.instance.PlaySE(effectSounds[0]);
                    monsterCreature1.SetTrigger("attack1");
                    skill1.isTrigger = true;
                    break;
                case 1:
                    //SoundManager.instance.PlaySE(effectSounds[1]);
                    monsterCreature1.SetTrigger("attack2");
                    skill2.isTrigger = true;
                    break;
            }
            if (isCool == true)
            {
                yield return new WaitForSeconds(1);
                isCool = false;
            }
            yield return new WaitForSeconds(6f);
            if (this.hp <= 0)
            {
                StopCoroutine(AttackPattern());
            }
        }
    }

    public override IEnumerator Die()
    {
        this.monsterCreature1.SetTrigger("Death"); //�ִϸ��̼� "Death" ���
        this.isDead = true; //isDead Ȱ��ȭ

        Destroy(gameObject, 3.0f);
        yield return new WaitForSeconds(2f);
    }

    void Update()
    {
        //jaw�� ��� �Լ� �����غ���

        currTime += Time.deltaTime; //�ð����� �ð��帣�� 
        
        if (currTime > 20) // �ð������� 10�ʺ��� Ŭ�� 
        {
            Instantiate(monster[monsterArraySize-4], spawnPointNormal[spawnArraySize - 3].position, spawnPointNormal[spawnArraySize - 3].rotation); // ���͹迭 [1] ���ִ� ���� ����
            Instantiate(monster[monsterArraySize-4], spawnPointNormal[spawnArraySize - 2].position, spawnPointNormal[spawnArraySize - 2].rotation); // ���͹迭 [1] ���ִ� ���� ����
            Instantiate(monster[monsterArraySize-4], spawnPointNormal[spawnArraySize - 1].position, spawnPointNormal[spawnArraySize - 1].rotation); // ���͹迭 [1] ���ִ� ���� ����

            Debug.Log("��ȯ����");
            currTime = 0; //�ð� 0�ʷ� �ٽõ��ư��� �ݺ�.
        }
        
        if (isCool == false)
        {
            isCool = true;
        }

        if (safeDestroy == 0)
        {
            col.enabled = true;
            isSafe = false;
            barrier.gameObject.SetActive(false);

        }
        bossHpBar.value = hp / maxHp;

    }
}