using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;      // 이후 쓰일 Random 들은 모두 UnityEngine의 랜덤이다 (System과 UnityEngine 의 충돌)

public class BoardManager : MonoBehaviour
{
    //Inspector창에서 Class는 보여주지 않음. Serializable을 쓰면 Inspector창에서 보임.
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 8;
    public int rows = 8;
    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);
    public GameObject player;
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject[] outerWallTiles;
    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();      //맵 

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }


    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                //바닥 타일 랜덤 지정
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }

                //지정된 바닥 생성
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }


    //리스트에서 지워가며 랜덤한 맵 일부분을 가르킨다.
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }


    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }


    public void SetupScene(int level)
    {
        BoardSetup();

        InitialiseList();

        //랜덤한 위치에 벽과 음식 생성
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);

        //Log2(level)
        int enemyCount = (int)Mathf.Log(level, 2f);

        //랜덤한 위치에 적 생성
        LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);

        //탈출구는 오른쪽 상단에 설치
        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);

        //플레이어는 중앙(좌측 하단)에 생성
        Instantiate(player, Vector3.zero, Quaternion.identity);
    }
}
