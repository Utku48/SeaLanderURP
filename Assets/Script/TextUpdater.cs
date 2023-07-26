using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    private TMP_Text componentText => GetComponent<TMP_Text>();
    public FishType fishtype;
    private void Update()
    {
        var a = FishManager.Instance.CollectedFishList.Select(x => x.GetComponent<FishController>()).Where(x => x.FishType == fishtype).ToList();
        componentText.text = a.Count.ToString();

    }
}
