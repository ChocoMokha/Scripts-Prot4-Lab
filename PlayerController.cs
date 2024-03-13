using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb; 
    public float horizontalInput;
    public float speed = 10.0f;
    public float jumpForce = 6.0f;
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void Update()
    {
        //Movement controls

        if(!gameOver){

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
            if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Box")){
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy")){
            isOnGround = false;
            gameOver = true;
            Destroy(gameObject);
        }
    }
}
