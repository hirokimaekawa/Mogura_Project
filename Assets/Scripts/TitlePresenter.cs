using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePresenter : MonoBehaviour
{
    public void OnStartGameButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnHistroyButton()
    {
        SceneManager.LoadScene("Histroy");
    }
}