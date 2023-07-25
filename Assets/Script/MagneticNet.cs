using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagneticNet : MonoBehaviour
{
    public float magnetForce = 10f; // Çekme kuvveti, ihtiyaca göre ayarlanabilir.

    private int fishIndex;


    public void Awake()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fish"))
        {
            // "fish" tagine sahip nesnenin "Net" nesnesine doğru yönelmesini sağlar.
            Vector3 direction = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce);

            StartCoroutine(KillFishAndRespawnRandomFish(other.gameObject));

            int index = other.GetComponent<FishController>().FishIndex;


            if (index >= 0 && index < FishController.CollectFishList.Count)
            {
                FishController.CollectFishList[index]++;
            }


        }
    }
    IEnumerator KillFishAndRespawnRandomFish(GameObject fishObject)
    {
        yield return new WaitForSeconds(0.25f);

        fishObject.transform.DOScale(Vector3.zero, 0.3f).From(fishObject.transform.localScale);


        GameObject randomFishPrefab = FishManager.Instance.fish[Random.Range(0, FishManager.Instance.fish.Length)];

        GameObject spawnedFish = Instantiate(randomFishPrefab, FishManager.Instance.GetSpawnPos(), Quaternion.identity);

        spawnedFish.transform.DOScale(Vector3.zero, 0.3f).From().SetDelay(0.3f);
    }

}

