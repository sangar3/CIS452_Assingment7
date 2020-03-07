using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Stats")]
    public float fireRate = 1f; //firing a bullet every sec
    private float firecountdown = 0f;
    public float range = 15f;
    public float turretTurnspeed = 10f;

    [Header("Fields")]
    public string enemytag = "Enemy";
    public Transform partToRotate;
    public GameObject bulletprefab;
    public Transform firepoint;
    public AudioClip playershootingsfx;




    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }
    
    
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if( distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                nearestEnemy = enemy;

            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;

        }
        else
        {
            target = null;
        }
    }


    void Update()
    {
        if(target == null)
        {
            return;
        }
        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turretTurnspeed).eulerAngles; //converting Quaternion to euler angles and smooth turning 
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y, 0f); //rotating around y-axis


        if(firecountdown <= 0f)
        {
            Shoot();
            firecountdown = 1f / fireRate;
        }
        firecountdown -= Time.deltaTime;
    }


    void Shoot()
    {
        Debug.Log("Shoot");
        AudioManager.Instance.PlaySFX(playershootingsfx, 3.0f);
        GameObject bulletGO = (GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
