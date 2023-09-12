using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy : MonoBehaviour

{

    [SerializeField]
    private int pointValue = 200;

    [SerializeField]
    private bool startColorIsA = true;

    GameObject player;
    private SpriteRenderer playerSpriteRenderer;
    private PlayerColorChange playerColorChange;

    [SerializeField]
    private SpriteRenderer spriteRendererToColor;

    private Color enemyColor;
    private Color corpseColor = Color.white;

    [SerializeField]
    private Sprite leftCorpse;
    [SerializeField]
    private Sprite rightCorpse;

    private Light2D associatedLight;
    private ParticleSystem ps;

    private Rigidbody2D playerRB;

    private bool isColliding = false;

    [SerializeField]
    private AudioClip deathSound;






    // Start is called before the first frame update
    void Start()
    {

        associatedLight = GetComponentInChildren<Light2D>();
        ps = GetComponentInChildren<ParticleSystem>();

        player = GameObject.FindWithTag("Player");


        if (player != null)
        {
            playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
            playerColorChange = player.GetComponent<PlayerColorChange>();
            playerRB = player.GetComponent<Rigidbody2D>();
        }


        if (startColorIsA)
        {
            enemyColor = playerColorChange.colorA;
        }
        else
        {
            enemyColor = playerColorChange.colorB;
        }

        if (!spriteRendererToColor)
        {
            spriteRendererToColor = GetComponent<SpriteRenderer>();
            corpseColor = enemyColor;
        }

        spriteRendererToColor.color = enemyColor;
        associatedLight.color = enemyColor;
        if (ps)
        {

            ParticleSystem.MainModule mainModule = ps.main;
            mainModule.startColor = enemyColor;
        }

    }

    private void FixedUpdate()
    {
        if (isColliding)
        {
            if (playerSpriteRenderer.color != spriteRendererToColor.color)
            {
                ControllerScript.Controller.GameOver();
            }
            else if (playerRB.velocity != new Vector2(0, 0))
            {
                if (deathSound) ControllerScript.Controller.PlaySound(deathSound);
                Object.Destroy(this.gameObject);
                ControllerScript.Controller.IncreaseScore(pointValue);

                GameObject Rubble = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation, transform.localScale);
                if (Rubble) Rubble.GetComponent<Rubble>().SetAttributes(leftCorpse, corpseColor, new Vector2((Mathf.Sign(transform.localScale.x) * -200), 300));
                GameObject Rubble2 = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation, transform.localScale);
                if (Rubble2) Rubble2.GetComponent<Rubble>().SetAttributes(rightCorpse, corpseColor, new Vector2((Mathf.Sign(transform.localScale.x) * 200), 300));

                GameObject blood = PoolManager.PullWithoutRotation("Blood", transform.position);
                if (blood) blood.GetComponent<BloodScript>().Splatter();
            }
        }
    }

    // private void OnCollisionEnter2D(Collider2D other)
    // {

    //     if (other.gameObject.CompareTag("Player"))
    //     {

    //         if (playerSpriteRenderer.color != spriteRendererToColor.color)
    //         {
    //             ControllerScript.Controller.GameOver();
    //         }
    //         else if (playerRB.velocity != new Vector2(0, 0))
    //         {
    //             Object.Destroy(this.gameObject);
    //             ControllerScript.Controller.IncreaseScore(pointValue);

    //             GameObject Rubble = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation, transform.localScale);
    //             if (Rubble) Rubble.GetComponent<Rubble>().SetAttributes(leftCorpse, corpseColor, new Vector2((Mathf.Sign(transform.localScale.x) * -200), 300));
    //             GameObject Rubble2 = PoolManager.PullFromPool("Rubble", transform.position, transform.rotation, transform.localScale);
    //             if (Rubble2) Rubble2.GetComponent<Rubble>().SetAttributes(rightCorpse, corpseColor, new Vector2((Mathf.Sign(transform.localScale.x) * 200), 300));

    //             GameObject blood = PoolManager.PullWithoutRotation("Blood", transform.position);
    //             if (blood) blood.GetComponent<BloodScript>().Splatter();
    //         }

    //     }
    // }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }





    private void OnDrawGizmos()
    {
        if (startColorIsA)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.magenta;
        }
        Gizmos.DrawWireSphere(transform.position, 1f);

    }
}
