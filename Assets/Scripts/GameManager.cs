using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform levelGrid;
    public float moveScale = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelGrid.position += moveScale * Time.deltaTime * Vector3.right;
    }
}
