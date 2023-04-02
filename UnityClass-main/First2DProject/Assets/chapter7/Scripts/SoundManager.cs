using UnityEngine;
using System.Collections;


public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;                  
    public AudioSource musicSource;                 
    public static SoundManager instance = null;     		
    public float lowPitchRange = .95f;              
    public float highPitchRange = 1.05f;            


    void Awake()
    {
        //싱글톤
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }


    //필요한 소리로 교체후 소리 플레이
    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }


    //params 키워드는 변수를 원하는 수만큼 넘겨줄 수 있다. (배열을 직접 넘기지않고 하나씩 넘겨도 된다)
    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //사운드의 속도(pitch)
        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];

        efxSource.Play();
    }
}
