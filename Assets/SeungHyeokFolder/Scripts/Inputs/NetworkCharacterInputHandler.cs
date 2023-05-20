using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCharacterInputHandler : MonoBehaviour
{
    Vector3 moveInputVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInputVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveInputVector += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            moveInputVector += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            moveInputVector += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            moveInputVector += Vector3.right;
    }

    public NetworkInputData GetNetworkInput()
    {
        NetworkInputData networkInputData = new NetworkInputData();

        networkInputData.direction = moveInputVector;

        return networkInputData;
    }
}
