using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public class PlayerAccessPoint : MonoBehaviour
    {
        [SerializeField]
        private WeaponHandler weaponHandler;

        public WeaponHandler WeaponHandler => weaponHandler;

        [SerializeField]
        private AudioPlayer audioPlayer;

        public AudioPlayer AudioPlayer => audioPlayer;


        public UnityEvent PlayerDeath;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}