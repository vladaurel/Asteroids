using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBaseMenu : MonoBehaviour
{
    #region variables 
    public string menuName = "none";
    #endregion variables 


    #region functionality 
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void DeActivate()
    {
        gameObject.SetActive(false);
    }
    #endregion functionality 

}
