
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //For Movement
    public float jumpForce;
    public Rigidbody2D Rigidbody;
    public Animator animator;



    private Vector2 still = new Vector2(0, 0);

    private void FixedUpdate() {
        if (Rigidbody.velocity == still) {
            animator.SetBool("Moving",false);
        }
        else {
            animator.SetBool("Moving",true);
        }
    }
    

    public void Leap(Vector2 direction)
    {

        Rigidbody.velocity = new Vector2(direction.x * jumpForce, direction.y * jumpForce);
    }
}
