using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int DuckSpawns = 0;
    public int totalScore;
    [SerializeField] GameObject DuckPrefab;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Destroy(DuckPrefab);
            AddScore(100);
        }
    }

    private void AddScore(int score)
    {
        totalScore += score;
    }
}
