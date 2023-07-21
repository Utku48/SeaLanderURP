using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İnventoryButtonController : MonoBehaviour
{
    public GameObject panel;

    public void On_Off_Panel()
    {
        panel.SetActive(!panel.activeSelf);
    }

}
