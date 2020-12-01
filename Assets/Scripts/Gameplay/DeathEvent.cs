using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEvent : MonoBehaviour
{
    public GameObject explosionParticle;

    void Update()
    {
        //if (Time.realtimeSinceStartup > 40f)
        //{
        //    Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        //    GameObject explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        //    explosion.transform.parent = this.transform;

        //    foreach (Collider hit in colliders)
        //    {
        //        Rigidbody rb = hit.GetComponent<Rigidbody>();

        //        if (rb != null)
        //            rb.AddExplosionForce(1f, transform.position, 3f, 5f);

        //    }
        //}

        //if (Time.realtimeSinceStartup > 50f)
        //{
        //    GameManager.Singleton.ChangeScene("Level_01");
        //    Destroy(this.gameObject);
        //}
    }

    private void TriggerEnter(Collision collision)
    {
        Debug.LogWarning("AAAAAAAAAAAAH");
    }
}
