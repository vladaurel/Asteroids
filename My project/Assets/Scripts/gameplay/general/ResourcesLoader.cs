/**
This class is a centralized point for loading resources - 
be it an image, an object, etc. 

I normally wouldn't use Resources.Load, however I'm using it for now as I'm in a bit of a hurry.

Other methods I would use are :
- linking the prefabs directly on objects on the stage ( I usually never do that, even with UI - this time I'm in a bit of a rush )
- asset bundles ( I do this most often ) 
- addressables ( rare case to be frank ) 


*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoader : MonoBehaviour
{
    #region loading 
    // Return a regular prefab
    public GameObject CreateAndReturnGameObject(string prefabName)
    {
        return Instantiate(Resources.Load(prefabName) as GameObject);
    }



    // Return a gameobject that is a UI menu 
    /**
    public GameObject CreateAndReturn_UI_Menu(string menuName, string location = "default")
    {
        string completeName = menuName;
        if (location != "default")
        {
            completeName = location + menuName;
            // Debug.Log(completeName + "| COMPLETE MENU NAME - flag 2");
            return Instantiate(Resources.Load(completeName) as GameObject);
        }

        // Debug.Log("Menus/"+completeName + "| COMPLETE MENU NAME - flag 1");
        return Instantiate(Resources.Load("Menus/" + completeName) as GameObject);
    }*/


    // Return just an image 
    /**
    public Sprite ReturnSprite(string spriteName, string location = "default")
    {
        if(location != default)
        {
            spriteName = location + spriteName;
        }
        return Resources.Load<Sprite>("sprites/"+spriteName);
    }*/
    #endregion loading 
}
