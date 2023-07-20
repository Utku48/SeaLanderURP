using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FishManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fish;

    [SerializeField] private Transform[] area;




    private void Awake()
    {
        float MaxX = area[0].transform.position.x;
        float MinX = area[1].transform.position.x;

        float MaxZ = area[2].transform.position.z;
        float MinZ = area[3].transform.position.z;


        for (int i = 0; i < fish.Length; i++)
        {
            float randomX = Random.Range(MinX, MaxX);
            float randomZ = Random.Range(MinZ, MaxZ);

            GameObject obj = Instantiate(fish[i], new Vector3(randomX, -0.5f, randomZ), Quaternion.identity);

            GameObject sameObject = GameObject.Find("Catfish0(Clone)");
            GameObject sameObject1 = GameObject.Find("Walleye3(Clone)");

            if (sameObject != null)
            {
                sameObject.GetComponent<FishController>().fishIndex = obj.GetComponent<FishController>().fishIndex;

            }
            else if (sameObject1 != null)
            {
                sameObject1.GetComponent<FishController>().fishIndex = obj.GetComponent<FishController>().fishIndex;
            }
            else
                obj.GetComponent<FishController>().fishIndex = i;
        }


    }

}
