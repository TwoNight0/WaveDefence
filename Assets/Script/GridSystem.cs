using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{

    public int width;
    public int height;
    public int[,] gridArray;
    //cellSize;
    public float cellsize;

    public int[,] matrix;

    public GridSystem(int width, int height) {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];
    
        //������ �ִ��� Ȯ��.
        // �ϴ� ���� ��̰� �ְ�
        // ��带 Ŭ���� ��ǥ�� �˼��־����
        // �̹� ���� ���� �ڸ��� 1���ִ��� Ȯ��(�̰ɷ� ��ġȮ��)
        // ��ǥ�� �˸� �� ��ǥ�� ���� �������� �迭��ŭ 0->1�ιٲپ����
 
    }

    // Start is called before the first frame update
    void Start()
    {

        matrix = new int[,] { {1, 0, 0 }, { 0, 0, 0 } , { 0, 0, 0 } };


        matrix = Rotate90Degrees(matrix);
        matrix = Rotate90Degrees(matrix);
        matrix = Rotate90Degrees(matrix);

        PrintArray(matrix);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[,] Rotate90Degrees(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] rotatedMatrix = new int[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                rotatedMatrix[j, rows - 1 - i] = matrix[i, j];
            }
        }

        return rotatedMatrix;
    }


    public void PrintArray(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Debug.Log(matrix[i, j] + " ");
            }
            Debug.Log("/n");
        }
    }

}
