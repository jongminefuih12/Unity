using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart2 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SecondScene");
        }
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("SecondScene");
    }
}
