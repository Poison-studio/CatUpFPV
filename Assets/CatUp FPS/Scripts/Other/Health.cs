using UnityEngine;

namespace CatUp
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField]
        private int value;

        private bool isDeath = false;

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
