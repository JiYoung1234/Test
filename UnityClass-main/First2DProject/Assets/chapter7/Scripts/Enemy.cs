using UnityEngine;
using System.Collections;


public class Enemy : MovingObject
{
    public int playerDamage; 
    public AudioClip attackSound1; 
    public AudioClip attackSound2;

    private Animator animator; 
    private Transform target; 
    private bool skipMove;

    protected override void Start()
    {
        GameManager.instance.AddEnemyToList(this);
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;  //플레이어 찾기

        base.Start();
    }


    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        //움직일 수 있는 차례인가?
        if (skipMove)
        {
            skipMove = false;
            return;
        }

        //이동
        base.AttemptMove<T>(xDir, yDir);
        skipMove = true;
    }


    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;

        //사정거리 안에 들었는가?
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {
            yDir = target.position.y > transform.position.y ? 1 : -1;
        }
        else
        {
            xDir = target.position.x > transform.position.x ? 1 : -1;
        }

        AttemptMove<Player>(xDir, yDir);
    }


    protected override void OnCantMove<T>(T component)
    {
        //플레이어라면 공격 시도
        Player hitPlayer = component as Player;

        animator.SetTrigger("enemyAttack");

        SoundManager.instance.RandomizeSfx(attackSound1, attackSound2);
        
        hitPlayer.LoseFood(playerDamage);
    }
}
