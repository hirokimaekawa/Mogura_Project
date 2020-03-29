using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject SpeakerToOnButton;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //Invoke("LoadScene", 3f);
    }
    void LoadScene1()
    {
        SceneManager.LoadScene("Main"); 
    }

    void LoadScene2()
    {
        SceneManager.LoadScene("History");
    }

    public void SpeakerOffButton()
    {
        audio.mute = true;
        SpeakerToOnButton.SetActive(true);
    }

    public void SpeakerOnButton()
    {
        audio.mute = false;
        SpeakerToOnButton.SetActive(false);
    }
}

