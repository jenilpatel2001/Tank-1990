using System.Collections;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    protected bool isMoving = false;

    // coroutine to move horizontal
    protected IEnumerator MoveHorizontal(float movementHorizontal, Rigidbody2D rigidbody)
    {
        isMoving = true;
        // poition of the gameobject
        transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        // rotation of gameobject & face direction towards movement
        Quaternion rotation = Quaternion.Euler(0, 0, -movementHorizontal * 90f);
        transform.rotation = rotation;


        float movementProgress = 0f;
        Vector2 movement;
        Vector2 endPos;

        while (movementProgress < Mathf.Abs(movementHorizontal))
        {
            //add speed to movement
            movementProgress += speed * Time.deltaTime;
            //clamp the movement progress value
            movementProgress = Mathf.Clamp(movementProgress, 0f, 1f);


            movement = new Vector2(speed * Time.deltaTime * movementHorizontal, 0f);
            endPos = rigidbody.position + movement;

            if (movementProgress == 1)
             endPos = new Vector2((endPos.x), endPos.y);
            rigidbody.MovePosition(endPos);

            yield return new WaitForFixedUpdate();
        }

        isMoving = false;
    }

    protected IEnumerator MoveVertical(float movementVertical, Rigidbody2D rb2d)
    {
        isMoving = true;

        transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        Quaternion rotation;

        if (movementVertical < 0)
        {
            rotation = Quaternion.Euler(0, 0, movementVertical * 180f);
        }
        else
        {
            rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.rotation = rotation;

        float movementProgress = 0f;
        Vector2 endPos, movement;

        while (movementProgress < Mathf.Abs(movementVertical))
        {

            movementProgress += speed * Time.deltaTime;
            movementProgress = Mathf.Clamp(movementProgress, 0f, 1f);

            movement = new Vector2(0f, speed * Time.deltaTime * movementVertical);
            endPos = rb2d.position + movement;

            if (movementProgress == 1) endPos = new Vector2(endPos.x, Mathf.Round(endPos.y));
            rb2d.MovePosition(endPos);
            yield return new WaitForFixedUpdate();

        }

        isMoving = false;

    }
}