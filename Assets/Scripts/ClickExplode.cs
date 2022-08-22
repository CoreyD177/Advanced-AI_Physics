using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickExplode : MonoBehaviour
{
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosiveForce;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Collider[] withinExplosion = Physics.OverlapSphere(hit.point, _explosionRadius);


                foreach (Collider c in withinExplosion)
                {
                    Rigidbody rb;
                    if (!c.TryGetComponent<Rigidbody>(out rb))
                    {
                        continue;
                    }
                    Vector3 direction = (c.transform.position - hit.point).normalized;
                    direction *= _explosiveForce;
                    rb.AddForce(direction, ForceMode.Impulse);
                }
            }
        }
    }
}
