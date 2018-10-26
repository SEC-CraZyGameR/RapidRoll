using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveDirection;
    private float inputDirection;
    float verticalVelocity = 0;
    private float gravity = 11.0f;
    private float speed = 5.0f;
    public static int health = 3;
    public GameObject lifeEffect;
    public GameObject deadEffect;
    public Text healthNumer;
    public GameObject DeathPanel;
    public bool gameEnd = false;
    public CameraMovement cm;
	void Start () {
        healthNumer.text = health.ToString();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        moveDirection = Vector3.zero;
        inputDirection = Input.GetAxis("Horizontal") * speed;

        if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > Screen.width / 2)
                {
                    inputDirection = 3.5f;
                }
                if (Input.mousePosition.x < Screen.width / 2)
                {
                    inputDirection = -3.5f;
                }
            }
        

        moveDirection.x = inputDirection;
        if (!controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        else
            verticalVelocity = 0.0f;
        moveDirection.y = verticalVelocity;
        if(cm.startDeleteTile)
            controller.Move(moveDirection * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dead"))
        {
            health--;
            if(health<=0)
            {
                healthNumer.text = health.ToString();
                GameEnd();
                return;
            }
            healthNumer.text = health.ToString();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(other.CompareTag("life"))
        {
            if (health < 5)
            {
                health++;
                healthNumer.text = health.ToString();
            }
            Instantiate(lifeEffect, transform.position, Quaternion.identity);
            //Debug.Log(health);
            Destroy(other.gameObject);
        }
    }
    void GameEnd()
    {
        health = 3;
        gameEnd = true;
        Destroy(gameObject);
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        
    }
    
   
}
