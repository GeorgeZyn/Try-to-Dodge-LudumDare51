using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneralEnemy : MonoBehaviour
{
   protected Transform _player;

   private void Start()
   {
      _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      StartCoroutine(Attack());
   }

   private void Update()
   {
      Action();
   }

   protected void FindingTheTurnAngleToThePlayer()
   {
      Vector3 rot = _player.position - transform.position;
      float angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0, 0, angle - 90);
   }

   abstract protected void Action();
   abstract protected IEnumerator Attack();
}
