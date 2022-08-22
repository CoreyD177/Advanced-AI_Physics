using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour
{
    private void OnCollisionEnter(Collision collider)
    {
        if (!collider.collider.CompareTag("Ground"))
        {
            GameObject ragdoll = GameObject.Find("RagDoll");
            Rigidbody[] rigidbodies = ragdoll.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
            StartCoroutine(DisableColliding(ragdoll));
        }
    }
    private IEnumerator DisableColliding(GameObject ragdoll)
    {
        yield return new WaitForSecondsRealtime(0.05f);
        ragdoll.GetComponent<CapsuleCollider>().enabled = false;
    }
}
