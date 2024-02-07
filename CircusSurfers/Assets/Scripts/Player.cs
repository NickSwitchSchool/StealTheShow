using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float startSpeed;
    public float addedSpeed;
    public float addedSpeedMultiplier;
    public Vector3 jump;
    int goingToPathIndex;
    bool isOnLeftPath;
    bool isOnRightPath;
    bool gameOver;
    float gravity;
    int score;
    public GameObject gameOverCanvas;

    private void Start()
    {
        goingToPathIndex = 1;
        gameOver = false;
    }

    void Update()
    {
        if (gameOver)
        {
            return;
        }

        this.gameObject.transform.position += new Vector3(startSpeed * Time.deltaTime + (addedSpeed * addedSpeedMultiplier * Time.deltaTime), 0, 0);
        addedSpeedMultiplier += 0.01f * Time.deltaTime;

        if (!isOnLeftPath && Input.GetKeyDown(KeyCode.D))
        {
            goingToPathIndex--;
        }
        else if (!isOnRightPath && Input.GetKeyDown(KeyCode.A))
        {
            goingToPathIndex++;
        }

        if (goingToPathIndex < 0)
        {
            goingToPathIndex = 0;
        }
        else if (goingToPathIndex > 2)
        {
            goingToPathIndex = 2;
        }

        if (goingToPathIndex == 0 && this.transform.position.z > -2.5f)
        {
            this.gameObject.transform.position += new Vector3(0, 0, -startSpeed * 2 * Time.deltaTime);
        }
        else if (goingToPathIndex == 2 && this.transform.position.z < 2.5f)
        {
            this.gameObject.transform.position += new Vector3(0, 0, startSpeed * 2 * Time.deltaTime);
        }
        else if (goingToPathIndex == 1 && this.transform.position.z < -0.1f)
        {
            this.gameObject.transform.position += new Vector3(0, 0, startSpeed * 2 * Time.deltaTime);
        }
        else if (goingToPathIndex == 1 && this.transform.position.z > 0.1f)
        {
            this.gameObject.transform.position += new Vector3(0, 0, -startSpeed * 2 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(this.transform.position, new Vector3(0, -1, 0), 0.6f))
        {
            this.GetComponent<Rigidbody>().velocity = jump;
        }

        if (!Physics.Raycast(this.transform.position, new Vector3(0, -1, 0), 0.6f) && !gameOver)
        {
            gravity = 10 * Time.deltaTime;
            this.GetComponent<Rigidbody>().velocity += new Vector3(0, -gravity, 0);
        }
        else
        {
            gravity = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag("Death"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameOver = true;
            gameOverCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.gameObject.CompareTag("Point"))
        {
            score++;
            Destroy(collision.transform.gameObject);
        }
    }
}
