using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } // ENCAPSULATION

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

}
