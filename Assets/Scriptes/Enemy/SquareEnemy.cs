using System.Collections;

public class SquareEnemy : GeneralEnemy
{
   protected override void Action()
   {
      return;
   }

   override protected IEnumerator Attack()
   {
      Destroy(gameObject, 10);
      yield return null;
   }
}
