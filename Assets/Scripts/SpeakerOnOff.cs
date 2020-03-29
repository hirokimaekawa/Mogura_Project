using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerOnOff : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject OffButton;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpeakerOffButton()
    {
        audio.mute = false;
        OffButton.SetActive(false);
    }

    public void SpeakerOnButton()
    {
        audio.mute = true;
        OffButton.SetActive(true);
    }
}
