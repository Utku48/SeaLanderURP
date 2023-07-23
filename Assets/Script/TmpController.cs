using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class TmpController : MonoBehaviour
{
    public TextMeshProUGUI[] inventoryFishText;



    private void Update()
    {
        for (int i = 0; i < inventoryFishText.Length; i++)
        {
            inventoryFishText[i].text = "Count: " + FishController.CollectFishList[i];
        }
    }

}
