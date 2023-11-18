using System.Collections.Generic;
using UnityEngine;

public class perlinController : MonoBehaviour
{
    List<Vector2Int> points = new List<Vector2Int>();

    List<GameObject> cubes = new List<GameObject>();

    [SerializeField]
    public GameObject cubePrefab = null;

    int min_x = -10;
    int max_x = 10;

    int min_y = -10;
    int max_y = 10;

    int offset_x = 0;
    int offset_y = 0;

    public float scale = 0.1f;
    public float magnitude = 12f;

    public int x_offset_input = 0;
    public int y_offset_input = 0;

    public void set_x_offset(int x)
    {
        x_offset_input = x;
        updateMapStagnate();
    }

    public void set_y_offset(int y)
    {
        y_offset_input = y;
        updateMapStagnate();
    }

    void generatePoints()
    {
        points.Clear();
        for(int x = min_x; x < max_x; x++)
        {
            for(int y = min_y; y < max_y; y++)
            {
                points.Add(new Vector2Int(x, y));
            }
        }
    }

    void generateCubes()
    {

        foreach(Vector2Int point in points)
        {
            // Instantiate as a child of this object
            
            GameObject cube = Instantiate(cubePrefab);
            cube.transform.parent = transform;
            cube.SetActive(true);
            cube.transform.position = new Vector3(point.x, 0, point.y);
    
            cubes.Add(cube);

            float y = Mathf.PerlinNoise((x_offset_input+offset_x+point.x)*scale, (y_offset_input+offset_y+point.y)*scale)*magnitude;
            cube.transform.localScale = new Vector3(1, y, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        updateMap();
    }

    void randomizeOffset(){
        offset_x = UnityEngine.Random.Range(-1000, 1000);
        offset_y = UnityEngine.Random.Range(-1000, 1000);
    }

    public void updateMap()
    {
        randomizeOffset();

        foreach(GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes.Clear();

        generatePoints();
        generateCubes();
    }

    public void updateMapStagnate()
    {
        foreach(GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes.Clear();

        generatePoints();
        generateCubes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
