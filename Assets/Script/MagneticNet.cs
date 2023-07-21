using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagneticNet : MonoBehaviour
{
    public float magnetForce = 10f; // Çekme kuvveti, ihtiyaca göre ayarlanabilir.


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("fish"))
        {
            // "fish" tagine sahip nesnenin "Net" nesnesine doğru yönelmesini sağlar.
            Vector3 direction = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce);
            StartCoroutine(KillFish(other.gameObject));

        }
    }
    IEnumerator KillFish(GameObject fishObject)
    {
        yield return new WaitForSeconds(0.45f);

        Destroy(fishObject);

    }

}

