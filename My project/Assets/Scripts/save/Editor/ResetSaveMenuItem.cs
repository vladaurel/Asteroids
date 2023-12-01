#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Profile.SaveAndLoad
{
    public class ResetSaveMenuItem : MonoBehaviour
    {
        [MenuItem("Reset/Reset Save")]
        static void ResetSaveMethod()
        {
            LoadData dataGo = new LoadData();
            dataGo.CreateNewProfile("default");
        }
    }
}
#endif
