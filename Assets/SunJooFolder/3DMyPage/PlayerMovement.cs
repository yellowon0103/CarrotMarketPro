using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {   
        //go back to sunjoo scene
        if(Input.GetKey(KeyCode.Q)){
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene("SunjooScene");
        }
        //logout and go back to sunjoo scene
        if(Input.GetKey(KeyCode.L)){
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            GameDataManager.Instance.ManageLogoutData();
            SceneManager.LoadScene("SunjooScene");
        }

        MyInput();
    }

    private void FixedUpdate() {
        MovePlayer();    
    }

    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f);
    }
}
