using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleEnemy : GeneralEnemy
{
   [SerializeField] private GameObject followLinePrefab;
   [SerializeField] private GameObject damageLinePrefab;

   private bool follow = true;

   protected override void Action()
   {
      if (follow)
      {
         FindingTheTurnAngleToThePlayer();
      }
   }

   override protected IEnumerator Attack()
   {
      Destroy(gameObject, 10);
      yield return new WaitForSeconds(1f);
      Instantiate(followLinePrefab, transform.position, transform.rotation, transform);
      yield return new WaitForSeconds(3f);
      follow = false;
      yield return new WaitForSeconds(1f);
      Instantiate(damageLinePrefab, transform.position, transform.rotation, transform);
   }
}
