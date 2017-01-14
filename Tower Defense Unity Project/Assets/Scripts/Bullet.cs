using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private Transform m_target;
    public GameObject BulletImpactEffectPrefap;

    public float speed = 70f;
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
        Destroy(this.m_target.gameObject);
        Destroy(gameObject);
    }
}
