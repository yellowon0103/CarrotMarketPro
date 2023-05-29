using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class NetworkCharacterMovementHandler : NetworkBehaviour
{
    NetworkCharacterControllerPrototypeCustom _cc;

    private Vector3 _forward;

    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterControllerPrototypeCustom>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            Vector3 moveDirection = transform.forward * data.direction.z + transform.right * data.direction.x;
            moveDirection = moveDirection.normalized;
            _cc.Move(5 * moveDirection * Runner.DeltaTime);

            // Apply rotation to the camera or parent GameObject
            float rotationY = data.rotationY;
            _cc.transform.Rotate(0f, rotationY, 0f, Space.Self);

            /*
            if (data.direction.sqrMagnitude > 0)
                _forward = data.direction;
            */
        }
    }
}
