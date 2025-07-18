using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    private void FixedUpdate()
    {
        Move();
        if(Input.Getkey)
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical,0).normalized;
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
