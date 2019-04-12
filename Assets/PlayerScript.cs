using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    enum State
    {
        MoveNorth,
        MoveSouth,
        MoveWest,
        MoveEast,
        Wait
    }

    public float speed = 15f;

    private State state;
    private bool lockActivity;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Wait;
        lockActivity = false;
    }

    void FixedUpdate()
    {
        if (!lockActivity)
        {
            lockActivity = true;

            if (Input.GetKeyDown("w"))
                state = State.MoveNorth;
            else if (Input.GetKeyDown("s"))
                state = State.MoveSouth;
            else if (Input.GetKeyDown("a"))
                state = State.MoveWest;
            else if (Input.GetKeyDown("d"))
                state = State.MoveEast;
            else
                lockActivity = false;
        }

        switch (state)
        {
            case State.MoveNorth:
                transform.position += Vector3.forward * speed * Time.deltaTime; break;
            case State.MoveSouth:
                transform.position += Vector3.back * speed * Time.deltaTime; break;
            case State.MoveEast:
                transform.position += Vector3.right * speed * Time.deltaTime; break;
            case State.MoveWest:
                transform.position += Vector3.left * speed * Time.deltaTime; break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            float fix = 0f;
            if (state == State.MoveEast || state == State.MoveNorth)
                fix = 0.5f;
            Debug.Log("Positions:\nx: " + transform.position.x + " y: " + transform.position.y + " z: " + transform.position.z);
            Debug.Log("Collided.");
            state = State.Wait;
            transform.position = new Vector3(Mathf.Round(transform.position.x - 0.1f - fix) + 0.5f, transform.position.y, Mathf.Round(transform.position.z - 0.1f - fix) + 0.5f);
            lockActivity = false;
        }
    }
}
