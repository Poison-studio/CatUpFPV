using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    /// <summary>
    /// Никакой логики в этом классе нет, просто место, из которого можно достать нужные компоненты, прикрепленные к игроку
    /// </summary>
    public class PlayerAccessPoint : MonoBehaviour
    {
        [SerializeField]
        private WeaponHandler weaponHandler;

        public WeaponHandler WeaponHandler => weaponHandler;

        [SerializeField]
        private AudioPlayer audioPlayer;

        public AudioPlayer AudioPlayer => audioPlayer;

        [SerializeField]
        private GoldPlayerController goldPlayerController;

        public GoldPlayerController GoldPlayerController => goldPlayerController;

        [SerializeField]
        private Interactor interactor;

        public Interactor Interactor => interactor;
    }
}