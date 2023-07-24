using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagneticNet : MonoBehaviour
{
    public float magnetForce = 10f; // Çekme kuvveti, ihtiyaca göre ayarlanabilir.

    private int fishIndex;

    private void Awake()
    {
        /*fishIndex = GetComponent<FishController>().FishIndex;*/
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fish"))
        {
            // "fish" tagine sahip nesnenin "Net" nesnesine doğru yönelmesini sağlar.
            Vector3 direction = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce);
          
            StartCoroutine(KillFish(other.gameObject));

            int index = other.GetComponent<FishController>().FishIndex;


            if (index >= 0 && index < FishController.CollectFishList.Count)
            {
                FishController.CollectFishList[index]++;
            }



        }
    }
    IEnumerator KillFish(GameObject fishObject)
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(fishObject);

    }

}

