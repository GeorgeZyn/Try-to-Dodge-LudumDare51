using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   [SerializeField] private Animator transition;
   [Range(0, 1)] [SerializeField] float timeScaleValue = 1;

   private void Awake()
   {
      instance = this;
   }

   private void Update()
   {
      Time.timeScale = timeScaleValue;
   }

   public void HomeButton()
   {
      StartCoroutine(LoadLevel());
   }

   public IEnumerator SlowDamage()
   {
      timeScaleValue = 0.3f;
      yield return new WaitForSeconds(0.1f);
      timeScaleValue = 0.4f;
      yield return new WaitForSeconds(0.1f);
      timeScaleValue = 0.5f;
      yield return new WaitForSeconds(0.1f);
      timeScaleValue = 0.7f;
      yield return new WaitForSeconds(0.1f);
      timeScaleValue = 0.9f;
      yield return new WaitForSeconds(0.1f);
      timeScaleValue = 1f;
   }

   public IEnumerator LoadLevel()
   {
      transition.SetTrigger("Start");
      yield return new WaitForSeconds(1.1f);

      SceneManager.LoadScene(0);
   }
}
