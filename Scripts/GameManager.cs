using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadNextScene", 17f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("lastEnding");
    }
}