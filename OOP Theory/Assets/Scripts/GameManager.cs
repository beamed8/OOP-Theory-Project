using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } // ENCAPSULATION

    public static event Action PlayerKilled;

    public GameObject playerPrefab;
    public Material playerMat;
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

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string sceneName) // ABSTRACTION: using only one function for changing scenes
    {
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator ResetPlayer(GameObject player)
    {
        Destroy(player);
        yield return new WaitForSeconds(0.5f);
        Instantiate(playerPrefab, spawnPosition.transform.position, Quaternion.identity);
        // player.transform.position = spawnPosition.transform.position;
        // player.GetComponent<Renderer>().material = playerMat;
        PlayerKilled?.Invoke();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

}
