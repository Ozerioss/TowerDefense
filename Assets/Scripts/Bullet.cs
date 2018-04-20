using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update ()
    {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

	}


    void HitTarget()
    {
        Debug.Log("Hit ! ");
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, .5f); // Destroys the effect after 1 second

        Destroy(target.gameObject); // temp destroy enemy

        Destroy(gameObject); // Destroys the bullet
    }
}
