using UnityEngine;
using UnityEngine.Events;

namespace CatUp
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField]
        private int value;

        private bool isDeath = false;

        public UnityEvent<GameObject> death;

        public int Value
        {
            get
            {
                return value;
            }
            private set
            {
                if (isDeath) return;

                OnGetDamage();

                this.value = value;

                if (this.value <= 0)
                {
                    isDeath = true;

                    OnDeath();

                    death.Invoke(gameObject);
                }
            }
        }

        protected abstract void OnGetDamage();
        protected abstract void OnDeath();

        public void GetDamage(int damage)
        {
            Value -= damage;
        }
    }
}
