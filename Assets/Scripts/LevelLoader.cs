using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    [Header("References")]
    public Transform LEVEL_MANAGER;

    [Header("Grid")]
    public GameObject TILE_PREFAB;
    public int rows = 4;
    public int columns = 4;
    public float spacing = 1.1f;

    [Header("Board")]
    public GameObject BOARD_PREFAB;

    [Header("StartendPipe_Prefab;s")]
    public GameObject startPipe_Prefab;
    public GameObject endPipe_Prefab;

    [SerializeField] float[] STARTEND_X_POSITION = { -3.831f, -1.28f, 1.28f, 3.831f };
    [SerializeField] float[] STARTEND_Y_POSITION = { 5.55f, -5.55f };

    void Start()
    {
        BackGroundBoard();
        Grid();
        StartEndPipes();
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
                GameObject tile = Instantiate(TILE_PREFAB, pos, Quaternion.identity, LEVEL_MANAGER);
                tile.name = $"{row}.{col}";
            }
        }
    }

    void BackGroundBoard()
    {
        GameObject board = Instantiate(BOARD_PREFAB, Vector3.zero, Quaternion.identity, LEVEL_MANAGER);
        board.name = "BackgroundBoard";
    }

    void StartEndPipes()
    {
        GameObject startPipe = Instantiate(startPipe_Prefab, new Vector3(STARTEND_X_POSITION[0], STARTEND_Y_POSITION[0], 0f), Quaternion.identity, LEVEL_MANAGER);
        startPipe.name = "StartPipe";

        GameObject endPipe = Instantiate(endPipe_Prefab, new Vector3(STARTEND_X_POSITION[3], STARTEND_Y_POSITION[1], 0f), Quaternion.identity, LEVEL_MANAGER);
        endPipe.name = "EndPipe";
    }
}