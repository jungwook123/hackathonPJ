using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10;
    private Rigidbody2D rb;
    private Animator myAnim;
    private Vector2Int dir;
    public Vector2Int lastDir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        Move();
        //if(Input.Getkey)
    }

    private void MoveAnim()
    {
         myAnim.SetFloat("moveX", rb.linearVelocity.x);
        myAnim.SetFloat("moveY",rb.linearVelocity.y);
        dir.x = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        dir.y = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));
        if(dir.x == 1 | dir.x == -1 || dir.y == 1 || dir.y== -1)
        {
            lastDir = dir;
            myAnim.SetFloat("LastX", dir.x);
            myAnim.SetFloat("LastY", dir.y);
            
        }
    }
    private void Move()
    {
        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
        MoveAnim();
        
    }
}
