using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageButtonsScripts : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject exitButton;

    public AudioSource gamePlayAudioSource;
    public AudioSource pauseAudioSource;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("chapter1");
    }

    public void Resume() {
        pauseAudioSource.Pause();
        gamePlayAudioSource.Play();

        GameObject.Find("player").GetComponent<ControlPlayer>().resume();
    }

    public void Pause() {
        gamePlayAudioSource.Pause();
        pauseAudioSource.Play();

        GameObject.Find("player").GetComponent<ControlPlayer>().pause();
    }

    public void Exit() {
        Application.Quit();
    }
}
