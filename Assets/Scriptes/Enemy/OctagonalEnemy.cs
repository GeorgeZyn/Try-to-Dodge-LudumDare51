using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctagonalEnemy : GeneralEnemy
{
   [SerializeField] protected GameObject projectile;
   [SerializeField] private float timeSpawnProjectile = 1.98f;

   protected override void Action()
   {
      timeSpawnProjectile -= Time.deltaTime;
      if (timeSpawnProjectile < 0)
      {
         Instantiate(projectile, transform.position, Quaternion.identity, SpawnManager.instance.transform);
         timeSpawnProjectile = 1.98f;
      }
   }

   override protected IEnumerator Attack()
   {
      Destroy(gameObject, 10);
      yield return null;
   }
}
