using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
   public static SpawnManager instance;

   [SerializeField] private TextMeshProUGUI levelText;
   [SerializeField] private GameObject[] enemies;
   [SerializeField] private int level = 0;

   private void Awake()
   {
      instance = this;
   }

   public void CreatesEnemies()
   {

      level++;
      if (level % 3 == 0)
         Player.instance.heatPoints++;
      for (int i = 0; i < level; i++)
      {
         float xPoint = Random.Range(-8.02f, 8.02f);
         float yPoint = Random.Range(Random.Range(0, 2.72f), Random.Range(-4.33f, 0));

         int randomEnemy = Random.Range(0, enemies.Length);
         Instantiate(enemies[randomEnemy], new Vector2(xPoint, yPoint), Quaternion.identity);
      }

      levelText.text = string.Format("{0:00}", level);
   }

   public void DeleteAllChild()
   {
      foreach(Transform child in gameObject.transform)
      {
         Destroy(child.gameObject);
      }
   }
}
