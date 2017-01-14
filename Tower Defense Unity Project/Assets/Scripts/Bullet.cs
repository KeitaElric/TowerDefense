using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private Transform m_target;
    public GameObject BulletImpactEffectPrefap;

    public float speed = 70f;
    public float explosionRadius = 0f;

    public int damage = 50;
    public void Seek(Transform target)
    {
        this.m_target = target;
    }
	// Update is called once per frame
	void Update ()
    {
	    if(this.m_target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = this.m_target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
	}
    private void HitTarget()
    {
        GameObject BulletImpactEffectGameObject = (GameObject)Instantiate(BulletImpactEffectPrefap, transform.position, transform.rotation);
        Destroy(BulletImpactEffectGameObject, 2f);

        if (this.explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(this.m_target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(this.damage);
        }
    }
}
