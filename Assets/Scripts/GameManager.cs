using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject endLevelText;
    public GameObject gameOverText;
    public GameObject replayButton;
    public GameObject nextLevelButton;
    public GameObject allLevelsButton;
    public GameObject Level1Button;
    public GameObject Level2Button;
    public GameObject Level3Button;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    
    public int levelNumber;
    public float secondWait;

    public int numberOfStars = 0;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void EndLevel()
    {
        gameOver = true;
        endLevelText.SetActive(true);
        allLevelsButton.SetActive(true);
        replayButton.SetActive(true);
        nextLevelButton.SetActive(true);
        
        StartCoroutine(DisplayStars());
    }

    private IEnumerator DisplayStars()
    {
        if (numberOfStars >= 1)
        {
            yield return new WaitForSeconds(secondWait);
            star1.SetActive(true);
        }
        if (numberOfStars >= 2)
        {
            yield return new WaitForSeconds(secondWait);
            star2.SetActive(true);
        }
        if (numberOfStars == 3)
        {
            yield return new WaitForSeconds(secondWait);
            star3.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        allLevelsButton.SetActive(true);
        replayButton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Replay()
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void NextLevel()
    {
        if (levelNumber != 2)
            SceneManager.LoadScene(levelNumber + 1);
    }

    public void AllLevels()
    {
        replayButton.SetActive(false);
        nextLevelButton.SetActive(false);
        allLevelsButton.SetActive(false);

        Level1Button.SetActive(true);
        Level2Button.SetActive(true);
        Level3Button.SetActive(true);
    }

    public void Level1()
    {
        SceneManager.LoadScene(0);
    }

    public void Level2()
    {
        SceneManager.LoadScene(1);
    }

    public void Level3()
    {
        SceneManager.LoadScene(2);
    }
}
