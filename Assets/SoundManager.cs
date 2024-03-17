/*sing System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Sound
{ 
    public string name; //사운드 이름
    public AudioClip clip; //사운드

}


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioSource[] audioSourcesEffcets; //이펙트 담을 배열
    public AudioSource audioSourcesBgm; //브금 담음


    public string[] playSoundName;

    [SerializeField]
    public Sound[] effectSounds;
    public Sound[] bgmSounds;


    #region singleton
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);          

        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion singleton

    private void Start()
    {
        playSoundName = new string[audioSourcesEffcets.Length];
    }
    public void PlaySE(string name) //이펙트사운드 재생
    {

        for(int i = 0; i < effectSounds.Length; i++) //사운드안에 찾는 이름이 있는지
        {
            if (name == effectSounds[i].name) //찾았다면 
            {
                for (int j = 0; j < audioSourcesEffcets.Length; j++) //재생중이지 않은 오디오 소스를 찾음
                {
                    if (!audioSourcesEffcets[j].isPlaying) //재생중이지 않다면
                    {
                        playSoundName[j] = effectSounds[i].name;
                        audioSourcesEffcets[j].clip = effectSounds[i].clip;
                        audioSourcesEffcets[j].Play();//재생
                        return;
                    }
                }
                Debug.Log("모든 오디오 소스 사용중");
                return;
            }
        }
        Debug.Log(name + "사운드가 등록되지 않음");
    }

    public void StopAllSE()
    {
        for(int i = 0;i < audioSourcesEffcets.Length;i++)
        {
            audioSourcesEffcets[i].Stop();
        }
    }

    public void StopSE(string name)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (playSoundName[i] == name) 
            { 
                audioSourcesEffcets[i].Stop();
                break;
            }
        }
        Debug.Log("재생중인" + name + "사운드가 없습니다");
    }

}
*/