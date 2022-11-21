using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Animator animator;

    [SerializeField] private float shootDelay = 2f;
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
