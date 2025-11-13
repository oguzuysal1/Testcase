using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int isGround = 0;
    public float jumpForce = 650;
    private float horizontalInput;
    public float speed = 5;
    public float bulletSpeed = 20;
    private int fire = 1;
    private int fireCooldown = 1;


    private Rigidbody2D PlayerRigidBody;
    private Animator PlayerAnimator;
    private ObjectPool ObjectPoolScript;
    private GameObject bulletForUse;
    public GameObject offSet;
    private Animator offSetAnimation;


    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        ObjectPoolScript = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        offSetAnimation = offSet.GetComponent<Animator>();

    }

    
    void Update()
    {
        movePlayer();
        fireBullet();

        PlayerAnimator.SetFloat("speed",Mathf.Abs(horizontalInput));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerAnimator.SetBool("jump",false);
            isGround = 1;
        }
        
    }

    private void movePlayer()
    {
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalInput > 0)
        {
            transform.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(transform.rotation == Quaternion.Euler(0, 180, 0))
        {

        }

        horizontalInput = Input.GetAxis("Horizontal");

        

        if (isGround == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnimator.SetBool("jump", true);
            PlayerRigidBody.AddForce(new Vector2(0,60), (ForceMode2D)ForceMode.Impulse);
            isGround = 0;
        }

        if (horizontalInput < 0)
        {
            transform.Translate(horizontalInput * Time.deltaTime * speed * Vector2.left);
        }
        else
        {
            transform.Translate(horizontalInput * Time.deltaTime * speed * Vector2.right);
        }

        
    }

    private void fireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && fire == 1)
        {
            offSetAnimation.SetTrigger("shot");
            bulletForUse = ObjectPoolScript.getObjectFromPool();

            Rigidbody2D bulletRigidBody = bulletForUse.GetComponent<Rigidbody2D>();
            bulletForUse.transform.rotation = offSet.transform.rotation;
            bulletForUse.transform.position = offSet.transform.position;

            bulletRigidBody.linearVelocity = bulletForUse.transform.right * bulletSpeed;
            

            StartCoroutine(waitForNextBullet());
            StartCoroutine(makeBulletInvisible(bulletForUse));
        }
    }

    IEnumerator makeBulletInvisible(GameObject bullet)
    {
        yield return new WaitForSeconds(4f);
        ObjectPoolScript.ReturnToPool(bullet);
    }

    IEnumerator waitForNextBullet()
    {
        fire = 0;
        yield return new WaitForSeconds(fireCooldown);
        fire = 1;

    }
}
