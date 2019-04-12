using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed = 15f;

    private float movementTimeStart;
    private Vector3 source;
    private Vector3 destination;
    private bool lockActivity;

    // Start is called before the first frame update
    void Start()
    {
        lockActivity = false;
        destination = transform.position;
        source = transform.position;
        movementTimeStart = Time.time;
    }

    private void Update()
    {
        if (!lockActivity)
        {
            lockActivity = true;
            source = transform.position;
            movementTimeStart = Time.time;

            if (Input.GetKeyDown("w"))
            {
                destination = GameController.Move(transform.position, Vector2.up);
            }
            else if (Input.GetKeyDown("s"))
            {
                destination = GameController.Move(transform.position, Vector2.down);
            }
            else if (Input.GetKeyDown("a"))
            {
                destination = GameController.Move(transform.position, Vector2.left);
            }
            else if (Input.GetKeyDown("d"))
            {
                destination = GameController.Move(transform.position, Vector2.right);
            }
            else
                lockActivity = false;
        }
    }

    void FixedUpdate()
    {
        if (transform.position != destination)
        {
            float distanceCovered = (Time.time - movementTimeStart) * speed;
            transform.position = Vector3.Lerp(source, destination, distanceCovered / Vector3.Distance(source, destination));
        }
        else
            lockActivity = false;
    }
}
