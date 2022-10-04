using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyProjectile : CircleEnemy
{
   [SerializeField] private float _projectileSpeed = 1;

   protected override void Action()
   {
      transform.Translate(Vector2.up * _projectileSpeed * Time.deltaTime);
   }

   override protected IEnumerator Attack()
   {
      Destroy(gameObject, 5);
      yield return null;
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Player"))
         Destroy(gameObject);
   }
}
