/**
This class is a centralized point for loading resources - 
be it an image, an object, etc. 

I normally wouldn't use Resources.Load, however I'm using it for now as I'm in a bit of a hurry.
 - I would normally use - Addressables, Scriptable Objects .

What I am doing and wouldn't do.
- linking the prefabs directly on objects on the stage ( I usually never do that, even with UI - this time I'm in a bit of a rush )
- other uncommon practices. 

*/
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ResourcesLoader : MonoBehaviour
{
    #region loading 
    public async Task<GameObject> CreateAndReturnGameObject(string prefabLocation)
    {
        prefabLocation = "Assets/Addressables/Prefabs/" + prefabLocation+".prefab";
        GameObject prefab = await Addressables.LoadAssetAsync<GameObject>(prefabLocation).Task;
        if (prefab != null)
        {
            return Instantiate(prefab);
        }
        else
        {
            Debug.LogError($"Failed to load prefab from {prefabLocation}");
            return null;
        }
    }

    public async Task<GameObject> ReturnPrefab(string prefabLocation)
    {
        prefabLocation = "Assets/Addressables/Prefabs/" + prefabLocation+".prefab";

        GameObject prefab = await Addressables.LoadAssetAsync<GameObject>(prefabLocation).Task;
        if (prefab != null)
        {
            return prefab;
        }
        else
        {
            Debug.LogError($"Failed to load prefab from {prefabLocation}");
            return null;
        }
    }


    /**
    // Return a regular prefab
    public GameObject CreateAndReturnGameObject(string prefabLocation)
    {
        // Debug.Log("PREFAB LOCATION -------------- : " + prefabLocation);
        return Instantiate(Resources.Load(prefabLocation) as GameObject);
    }


    public GameObject ReturnPrefab(string prefabLocation)
    {
        // Debug.Log("PREFAB LOCATION : "+prefabLocation);
        return Resources.Load(prefabLocation) as GameObject;
    }
    */

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
        if(location != "default")
        {
            spriteName = location + spriteName;
        }
        return Resources.Load<Sprite>("sprites/"+spriteName);
    }*/
    #endregion loading 
}
