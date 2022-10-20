using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ResetSaveMenuItem : MonoBehaviour
{
    [MenuItem("Reset/Reset Save")]
    static void ResetSaveMethod()
    {
        LoadData dataGo = new LoadData();
        dataGo.CreateNewProfile("default");
    }

}
