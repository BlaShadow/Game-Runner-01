using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject cloud;
    public Text scoreUI;

    float timer;
    float cloudTimer;
    float score;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        manageTimer();

        createClouds();
    }

    private void manageTimer() {
        timer += Time.deltaTime;
        score += Time.deltaTime;

        if (timer >= 2){
            addObstacle();

            timer = 0;
        }

        displayScore();
    }

    private void addObstacle() {
        var positionPlayer = GameObject.Find("player").GetComponent<ControlPlayer>().initialPosition;
        var totalObstacles = Random.Range(1, 5);

        for (var i = 1; i <= totalObstacles; i++) {
            var vector = positionPlayer + Vector3.right * (20 + i);
            vector.y = -3.21f;

            var t1 = GameObject.Instantiate(obstacle, vector, Quaternion.identity);
        }
        
    }

    private void createClouds() {
        cloudTimer += Time.deltaTime;
        var topRightCorner = GameObject.Find("topRightCorner").transform.position;
        var altitude = Random.Range(0, 3);

        if (cloudTimer >= 6) {
            cloudTimer = 0;
            var vector = topRightCorner + -Vector3.up * altitude;

            var cloudInstance = GameObject.Instantiate(cloud, vector, Quaternion.identity);
        }
    }

    private void displayScore() {
        scoreUI.text = score.ToString("0");
    }
}
