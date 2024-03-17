using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBuff : Potion
{
    new int atkBuff =50;//공격력증가
    new int buffTime = 60;
   


    public void Use() //포션 사용시
    {
        GameObject target = GameObject.Find("Player");
        Player player = target.GetComponent<Player>();
        player.Hp += hpBuff;

        
       // player.gun.Damage += atkBuff;

        this.useable = true; //이 템 사용되었음
        Debug.Log(name + " 을 사용 하였습니다.");
        Debug.Log("현재체력" + player.Hp); //변하는지 확인용
        //Debug.Log("현재공격력" + player.gun.Damage); //변하는지 확인용
        StartCoroutine(Reset());
    }
    IEnumerator Reset()
    {

        yield return new WaitForSeconds(buffTime);
        GameObject target = GameObject.Find("Player");
        Player player = target.GetComponent<Player>();

        //player.gun.Damage -= atkBuff;
       
        //Debug.Log("현재공격력" + player.gun.Damage); //변하는지 확인용
        Delete(this.useable);

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Use();
        }
    }
    void Start()
    {
        items[5] = gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
}
