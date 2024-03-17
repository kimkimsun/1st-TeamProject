using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] monster; //몬스터 프리팹을 지정하기 위한 용도(유니티에서 프리팹 직접 지정)
    int arraySize = 3;             //일반몹 배열 3개 인스턴트에서 활용
    int monsterCount = 10;        //소환할 몬스터 수 지정

    public Transform[] spawnPoint_MonsterCreature1_LP;      //소환할 지역 좌표를 배열로 수 설정(유니티에서)
    public Transform[] spawnPoint_FishMan;      //소환할 지역 좌표를 배열로 갯수 설정(유니티에서)
    public Transform[] spawnPoint_Medusa;      //소환할 지역 좌표를 배열로 갯수 설정(유니티에서)

    //보스로 가게 될 트리거카운트: 중간보스 잡을때마다 goToBoss++; 3되면 bool open과 연동
    public int goToBoss;
    //goToBoss가 3이 되면 보스로 갈 수 있는 스위치
    public bool open;

    void Start()
    {
        //일단 시작하자 마자 소환하게 기능 설정함
        StartCoroutine(Summon());
        goToBoss = 0;
        open = false;

    }

    IEnumerator Summon()
    {
        yield return new WaitForSeconds(1);     //시작한 후 1초 뒤에 시작하게 설정

        while (monsterCount > 0)
        {
            monsterCount--;
            RandomSpawn(monsterCount);
       
        }
    }

    void RandomSpawn(int num)
    {
        Instantiate(monster[arraySize - 3], spawnPoint_MonsterCreature1_LP[monsterCount].position, spawnPoint_MonsterCreature1_LP[monsterCount].rotation);
        Instantiate(monster[arraySize - 2], spawnPoint_FishMan[monsterCount].position, spawnPoint_FishMan[monsterCount].rotation);
        Instantiate(monster[arraySize - 1], spawnPoint_Medusa[monsterCount].position, spawnPoint_Medusa[monsterCount].rotation);

    }
}