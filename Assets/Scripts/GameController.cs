using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {
    
    public float[] arrayXPos;
    public float spawnWaitTime;

    public GameObject cub;
    public GameObject menu;

    public Text scoreText, lifeText, resultText;


    static int score;
    static int life;
    int resultScore;

    public static bool gameStart;

	void Start ()
    {
        gameStart = false;
        score = 0;
        life = 3;
        arrayXPos = new float[] { -9f, 0f, 9f };
        StartCoroutine(SpawnPicUp());
	}
	
	void Update ()
    {
        Debug.Log("Score: " + score);
        scoreText.text ="Score: "+ score;
        lifeText.text = "Life: " + life;

        if (gameStart)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
        if (life<=0)
        {
            gameStart = false;
            resultScore = score;
            resultText.text ="Record\n"+resultScore;
        }
    }

    IEnumerator SpawnPicUp()
    {
            yield return new WaitForSeconds(1f);
            Quaternion spawnRotation = Quaternion.identity;
            while (true)
            {            
                Vector3 spawnPosition = new Vector3(arrayXPos[Random.Range(0, 3)], 0f, -31f);
                Instantiate(cub, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWaitTime);    
            }



    }

    public static void ScoreUp(int valueScore,int valueLife)
    {
        if (score>=0)
        {
            score += valueScore;
        }
        life += valueLife;
    }

    public void GameStart()
    {
        gameStart = true;
        Debug.Log("gameStart" + gameStart);
        life = 3;
        score = 0;
    }

    public void EndGame()
    {
        Application.Quit();
    }
   
}
