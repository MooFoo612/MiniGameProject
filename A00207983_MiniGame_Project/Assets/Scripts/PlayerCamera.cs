using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject camTarget;
    public Vector3 cameraPosition = new Vector3(0,0,-1);

    // Start is called before the first frame update
    void Start()
    {      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (camTarget) {
            transform.position = new Vector3(
                camTarget.transform.position.x + cameraPosition.x,
                camTarget.transform.position.y + cameraPosition.y,
                camTarget.transform.position.z + cameraPosition.z
            );
        }
    }
}
