using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : GeneralEnemy
{
   [SerializeField] private Transform[] points;
   [SerializeField] private GameObject projectile;

   protected override void Action()
   {
      return;
   }

   override protected IEnumerator Attack()
   {
      Destroy(gameObject, 10);
      for (int i = 0; ; i++)
      {
         if (i == points.Length)
            i = 0;
         Instantiate(projectile, points[i].position, points[i].rotation, SpawnManager.instance.transform);
         yield return new WaitForSeconds(0.5f);
      }
   }
}
