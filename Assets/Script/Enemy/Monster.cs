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

    // �÷��̾� �����ϱ� ���� Ʈ������ ������Ʈ ����
    public Transform targetPlayer;
    private Transform targetDrone;

    //�����̼�+�ɾ�ٴϸ鼭 
    public NavMeshAgent agent;

    public bool isDead = false;
    public bool isSeekPlayer = false;
    public bool isSeekDrone = false;

    //�ִϸ����� ������Ʈ ȣ��
    public Animator monsterCreature1;

    public Rigidbody rb;

    public BoxCollider col;

    public System.Action onDie;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        //������ �ִϸ����� ������Ʈ�� �Է½�Ŵ!
        monsterCreature1 = gameObject.GetComponent<Animator>();

        //Ÿ��(�÷��̾�)�� ��ġ�� �Է½�Ŵ
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        //����޽� ������Ʈ ������: ���� Ȱ��ȭ, ��Ȱ��ȭ��
        agent = GetComponent<NavMeshAgent>();

        //������ٵ� ������Ʈ ������: �ӵ� ������
        rb = GetComponent<Rigidbody>();

        targetDrone = GameObject.FindGameObjectWithTag("Drone").transform;

        col = GetComponent<BoxCollider>();
    }


    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && isDead == false)
        {
            this.hp -= collision.transform.GetComponent<Bullet>().Damage;
            Debug.Log("����" + hp);
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
        Debug.Log("������" + random);

        agent.SetDestination(agent.transform.position);
        this.monsterCreature1.SetTrigger("Death"); //�ִϸ��̼� "Death" ���
        if (random < 1)
        {
            this.DropItem(); //DropItem �Լ� ����
            this.onDie(); //onDie�̺�Ʈ Ȱ��ȭ

        }
        Destroy(gameObject, 2.5f); //���ӿ�����Ʈ 3���� �ı�.
        yield return new WaitForSeconds(2f); //2�� ��ٸ�
    }

    public virtual void DropItem()
    {
        //var ������ ������ ���������θ� �����ؾ��ϰ� �ʱ�ȭ�۾��� �ٷ� �ؾ� ��� ����
        var itemGo = Instantiate<GameObject>(this.boxPrefab); // Instantiate �Լ��� �÷����� ���ӿ�����Ʈ �����Ѵ�.
        itemGo.transform.position = this.gameObject.transform.position; //itemGo�� ��ġ�� ������ ������������ ��ġ.
        itemGo.SetActive(false); //itemgo�� ��Ȱ��ȭ (object.SetActive(false) << ������Ʈ�� ��Ȱ��ȭ��Ŵ.)
        this.onDie = () => //onDie �̺�Ʈ �߻���Ŵ
        {
            itemGo.SetActive(true); //itemgo Ȱ��ȭ.
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
            //Debug.Log("��� ���� Ȯ��!");
            agent.SetDestination(targetPlayer.position);
            return;
        }
        else if (isSeekDrone == true)
        {
            monsterCreature1.SetFloat("Locomotion", 0.5f);
            //Debug.Log("��� ���� Ȯ��!");
            agent.SetDestination(targetDrone.position);
            StartCoroutine(DroneDisappear());
        }
        else if (isSeekPlayer == false)
        {
            monsterCreature1.SetFloat("Locomotion", 0f);
            //Debug.Log("��� ��ħ Ȯ��!");
            agent.SetDestination(transform.position);
        }
        else if (isSeekDrone == false)
        {
            monsterCreature1.SetFloat("Locomotion", 0f);
            //Debug.Log("��� ��ħ Ȯ��!");
            agent.SetDestination(transform.position);
        }

    }

}
