using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
   [SerializeField] private Animator transition;

   public void PlayGameButton()
   {
      StartCoroutine(LoadLevel());
   }
   
   public void ExitButton()
   {
      StartCoroutine(Exit());
   }

   private IEnumerator LoadLevel()
   {
      transition.SetTrigger("Start");
      yield return new WaitForSeconds(1.1f);

      SceneManager.LoadScene(1);
   }

   private IEnumerator Exit()
   {
      transition.SetTrigger("Start");
      yield return new WaitForSeconds(1.1f);

      Application.Quit();
   }
}
