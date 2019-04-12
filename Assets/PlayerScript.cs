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

    public float speed = 2f;

    private State state = State.Wait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
            state = State.MoveNorth;
        else if (Input.GetKeyDown("s"))
            state = State.MoveSouth;
        else if (Input.GetKeyDown("a"))
            state = State.MoveWest;
        else if (Input.GetKeyDown("d"))
            state = State.MoveEast;

        if (state == State.MoveNorth)
            transform.position += Vector3.forward * speed * Time.deltaTime;
        else if(state == State.MoveSouth)
            transform.position += Vector3.back * speed * Time.deltaTime;
        else if (state == State.MoveWest)
            transform.position += Vector3.left * speed * Time.deltaTime;
        else if (state == State.MoveEast)
            transform.position += Vector3.right * speed * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        float fix = 0f;
        if (state == State.MoveEast || state == State.MoveNorth)
            fix = 0.5f;
        Debug.Log("Positions:\nx: " + transform.position.x + " y: " + transform.position.y + " z: " + transform.position.z);
        Debug.Log("Collided.");
        state = State.Wait;
        transform.position = new Vector3(Mathf.Round(transform.position.x - 0.1f - fix) + 0.5f, transform.position.y, Mathf.Round(transform.position.z - 0.1f - fix) + 0.5f);
    }
}
