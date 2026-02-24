using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private float moveX;
    private float moveY;

    public Rigidbody2D rb;

    public float speed;
    public float smoothValue;
    private Vector3 refVelocity;

    private void Update()
    {
        // Can change this later to be better and for co op

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }


    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(moveX, moveY, 0) * speed;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref refVelocity, smoothValue * Time.fixedDeltaTime);
    }
}
