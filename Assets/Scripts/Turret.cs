using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Turret attributes")]

    public float range = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup")]

    public string enemytag = "Enemy";
    public Transform partToRotate;
    public int lockSpeed = 5;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("GetTarget", 0f, 0.5f);
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;  // get direction to look at
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * lockSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        Debug.Log("Shoot !");
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if(bullet !=null)
        {
            bullet.Seek(target);
        }
    }

    void GetTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag); // stores all enemies in scene in the gameobject array

        float minDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            Debug.Log("distance to enemy : " + distanceToEnemy + "min distance : " + minDistance);

            if (distanceToEnemy < minDistance)
            {
                minDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && minDistance <= range)
        {
            target = nearestEnemy.transform;
        } 

        else
        {
            target = null;
        }

    }



    // Method to show in inspector range of a turret
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
