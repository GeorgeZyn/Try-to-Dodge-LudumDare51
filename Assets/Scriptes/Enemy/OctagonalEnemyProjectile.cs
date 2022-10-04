using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctagonalEnemyProjectile : OctagonalEnemy
{
   [SerializeField] private Rigidbody2D _rigidbody;

   [SerializeField] private float speed = 5f;
   [SerializeField] private float rotateSpeed = 200f;

   protected override void Action()
   {
      transform.Rotate(0, 0, 30 * Time.deltaTime);

      Vector2 direction = (Vector2)_player.position - _rigidbody.position;
      direction.Normalize();
      float rotateAmount = Vector3.Cross(direction, transform.right).z;

      _rigidbody.angularVelocity = -rotateAmount * rotateSpeed;
      _rigidbody.velocity = transform.right * speed;
   }

   override protected IEnumerator Attack()
   {
      FindingTheTurnAngleToThePlayer();
      Destroy(gameObject, 3);
      yield return null;
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Player"))
         Destroy(gameObject);
   }
}
