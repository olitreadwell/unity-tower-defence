using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;

    [Header("Projectile Attributes")]
    public float projectileSpeed = 20f;
    public float projectileDamage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // set the speed and direction of the projectile
        ShootProjectile();
    }

    private void OnTriggerEnter(Collider other)
    {

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
