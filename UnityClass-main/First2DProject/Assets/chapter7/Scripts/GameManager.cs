using UnityEngine;
using System.Collections;
using System.Collections.Generic;      
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;              

    public float levelStartDelay = 2f;                      
    public float turnDelay = 0.1f;                          
    public int playerFoodPoints = 100;                      

    [HideInInspector]
    public bool playersTurn = true;                        
    [HideInInspector]
    public bool doingSetup = true;                          

    private Text levelText;                                
    private GameObject levelImage;                          
    private BoardManager boardScript;                      
    private int level = 1;                                  
    private List<Enemy> enemiesInCurrentField;        //필드에 나와있는 적들 리스트                        
    private bool enemiesMoving;                             


    void Awake()
    {
        //싱글톤
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnLoadThisScene;
        enemiesInCurrentField = new List<Enemy>();
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    // 해당 씬이 시작될때 호출될 메소드
    private void OnLoadThisScene(Scene arg0, LoadSceneMode arg1)
    {
        //다음 스테이지일때 레벨 증가 및 게임 초기화
        level++;
        InitGame();
    }

    //게임 초기화
    void InitGame()
    {
        doingSetup = true;

        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        levelText.text = "Day " + level;
        levelImage.SetActive(true);

        //Invoke 키워드는 딜레이 시간 이후 함수를 실행시킨다. levelStartDelay 시간 뒤에 HideLevelImage를 실행한다.
        Invoke("HideLevelImage", levelStartDelay);

        enemiesInCurrentField.Clear();
        boardScript.SetupScene(level);      //맵 제작
    }


    void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    void Update()
    {
        if (playersTurn || enemiesMoving || doingSetup)
            return;


        StartCoroutine(MoveEnemies());
    }

    public void AddEnemyToList(Enemy script)
    {
        enemiesInCurrentField.Add(script);
    }


    public void GameOver()
    {
        levelText.text = "After " + level + " days, you starved.";

        levelImage.SetActive(true);

        enabled = false;
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;

        yield return new WaitForSeconds(turnDelay);

        if (enemiesInCurrentField.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i = 0; i < enemiesInCurrentField.Count; i++)
        {
            enemiesInCurrentField[i].MoveEnemy();
            yield return new WaitForSeconds(enemiesInCurrentField[i].moveTime);
        }

        playersTurn = true;
        enemiesMoving = false;
    }
}
