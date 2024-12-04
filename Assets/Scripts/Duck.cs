using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class Duck : MonoBehaviour
    {
        Rigidbody2D rb;
        public IObjectPool<Duck> Pool { get; set; }

        public float _currentHealth;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _currentHealth = 1;
        }
        void OnEnable()
        {
            rb.AddForceX(0.01f);
        }
        private void OnDisable()
        {
            ResetDuck();
        }

        private void ReturnToPool()
        {
            Pool.Release(this);
        }
        private void ResetDuck()
        {
            _currentHealth = 1;
            this.transform.position = Vector3.zero;
        }
        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0.0f)
                ReturnToPool();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Boundary")
            {
                OnDisable();
                ReturnToPool() ;
            }
        }
    }
}
