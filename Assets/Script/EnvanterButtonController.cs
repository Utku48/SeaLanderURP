using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvanterButtonControllere : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    bool inventroyOn = false;

    private void Start()
    {
        inventory.SetActive(false);
    }
    public void On_Click()
    {
        inventory.SetActive(true);
        inventroyOn = true;
    }


}
