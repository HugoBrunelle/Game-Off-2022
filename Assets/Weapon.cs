using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D playergb;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Animator animator;

    private const float speed = 5f;
    [SerializeField] private float currentSpeed = 0f;
    [SerializeField] private bool shotRight = false;
    
    [SerializeField] private float shootDelay = 1f;
    [SerializeField] private float animationDelay = 0.5f;

    private bool isShooting = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            isShooting = true;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            animator.Play("Main-Shooting");

            Invoke("ShootStop", shootDelay);
            Invoke("AnimationStop", animationDelay);

            currentSpeed = speed;
            playergb.velocity = -transform.right * currentSpeed;
            shotRight = playergb.velocity.x > 0 ? true : false;
        }

        // Weapon Kickback
        if (playergb.velocity.x > 0 && shotRight)
        {
            playergb.velocity = -transform.right * currentSpeed;
            currentSpeed -= 0.1f;
        }
        else if (playergb.velocity.x < 0 && !shotRight)
        {
            playergb.velocity = -transform.right * currentSpeed;
            currentSpeed -= 0.1f;
        }
        else
        {
            playergb.velocity = transform.right * 0;
        }
    }

    void ShootStop()
    {
        isShooting = false;
    }

    void AnimationStop()
    {
        animator.Play("Player-Idle");
    }
}
