using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
   public static Player instance;
   public int heatPoints = 5;

   [SerializeField] private float _speed = 5;
   [SerializeField] private TextMeshProUGUI hpText;
   [SerializeField] private ParticleSystem damageParticlePref;

   private bool resist = false;
   private Vector2 movement;
   private Rigidbody2D _rigidbody;
   private Animator _animator;

   private void Awake()
   {
      instance = this;
   }

   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
      _animator = GetComponent<Animator>();
   }

   private void Update()
   {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      hpText.text = string.Format("{0:00}    HP", heatPoints);
   }

   private void FixedUpdate()
   {
      _rigidbody.MovePosition(_rigidbody.position + movement * _speed * Time.fixedDeltaTime);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Obstacle"))
      {
         if (heatPoints >= 1 && resist == false)
         {
            Instantiate(damageParticlePref, other.transform.position, damageParticlePref.transform.rotation);
            StartCoroutine(Resist());
            StartCoroutine(GameManager.instance.SlowDamage());
            StartCoroutine(CameraShake.instance.Shake(0.06f, 0.08f));
            heatPoints--;
         }
         else if(heatPoints < 1 && resist == false)
         {
            StartCoroutine(GameManager.instance.LoadLevel());
         }
      }
   }

   private IEnumerator Resist()
   {
      resist = true;
      _animator.SetBool("IsDamaged", true);

      yield return new WaitForSeconds(5);

      resist = false;
      _animator.SetBool("IsDamaged", false);
   }
}
