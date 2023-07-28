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
            //"fish" tagine sahip nesnenin "Net" nesnesine doğru yönelmesini sağlar.
            Vector3 direction = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(direction.normalized * magnetForce);

            StartCoroutine(KillFishAndRespawnRandomFish(other.gameObject));


            if (!FishManager.Instance.CollectedFishList.Contains(other.gameObject))
            {
                FishManager.Instance.CollectedFishList.Add(other.gameObject);
            }
        }
    }
    IEnumerator KillFishAndRespawnRandomFish(GameObject fishObject)
    {
        yield return new WaitForSeconds(0.25f);

        fishObject.transform.DOScale(Vector3.zero, 0.3f).From(fishObject.transform.localScale);


        GameObject randomFishPrefab = FishManager.Instance.fish[Random.Range(0, FishManager.Instance.fish.Length)];

        Vector3 randomRotation = new Vector3(0f, Random.Range(0f, 360f), 0f);
        GameObject spawnedFish = Instantiate(randomFishPrefab, FishManager.Instance.GetSpawnPos(), Quaternion.Euler(randomRotation));

        spawnedFish.transform.DOScale(Vector3.zero, 0.3f).From().SetDelay(0.3f);
    }

}

