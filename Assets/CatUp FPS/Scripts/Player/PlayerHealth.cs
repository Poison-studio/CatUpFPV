using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class PlayerHealth : Health
    {
        [SerializeField]
        private PlayerAccessPoint playerAccessPoint;

        [SerializeField]
        private VignetteDamage vignetteDamage;

        [SerializeField]
        private HealthUI healthUI;

        [SerializeField]
        private GoldPlayerController goldPlayerController;

        [SerializeField]
        private Animator animator;

        protected override void OnDeath()
        {
            animator.SetTrigger("Death");
            goldPlayerController.enabled = false;
            playerAccessPoint.PlayerDeath.Invoke();
        }

        protected override void OnGetDamage()
        {
            goldPlayerController.Camera.CameraShake(2, 2, 1);
            vignetteDamage.GetDamage();
            healthUI.SetHealth(Value);
        }
    }

}