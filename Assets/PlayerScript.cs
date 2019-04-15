using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float speed = 15f;


    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    private float movementTimeStart;
    private Vector3 source;
    private Vector3 destination;
    private bool lockActivity;
    private Animator animator;
    private Direction direction;


    // Start is called before the first frame update
    void Start()
    {
        lockActivity = false;
        destination = transform.position;
        source = transform.position;
        movementTimeStart = Time.time;
        animator = gameObject.GetComponentInChildren<Animator>();
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
                direction = Direction.Up;
            }
            else if (Input.GetKeyDown("s"))
            {
                destination = GameController.Move(transform.position, Vector2.down);
                direction = Direction.Down;
            }
            else if (Input.GetKeyDown("a"))
            {
                destination = GameController.Move(transform.position, Vector2.left);
                direction = Direction.Left;
            }
            else if (Input.GetKeyDown("d"))
            {
                destination = GameController.Move(transform.position, Vector2.right);
                direction = Direction.Right;
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
            if (transform.position == destination)
            {
                switch (direction)
                {
                    case Direction.Up:
                        animator.SetTrigger("HitUpTrigger");
                        break;
                    case Direction.Down:
                        animator.SetTrigger("HitDownTrigger");
                        break;
                    case Direction.Left:
                        animator.SetTrigger("HitLeftTrigger");
                        break;
                    case Direction.Right:
                        animator.SetTrigger("HitRightTrigger");
                        break;
                }

            }
        }
        else
            lockActivity = false;
    }
}
