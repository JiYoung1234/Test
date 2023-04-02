using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MovingObject
{
    public float restartLevelDelay = 1f; 
    public int pointsPerFood = 10; 
    public int pointsPerSoda = 20; 
    public int wallDamage = 1; 
    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip eatSound1;
    public AudioClip eatSound2; 
    public AudioClip drinkSound1; 
    public AudioClip drinkSound2;
    public AudioClip gameOverSound;
    private Animator animator; 
    private Text foodText;
    private int food;

    protected override void Start()
    {
        animator = GetComponent<Animator>();

        foodText = FindObjectOfType<Canvas>().GetComponentInChildren<Text>();

        food = GameManager.instance.playerFoodPoints;
        foodText.text = "Food: " + food;

        base.Start();
    }


    private void OnDisable()
    {
        //씬이 다시 시작되면 해당 스크립트는 날라감. 따라서 GameManager에 값을 저장한다.
        GameManager.instance.playerFoodPoints = food;
    }


    private void Update()
    {
        //턴일때, 게임 시작 가능할때 움직임.
        if (!GameManager.instance.playersTurn || GameManager.instance.doingSetup) return;

        int horizontal = 0; int vertical = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0)
        {
            vertical = 0;
        }
        if (horizontal != 0 || vertical != 0)
        {
            AttemptMove<Wall>(horizontal, vertical);
        }
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        //식량 감소
        food--;
        foodText.text = "Food: " + food;

        //해당 앞에 이동가능한지 체크
        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;

        if (Move(xDir, yDir, out hit))
        {
            SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
        }

        //음식을 다먹어서 끝났는가?
        CheckIfGameOver();

        //턴 종료
        GameManager.instance.playersTurn = false;
    }


    protected override void OnCantMove<T>(T component)
    {
        //벽이면 부순다
        Wall hitWall = component as Wall;
        hitWall.DamageWall(wallDamage);

        animator.SetTrigger("playerChop");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }

        else if (other.tag == "Food")
        {
            food += pointsPerFood;
            foodText.text = "+" + pointsPerFood + " Food: " + food;

            SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);
            other.gameObject.SetActive(false);
        }

        else if (other.tag == "Soda")
        {
            food += pointsPerSoda;
            foodText.text = "+" + pointsPerSoda + " Food: " + food;

            SoundManager.instance.RandomizeSfx(drinkSound1, drinkSound2);
            other.gameObject.SetActive(false);
        }
    }


    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //플레이어 피격
    public void LoseFood(int loss)
    {
        animator.SetTrigger("playerHit");

        food -= loss;
        foodText.text = "-" + loss + " Food: " + food;

        //죽었는가?
        CheckIfGameOver();
    }


    private void CheckIfGameOver()
    {
        //게임 오버
        if (food <= 0)
        {
            SoundManager.instance.PlaySingle(gameOverSound);
            SoundManager.instance.musicSource.Stop();

            enabled = false;
            GameManager.instance.GameOver();
        }
    }
}
