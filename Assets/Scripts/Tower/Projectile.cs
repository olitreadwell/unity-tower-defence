using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;

    [Header("Projectile Attributes")]
    public float projectileSpeed = 2f;
    public float projectileDamage = 10f;

    public GameObject shotEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // set the speed and direction of the projectile
        ShootProjectile();
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the projectile hit an enemy
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(projectileDamage);
        }

        // Debug.Log("Projectile hit: " + other.name);
        GameObject newShotEffect = Instantiate(shotEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void ShootProjectile()
    { 
        rb.velocity = transform.forward * projectileSpeed;
    }
}
