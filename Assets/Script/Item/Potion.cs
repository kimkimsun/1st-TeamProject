using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


/*public struct PotionInfo
{
    public int hpBuff;
    public int atkBuff;
    public int buffTime;
}*/

public class Potion : Item
{
    //PotionInfo potion;
     protected int hpBuff; //체력회복
     protected int atkBuff;//공격력증가
     protected int buffTime;

  /*  void Start()
    {
        Init(inPutHpBuff, inPutAtkBuff);
    }*/

    void Update()
    {
        Rotate();
        
    }

/*    public void Use() //포션 사용시
    {       
        GameObject target;
        target = GameObject.Find("Player");
        Player player = target.GetComponent<Player>();
        player.Hp += hpBuff;
        player.Atk += atkBuff;

        this.useable = true; //이 템 사용되었음
        Debug.Log(itemName + " 을 사용 하였습니다.");                    
        Debug.Log("현재체력" + player.Hp); //변하는지 확인용
        Debug.Log("현재공격력" + player.Atk); //변하는지 확인용
        StartCoroutine(Reset());
    }
*/
/*    public void Init(int hp, int atk)
    {
       
        potion.hpBuff = hp;
        potion.atkBuff = atk;
       
    }*/

/*    IEnumerator Reset()
    {    

        yield return new WaitForSeconds(buffTime);
          GameObject target;
          target = GameObject.Find("Player");
          Player player = target.GetComponent<Player>();
          player.Atk -= atkBuff;
          Debug.Log("현재체력" + player.Hp); //변하는지 확인용
          Debug.Log("현재공격력" + player.Atk); //변하는지 확인용
          Delete(this.useable);      

    }
*/

/*    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>()!=null)
        {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Use();          
        }
    }*/

}
