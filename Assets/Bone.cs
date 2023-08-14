using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5;
    public GameObject fallingBone;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            RaycastHit2D raycast = Physics2D.Raycast(transform.position, Vector2.down);

            gameObject.transform.Rotate(0, 0, rotationSpeed);

            if (raycast.collider.CompareTag("Player")) {
                GameObject spawnedBone = Instantiate(fallingBone, transform.position, transform.rotation);
                spawnedBone.GetComponent<SpriteRenderer>().color = spriteRenderer.color;
                Object.Destroy(this.gameObject);
                //Do STUFF HERE TO DROP BONE
            }



    }
}
