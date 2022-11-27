using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMama : MonoBehaviour
{
    public float Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHurt(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
