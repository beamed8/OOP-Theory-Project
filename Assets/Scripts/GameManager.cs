using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager instance { get; private set; }

    public static event Action PlayerKilled;

    public GameObject playerPrefab;
    public GameObject spawnPosition;

    public int score;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // ABSTRACTION: using only one function for changing scenes
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator ResetPlayer(GameObject player)
    {
        Destroy(player);
        yield return new WaitForSeconds(0.5f);
        Instantiate(playerPrefab, spawnPosition.transform.position, Quaternion.identity);
        PlayerKilled?.Invoke();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

}
