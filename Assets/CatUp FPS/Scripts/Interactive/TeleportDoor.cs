using UnityEngine;
using Hertzole.GoldPlayer;
using System.Collections;

namespace CatUp
{
    public class TeleportDoor : Interactable
    {
        [SerializeField]
        private Transform destination;

        [SerializeField]
        private float fadeDuration;

        private VignetteTeleport vignetteTeleport;

        private void Start()
        {
            vignetteTeleport = FindObjectOfType<VignetteTeleport>();
        }

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);

            vignetteTeleport.FadeInOut(fadeDuration);

            StartCoroutine(Teleport());
        }

        private IEnumerator Teleport()
        {
            yield return new WaitForSeconds(fadeDuration);

            FindObjectOfType<GoldPlayerController>().SetPositionAndRotation(destination.transform.position, destination.transform.eulerAngles.y);
        }
    }

}