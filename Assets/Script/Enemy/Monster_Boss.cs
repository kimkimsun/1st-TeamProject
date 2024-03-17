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

    //��ŸƮ �Լ��� ����� �Ұ���!
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

        portal = FindObjectOfType<Portal>(true);

        spwanPoint = FindObjectOfType<SpawnPoint>();

        boss=FindObjectOfType<Monster_Main>();

        shield.SetActive(true);


    }


    public override IEnumerator Die()
    {
        this.isDead = true; //isDead Ȱ��ȭ
        this.DropItem(); //DropItem �Լ� ����
        this.onDie(); //onDie�̺�Ʈ Ȱ��ȭ
        agent.SetDestination(agent.transform.position);
        this.monsterCreature1.SetTrigger("Death"); //�ִϸ��̼� "Death" ���
       if(spwanPoint.open==true)
        {
            boss.safeDestroy--;
        }
        spwanPoint.goToBoss++;

        if(spwanPoint.goToBoss==3)
        {
            spwanPoint.open=true;

            Debug.Log("������");
            portal.transform.position = targetPlayer.transform.position;
            portal.transform.position += (targetPlayer.transform.forward * 5f);
            portal.transform.position += (targetPlayer.transform.up * 1.5f);
            shield.SetActive(false);
            portal.gameObject.SetActive(true);
        }
        Destroy(gameObject, 3.0f); //���ӿ�����Ʈ 3���� �ı�.

        yield return new WaitForSeconds(2f); //2�� ��ٸ�

    }

    public override void DropItem()
    {
        //var ������ ������ ���������θ� �����ؾ��ϰ� �ʱ�ȭ�۾��� �ٷ� �ؾ� ��� ����
        var itemGo = Instantiate<GameObject>(this.boxPrefab); // Instantiate �Լ��� �÷����� ���ӿ�����Ʈ �����Ѵ�.
        itemGo.transform.position = this.gameObject.transform.position; //itemGo�� ��ġ�� ������ ������������ ��ġ.
        itemGo.SetActive(false); //itemgo�� ��Ȱ��ȭ (object.SetActive(false) << ������Ʈ�� ��Ȱ��ȭ��Ŵ.)
        this.onDie = () => //onDie �̺�Ʈ �߻���Ŵ: ���ٽ� �Լ�
        {
            itemGo.SetActive(true); //itemgo Ȱ��ȭ.
        };
    }

    void Update()
    {
        
        FreezeRotation();

        if (isSeekPlayer == true)
        {
            monsterCreature1.SetFloat("Locomotion", 0.5f);
            //Debug.Log("��� ���� Ȯ��!");
            agent.SetDestination(targetPlayer.position);
            return;
        }
        else if (isSeekPlayer == false)
        {
            monsterCreature1.SetFloat("Locomotion", 0f);
            //Debug.Log("��� ��ħ Ȯ��!");
            agent.SetDestination(transform.position);
        }
        bossHpBar.value = hp / maxHp;
    }
}
