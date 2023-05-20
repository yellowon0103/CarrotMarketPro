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
            _cc.Move(5 * data.direction * Runner.DeltaTime);

            if (data.direction.sqrMagnitude > 0)
                _forward = data.direction;
        }
    }
}
