using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMoveController : MonoBehaviour
{
    [SerializeField] private float speedTarget;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.3f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speedTarget * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -4.3f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speedTarget * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.1f)
        {
            transform.position = new Vector2(transform.position.x - speedTarget * Time.deltaTime, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 8.1f)
        {
            transform.position = new Vector2(transform.position.x + speedTarget * Time.deltaTime, transform.position.y);
        }
    }
}
