using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;

    public int Health = 100;
    public int value = 50;
    public GameObject deathEffect;

	private Transform target;
	private int wavepointIndex = 0;

	void Start ()
	{
		target = Waypoints.points[0];
	}

    public void TakeDamage(int amount)
    {
        this.Health -= amount;

        if (this.Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

	void Update ()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
            EndPath();
            return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

    void EndPath()
    {
        if (PlayerStats.Lives > 0)
        {
            PlayerStats.Lives--;
        }
        Destroy(gameObject);
    }
}
