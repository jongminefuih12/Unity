using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restrart1 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("FirstScene");
        }

    }
    public void SceneChange()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
