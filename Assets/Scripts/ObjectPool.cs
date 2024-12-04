using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] GameObject objectPrefab;
        //List of spawn locations for ducks
        //[SerializeField] GameObject spawnLocations;
        int maxPoolSize = 10;
        int stackDefaultCapacity = 10;


        public IObjectPool<Duck> Pool
        {
            get
            {
                if (_pool == null)
                    _pool = new ObjectPool<Duck>(CreatedPooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject,
                    true, stackDefaultCapacity, maxPoolSize);
                return _pool;
            }

        }
        private IObjectPool<Duck> _pool;
        private Duck CreatedPooledItem()
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Duck duck = go.AddComponent<Duck>();
            go.name = "Duck";
            duck.Pool = Pool;
            return duck;
        }
        private void OnReturnedToPool(Duck duck)
        {
            duck.gameObject.SetActive(false);
        }
        private void OnTakeFromPool(Duck duck)
        {
            duck.gameObject.SetActive(true);
        }
        private void OnDestroyPoolObject(Duck duck)
        {
            Destroy(duck.gameObject);
        }
        public void Spawn()
        {
            var amount = Random.Range(1, 10);
            for (int i = 0; i < amount; ++i)
            {
                var duck = Pool.Get();
                duck.transform.position = Random.insideUnitSphere * 7.5f;
            }
        }
    }
}
