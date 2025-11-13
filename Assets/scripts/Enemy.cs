using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health = 3f;
    public float maxHealth = 3f;
    public int isDead = 0;
    public float enemySpeed = 0.2f;


    private HealthBar healthBar;

    private GameObject player;
    private Vector2 playerPosition;
    private Vector2 enemyPosition;
    void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.updateHealthBar(health, maxHealth);
        GameManager.instance.updateScore(0);

        player = GameObject.FindGameObjectWithTag("player");
       
    }

    
    void Update()
    {
        followPlayer();
    }

    public void takeDamage(int damageAmount)
    {

        health -= damageAmount;
        healthBar.updateHealthBar(health, maxHealth);

        if (health < 1)
        {
            GameManager.instance.updateScore(1);
            Destroy(gameObject);
        }
    }

    private void followPlayer(){
        playerPosition = player.transform.position;
        enemyPosition = transform.position;
        transform.position = Vector2.MoveTowards(enemyPosition, playerPosition, enemySpeed* Time.deltaTime);
    }

}
