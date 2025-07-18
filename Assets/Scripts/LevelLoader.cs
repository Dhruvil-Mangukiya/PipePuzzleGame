using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    [Header("References")]
    public Transform level_manager;

    [Header("Grid")]
    public GameObject tile_Prefab;
    public int rows = 4;
    public int columns = 4;
    public float spacing = 1.1f;

    [Header("Board")]
    public GameObject board_Prefab;

    [Header("StartendPipe_Prefab;s")]
    public GameObject startPipe_Prefab;
    public GameObject endPipe_Prefab;

    [SerializeField] float[] startend_x_position = { -3.831f, -1.28f, 1.28f, 3.831f };
    [SerializeField] float[] startend_y_position = { 5.55f, -5.55f };

    [Header("Pipe")]
    public GameObject pipe_Prefab;

    public void Level()
    {
        BackGroundBoard();
        Grid();
        StartEndPipes();
        SpawnPipeAt(3, 3);
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
                GameObject tile = Instantiate(tile_Prefab, pos, Quaternion.identity, level_manager);
                tile.name = $"{row}.{col}";
            }
        }
    }

    void BackGroundBoard()
    {
        GameObject board = Instantiate(board_Prefab, Vector3.zero, Quaternion.identity, level_manager);
        board.name = "BackgroundBoard";
    }

    void StartEndPipes()
    {
        GameObject startPipe = Instantiate(startPipe_Prefab, new Vector3(startend_x_position[0], startend_y_position[0], 0f), Quaternion.identity, level_manager);
        startPipe.name = "StartPipe";

        GameObject endPipe = Instantiate(endPipe_Prefab, new Vector3(startend_x_position[3], startend_y_position[1], 0f), Quaternion.identity, level_manager);
        endPipe.name = "EndPipe";
    }

    public void SpawnPipeAt(int x, int y)
    {
        Vector3 spawnPosition = new Vector3(x * rows, y * columns, 0);
        Instantiate(pipe_Prefab, spawnPosition, Quaternion.identity);
    }
}