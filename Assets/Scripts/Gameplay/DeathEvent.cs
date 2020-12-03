using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEvent : MonoBehaviour
{
    public GameObject explosionParticle;

    void OnCollisionEnter(Collision col)
    {
        PlayerController.isPlayerAlive = false;
        MusicController.pleaseDontStopTheMusic = false;

        //Time.timeScale = 0.3f;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, 30f);
        GameObject explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        explosion.transform.parent = this.transform;

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddExplosionForce(200f, transform.position, 50f, 50f);
            }             
        }

        Destroy(this.gameObject, 0.5f);
    }
}
