using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart4 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("FinalScene");
        }
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
