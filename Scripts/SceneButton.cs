using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{

    public void SceneChange()
    {
        SceneManager.LoadScene("SecondScene");
    }

}
