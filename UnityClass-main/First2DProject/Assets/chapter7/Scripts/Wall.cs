using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    public AudioClip chopSound1;               
    public AudioClip chopSound2;                
    public Sprite dmgSprite;                    
    public int hp = 3;                         


    private SpriteRenderer spriteRenderer;      


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //벽 부수기
    public void DamageWall(int loss)
    {
        //2개중 랜덤한 소리가 나옴.
        SoundManager.instance.RandomizeSfx(chopSound1, chopSound2);

        spriteRenderer.sprite = dmgSprite;

        hp -= loss;

        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
