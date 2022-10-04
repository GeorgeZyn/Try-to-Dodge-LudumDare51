using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
   [SerializeField] public float timeValue = 10;
   [SerializeField] TextMeshProUGUI timerText;

   [HideInInspector] public float currentTimeValue;

   private void Start()
   {
      currentTimeValue = timeValue;
   }

   private void Update()
   {
      if (currentTimeValue > 0)
      {
         currentTimeValue -= Time.deltaTime;
      }
      else
      {
         currentTimeValue += timeValue;
         SpawnManager.instance.DeleteAllChild();
         SpawnManager.instance.CreatesEnemies();
      }

      DisplayTime(currentTimeValue);
   }

   void DisplayTime(float timeToDisplay)
   {
      if(timeToDisplay < 0)
      {
         timeToDisplay = timeValue;
      }

      float seconds = Mathf.FloorToInt(timeToDisplay % 60);
      float milliseconds = timeToDisplay % 1 * 100;

      timerText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
   }
}
