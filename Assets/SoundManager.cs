/*sing System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Sound
{ 
    public string name; //���� �̸�
    public AudioClip clip; //����

}


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioSource[] audioSourcesEffcets; //����Ʈ ���� �迭
    public AudioSource audioSourcesBgm; //��� ����


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
    public void PlaySE(string name) //����Ʈ���� ���
    {

        for(int i = 0; i < effectSounds.Length; i++) //����ȿ� ã�� �̸��� �ִ���
        {
            if (name == effectSounds[i].name) //ã�Ҵٸ� 
            {
                for (int j = 0; j < audioSourcesEffcets.Length; j++) //��������� ���� ����� �ҽ��� ã��
                {
                    if (!audioSourcesEffcets[j].isPlaying) //��������� �ʴٸ�
                    {
                        playSoundName[j] = effectSounds[i].name;
                        audioSourcesEffcets[j].clip = effectSounds[i].clip;
                        audioSourcesEffcets[j].Play();//���
                        return;
                    }
                }
                Debug.Log("��� ����� �ҽ� �����");
                return;
            }
        }
        Debug.Log(name + "���尡 ��ϵ��� ����");
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
        Debug.Log("�������" + name + "���尡 �����ϴ�");
    }

}
*/