
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //For Movement
    public float jumpForce;
    public Rigidbody2D Rigidbody;
    public Animator animator;

    private Vector2 lastDirection;

    [SerializeField]
    private AudioClip leapSound;

    private Collider2D collisionBox;



    private Vector2 still = new Vector2(0, 0);
    private int wallLayerMask;

    void Start()
    {
        collisionBox = GetComponent<Collider2D>();
        wallLayerMask = LayerMask.GetMask("Walls");
    }

    private void FixedUpdate()
    {

        if (Rigidbody.velocity == still)
        {
            animator.ResetTrigger("Up");
            animator.ResetTrigger("Down");
            animator.ResetTrigger("Right");
            animator.ResetTrigger("Left");

            if (lastDirection == new Vector2(0, 1))
            {
                animator.SetTrigger("Up");
            }
            else if (lastDirection == new Vector2(0, -1))
            {
                animator.SetTrigger("Down");
            }
            else if (lastDirection == new Vector2(1, 0))
            {
                animator.SetTrigger("Right");
            }
            else
            {
                animator.SetTrigger("Left");
            }
            animator.SetBool("Moving", false);






        }
    }


    public void Leap(Vector2 direction)
    {


        if (Rigidbody.velocity.normalized * -1 != direction)
        {
            
            

            RaycastHit2D raycast = Physics2D.Raycast(transform.position, direction, collisionBox.bounds.extents.y + 0.1f, wallLayerMask);
            if (!raycast || animator.GetBool("Moving"))
            {
                animator.SetBool("Moving", true);
                //Rotate Player
                //down
                if (direction == new Vector2(0, -1))
                {
                    gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * 0);

                }
                //right
                else if (direction == new Vector2(1, 0))
                {
                    gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * 90);

                }
                //up
                else if (direction == new Vector2(0, 1))
                {
                    gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * 180);


                }
                //left
                else if (direction == new Vector2(-1, 0))
                {
                    gameObject.transform.rotation = Quaternion.Euler(Vector3.forward * 270);

                }
            }
            Rigidbody.velocity = new Vector2(direction.x * jumpForce, direction.y * jumpForce);
            lastDirection = direction;
            if (leapSound) ControllerScript.Controller.PlaySound(leapSound);
        }


    }
}
