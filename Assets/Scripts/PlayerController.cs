using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float tilt;  // to rotate the player when turn left or right

    // Update after everything is done
    void FixedUpdate () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizotal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizotal, 0.0f, moveVertical);

        // change the player components of velocity (speed), boundary position and its rotation in respect of z axis when turn left or right (x axis)
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * (-tilt));
    }
}
