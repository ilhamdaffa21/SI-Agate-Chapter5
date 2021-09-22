using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{

    Collider2D[] inExplosionRadius = null;
    [SerializeField] private float ExplosionForceMulti = 5;
    [SerializeField] private float areaofeffect = 5;
    // Start is called before the first frame update

    private void Update()
    {

    }

    public void explosion()
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position, areaofeffect);

        foreach (Collider2D o in inExplosionRadius)
        {
            Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();
            if (o_rigidbody != null)
            {
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0)
                {
                    float ExplosionForce = ExplosionForceMulti / distanceVector.magnitude;
                    o_rigidbody.AddForce(distanceVector.normalized * ExplosionForce);
                }

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaofeffect);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Wood" || other.name == "Enemy")
        {
            explosion();
        }
    }
}
