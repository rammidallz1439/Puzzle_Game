using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab of the object to instantiate
    public const int width = 5; // Width of the 2D array
    public const int height = 5; // Height of the 2D array
    public float spacing = 1f; // Spacing between objects

    void Start()
    {
        // Example 2D array representing positions
        int[,] positions = new int[width, height] {
            {1, 0, 0, 0, 1},
            {0, 0, 1, 0, 0},
            {0, 1, 0, 1, 0},
            {0, 0, 1, 0, 0},
            {1, 0, 0, 0, 1}
        };

        // Iterate through the array
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // If the array value is 1, instantiate an object
                if (positions[y, x] == 1)
                {
                    Vector3 position = new Vector3(x * spacing, 0f, y * spacing);
                    Instantiate(objectPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
