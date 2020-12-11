using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraTouchMovement : MonoBehaviour
{
    Touch touch;

    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    public Joystick JS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.touchCount > 0 && JS.Direction == Vector2.zero)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = -(touch.position - startPos).normalized;

                    transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }

        else
        {
            transform.position += new Vector3(-JS.Direction.x, -JS.Direction.y, 0) * Time.deltaTime;
        }
    }
}
