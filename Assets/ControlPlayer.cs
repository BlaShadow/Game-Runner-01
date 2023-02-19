using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ControlPlayer : MonoBehaviour {
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject exitButton;
    public GameObject pauseText;

    bool isOnGround;
    public bool isPaused;

    public Vector3 initialPosition;

    public void resume() {
        isPaused = false;
        Time.timeScale = 1;

        hideAllButtons();
    }

    public void pause() {
        isPaused = true;
        Time.timeScale = 0;

        showAllButtons();
    }

    // Start is called before the first frame update
    void Start() {
        initialPosition = transform.position;

        isPaused = false;
        hideAllButtons();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isOnGround = collision.collider.name == "ground";

        // Reset game
        if (collision.collider.tag == "obstacle") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void jump() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400.0f));

        isOnGround = false;
    }

    private void hideAllButtons() {
        handleButtons(false);
    }

    private void showAllButtons() {
        handleButtons(true);
    }

    private void handleButtons(bool value) {
        pauseButton.SetActive(!value);
        resumeButton.SetActive(value);
        exitButton.SetActive(value);
        pauseText.SetActive(value);
    }
}
