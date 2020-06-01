using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    Vector2 targetSpeed;
    Transform targetTransform;
    float rotationSpeed;

    public GameObject projectile;
    bool canFire = true;
    public float defaultFireRate;
    float currentFireRate;
    public GameObject firePoint;


    void Start()
    {
        rotationSpeed = 50;
    }

    void Update()
    {
        targetSpeed = player.GetComponent<PlayerController>().currentSpeed;
        targetTransform = player.transform;

        //Vector2 targetPos = new Vector2(targetTransform.position.x * targetSpeed, targetTransform.position.y * targetSpeed);
        Vector2 targetPos = targetSpeed;
        Vector2 faceDir = player.transform.position - transform.position;
        faceDir += targetPos;
        float angle = Mathf.Atan2(faceDir.y, faceDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        if (currentFireRate <= 0 && canFire == true)
        {
            projectile.GetComponent<Projectile>().origin = gameObject;
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
            currentFireRate = defaultFireRate;
        }
        else
        {
            currentFireRate -= Time.deltaTime;
        }
    }
}
