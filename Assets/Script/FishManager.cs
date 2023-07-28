using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FishManager : MonoBehaviour
{
    public static FishManager Instance { get; private set; }

    public GameObject[] fish;
    public Transform[] area;

    private List<GameObject> activeFish = new List<GameObject>();

    public List<GameObject> CollectedFishList = new List<GameObject>();
    public float rotationSpeed = 10f;

    private void Awake()
    {
        SpawnFish();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void SpawnFish()
    {
        for (int i = 0; i < fish.Length; i++)
        {
            Vector3 randomRotation = new Vector3(0f, Random.Range(0f, 360f), 0f); // Sadece y ekseninde rastgele bir rotasyon oluşturuyoruz

            GameObject obj = Instantiate(fish[i], GetSpawnPos(), Quaternion.Euler(randomRotation));
            activeFish.Add(obj);
        }
    }


    public Vector3 GetSpawnPos()
    {
        float MaxX = area[0].transform.position.x;
        float MinX = area[1].transform.position.x;

        float MaxZ = area[2].transform.position.z;
        float MinZ = area[3].transform.position.z;

        float randomX = Random.Range(MinX, MaxX);
        float randomZ = Random.Range(MinZ, MaxZ);

        Vector3 pos = new Vector3(randomX, -0.8f, randomZ);

        return pos;
    }

}
