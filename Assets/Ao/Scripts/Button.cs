using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnButtonClickStart()
    {
        SceneManager.LoadScene("otamescene");
    }

    public void OnButtonClickTitleBack()
    {
        SceneManager.LoadScene("Title");
    }
}
