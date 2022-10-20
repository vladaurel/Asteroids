using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    #region 
    public List<GameObject> projectiles1Pool = new List<GameObject>();
    public List<GameObject> projectiles2Pool = new List<GameObject>();
    #endregion


    #region 
    public GameObject ReturnProjectileType(int type)
    {
        List<GameObject> listToUse;
        switch(type)
        {
            case 1: listToUse = projectiles1Pool; break;
            case 2: listToUse = projectiles2Pool; break;
            default: listToUse = projectiles2Pool; break;
        }

        if (listToUse.Count>0)
        {
            GameObject projectileToReturn = listToUse[0];
            listToUse.RemoveAt(0);
            projectileToReturn.GetComponent<BaseProjectile>().ReadyForReuse();
            return projectileToReturn;
        } else {
            GameObject projectile;
            switch(type)
            {
                // 
                case 1: projectile = Instantiate(StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/BasicProjectile")); break;
                case 2: projectile = Instantiate(StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/MoonProjectile"));  break;
                default: projectile = Instantiate(StateMachineAsteroids.RESOURCE_LOADER.ReturnPrefab("prefabs/BasicProjectile")); break;
            }
            return projectile;
        }
    }

    public void SetProjectileIntoPool(GameObject projectile, int poolType)
    {
        projectile.SetActive(false);

        switch(poolType)
        {
            case 1: projectiles1Pool.Add(projectile); break; 
            case 2: projectiles2Pool.Add(projectile); break; 
            default: projectiles2Pool.Add(projectile); break; 
        }
    }
    #endregion 
}
