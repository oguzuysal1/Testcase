using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageableobject = other.GetComponent<IDamageable>();

        if (damageableobject != null) { 
            damageableobject.takeDamage(damage);
        }

        gameObject.SetActive(false);
    }

}
