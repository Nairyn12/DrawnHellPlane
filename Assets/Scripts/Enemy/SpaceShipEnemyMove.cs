using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipEnemyMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    public void MoveEnemyShips()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        
        if (transform.position.x >= 0)
        {
            _rb.AddForce(Vector2.left, ForceMode2D.Impulse);
        }
        else
        {
            _rb.AddForce(Vector2.right, ForceMode2D.Impulse);
        }
        Invoke("MoveEnemyShips", 3f);
    }

}
