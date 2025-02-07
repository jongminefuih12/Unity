using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart3 : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetZombieKillCount();
            SceneManager.LoadScene("ThirdScene");
        }
    }
    public void SceneChange()
    {
        ResetZombieKillCount();
        SceneManager.LoadScene("ThirdScene");
    }
    void ResetZombieKillCount()
    {
        zombie.killedZombies = 0;
    }
}
