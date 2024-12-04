using UnityEngine;
namespace Chapter.ObjectPool
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private int DuckSpawns = 0;
        public int totalScore;
        [SerializeField] GameObject DuckPrefab;
        private ObjectPool _pool;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _pool = gameObject.AddComponent<ObjectPool>();
        }
        void OnGUI()
        {
            if (GUILayout.Button("Start Wave"))
            {
                var amount = Random.Range(1, 50);
                if (amount <= 49)
                {
                    _pool.Spawn();
                }
                else
                {
                    //spawn decoy
                }
                    
            }
                
        }

            // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {

                AddScore(100);
            }
        }

        private void AddScore(int score)
        {
            totalScore += score;
        }
    }
}
