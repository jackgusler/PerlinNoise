using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perlinController : MonoBehaviour
{
    List<Vector2Int> points = new List<Vector2Int>();

    List<GameObject> cubes = new List<GameObject>();

    [SerializeField]
    public GameObject cubePrefab = null;

    public Slider One_Dimensional_x_slider;
    public Slider Two_Dimensional_x_slider;
    public Slider Two_Dimensional_y_slider;
    public Slider Three_Dimensional_x_slider;
    public Slider Three_Dimensional_y_slider;

    public int x_offset_input;
    public int y_offset_input;

    int min_x = -10;
    int max_x = 10;

    int min_y = -10;
    int max_y = 10;

    int offset_x = 0;
    int offset_y = 0;

    public float scale = 0.1f;
    public float magnitude = 12f;

    void generatePoints()
    {
        points.Clear();
        for (int x = min_x; x < max_x; x++)
        {
            for (int y = min_y; y < max_y; y++)
            {
                points.Add(new Vector2Int(x, y));
            }
        }
    }

    void generateCubes()
    {

        foreach (Vector2Int point in points)
        {
            GameObject cube = Instantiate(cubePrefab);
            cube.transform.parent = transform;

            cube.transform.position = new Vector3(point.x, 0, point.y);

            cubes.Add(cube);

            float xCoord = (x_offset_input + offset_x + point.x) * scale;
            float yCoord = (y_offset_input + offset_y + point.y) * scale;
            float y = Mathf.PerlinNoise(xCoord, yCoord) * magnitude;

            cube.transform.localScale = new Vector3(1, y, 1);
            cube.SetActive(true);
        }
    }

    void updateCubesPositions()
    {
        foreach (Vector2Int point in points)
        {
            int index = (point.x - min_x) + (point.y - min_y) * (max_x - min_x);

            float xCoord = (x_offset_input + offset_x + point.x) * scale;
            float yCoord = (y_offset_input + offset_y + point.y) * scale;

            float y = Mathf.PerlinNoise(xCoord, yCoord) * magnitude;

            cubes[index].transform.position = new Vector3(point.x, y / 2, point.y);
            cubes[index].transform.localScale = new Vector3(1, y, 1);
        }
    }

    void Start()
    {
        updateMap();
    }

    void randomizeOffset()
    {
        offset_x = UnityEngine.Random.Range(-1000, 1000);
        offset_y = UnityEngine.Random.Range(-1000, 1000);
    }

    public void updateMap()
    {
        randomizeOffset();
        One_Dimensional_x_slider.onValueChanged.AddListener(UpdateXSliderValue);
        Two_Dimensional_x_slider.onValueChanged.AddListener(UpdateXSliderValue);
        Two_Dimensional_y_slider.onValueChanged.AddListener(UpdateYSliderValue);
        Three_Dimensional_x_slider.onValueChanged.AddListener(UpdateXSliderValue);
        Three_Dimensional_y_slider.onValueChanged.AddListener(UpdateYSliderValue);

        destroyCubes();

        generatePoints();
        generateCubes();
    }

    void destroyCubes()
    {
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes.Clear();
    }

    public void UpdateXSliderValue(float value)
    {
        x_offset_input = Mathf.RoundToInt(value);
        updateCubesPositions();
    }

    public void UpdateYSliderValue(float value)
    {
        y_offset_input = Mathf.RoundToInt(value);
        updateCubesPositions();
    }

    void Update()
    {

    }


}
