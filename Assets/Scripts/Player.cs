using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed;

    [SerializeField]
    private float AccelerationMove;

    [SerializeField]
    private float JumpPower;

    private bool isGround;

    private Rigidbody2D PlayerRb;

    private void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            PlayerRb.velocity = new Vector2(MoveSpeed * Time.fixedDeltaTime * AccelerationMove, PlayerRb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            PlayerRb.velocity = new Vector2(MoveSpeed * Time.fixedDeltaTime * -AccelerationMove, PlayerRb.velocity.y);
        }

        if(Input.GetKey(KeyCode.Space) && isGround)
        {
            PlayerRb.AddForce(new Vector2(PlayerRb.velocity.x, JumpPower), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
