using UnityEngine;

[System.Serializable]
public class PipeData
{
    public Vector2Int gridPosition;
    public GameObject pipePrefab;
}

public class LevelLoader : MonoBehaviour
{
    [Header("References")]
    public Transform LevelManager;
    public Transform TilesHolder;
    public Transform PipesHolder;

    [Header("Prefabs")]
    public GameObject board_Prefab;
    public GameObject tile_Prefab;
    public GameObject startPipe_Prefab;
    public GameObject endPipe_Prefab;

    [Header("Grid")]
    public int rows = 4;
    public int columns = 4;

    [HideInInspector]
    public float spacing = 2.5f;

    [Header("Start and End Pipe Grid Positions")]
    public Vector2Int startPipeGridPos = new Vector2Int(0, 0);
    public Vector2Int endPipeGridPos = new Vector2Int(3, 3);

    [Header("Pipes")]
    public PipeData[] pipeDatas;

    void Start()
    {
        BackGroundBoard();
        Grid();
        PlaceStartAndEndPipes();
        Pipes();
    }

    void Grid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float grid_Width = (columns - 1) * spacing;
                float grid_Height = (rows - 1) * spacing;

                Vector3 offset = new Vector3(-grid_Width / 2f, grid_Height / 2f, 0f);

                Vector3 pos = new Vector3(col * spacing, -row * spacing, 0) + offset;
                Instantiate(tile_Prefab, pos, Quaternion.identity, TilesHolder).name = $"{row}.{col}";
            }
        }
    }

    void BackGroundBoard()
    {
        Instantiate(board_Prefab, Vector3.zero, Quaternion.identity, LevelManager).name = "BackgroundBoard";
    }

    void PlaceStartAndEndPipes()
    {
        float grid_Width = (columns - 1) * spacing;
        float grid_Height = (rows - 1) * spacing;
        Vector3 offset = new Vector3(-grid_Width / 2f, grid_Height / 2f, 0f);

        Vector3 startPos = new Vector3(startPipeGridPos.y * spacing, -startPipeGridPos.x * spacing + 1.72f, 0f) + offset;
        Vector3 endPos = new Vector3(endPipeGridPos.y * spacing, -endPipeGridPos.x * spacing - 1.72f, 0f) + offset;

        Instantiate(startPipe_Prefab, startPos, Quaternion.identity, LevelManager).name = "StartPipe";
        Instantiate(endPipe_Prefab, endPos, Quaternion.identity, LevelManager).name = "EndPipe";
    }

    void Pipes()
    {
        float grid_Width = (columns - 1) * spacing;
        float grid_Height = (rows - 1) * spacing;
        Vector3 offset = new Vector3(-grid_Width / 2f, grid_Height / 2f, 0f);

        foreach (PipeData data in pipeDatas)
        {
            Vector3 pos = new Vector3(data.gridPosition.y * spacing, -data.gridPosition.x * spacing, 0f) + offset;

            Instantiate(data.pipePrefab, pos, Quaternion.identity, PipesHolder).name = $"Pipe_{data.gridPosition.x}_{data.gridPosition.y}";
        }
    }
}