using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGenerator : MonoBehaviour {

    [SerializeField] private int _rows;

    [SerializeField] private int _columns;

    [SerializeField] private GameObject _prefab;

    [SerializeField] public Block[] _cells;

    [SerializeField] public Block Start;
    [SerializeField] public Block End;
    [SerializeField] public float _speed = 0.05f;
    public void Generate()
    {
        GameObject obj = new GameObject();
        _cells = new Block[_rows * _columns];
        for(int x = 0; x < _rows; x++)
        {
            for (int y = 0; y < _columns; y++)
            {
                _cells[x * _columns + y] = Instantiate(_prefab,new Vector3(x*1.5f ,0,-(y*2.0f + (x % 2 == 0 ? 0 : 1))),Quaternion.Euler(90,90,90)).GetComponent<Block>();
                _cells[x * _columns + y].transform.parent = obj.transform;
                _cells[x * _columns + y].pos = ConvertAxiToCubeCoordinates(x, y);
            }
        }

        Start = _cells[0];
        End = _cells[_cells.Length - 1];
    }


    public void GetPath()
    {

    }
    
    //public IEnumerator FindPathGreedyBestFirstSearch()
    //{
    //    Dictionary<Block, int> pathValues = new Dictionary<Block, int>();


    //    Queue<Block> queue = new Queue<Block>(); //1. backstack

    //    Dictionary<Block, Block> parents = new Dictionary<Block, Block>();


    //    bool[] visited = new bool[_cells.Length];

    //    //Start van de start positie
    //    Block start = Start;
    //    queue.Enqueue(start); //2b
    //    pathValues[start] = 0;

    //    bool found = false;
    //    while (queue.Count > 0 && !found) // 3 loop doorheen de stack
    //    {

    //        Block current = queue.Dequeue();

    //        var unvisitedNeighbours = FilterNeighbours(current, visited);
    //        foreach (var neighbour in unvisitedNeighbours)
    //        {
    //            queue.Enqueue(neighbour);
    //            parents[neighbour] = current;

    //            pathValues[neighbour] = pathValues[current] + neighbour.Penalty;
    //            neighbour.Display = pathValues[neighbour];
    //            yield return new WaitForSeconds(_speed);
    //        }

    //        visited[current.Row * _columns + current.Column] = true;

    //        if (current == End)
    //            found = true;

    //        yield return new WaitForSeconds(_speed);

    //    }


    //    CellBehaviour pathPart = _endCell;
    //    while (pathPart != _startCell)
    //    {
    //        pathPart.Color = Color.cyan;
    //        pathPart = parents[pathPart];
    //        yield return new WaitForSeconds(_speed);
    //    }
    //}

    //private List<Block> FilterNeighbours(Block current, bool[] visited)
    //{
    //    // collect unvisited neighbours
    //    List<Block> unvisitedNeighbours = new List<Block>(4);
    //    if (current.Row < (_rows - 1) && !visited[(current.Row + 1) * _columns + current.Column])
    //        unvisitedNeighbours.Add(_cells[(current.Row + 1) * _columns + current.Column]);

    //    if (current.Row > 0 && !visited[(current.Row - 1) * _columns + current.Column])
    //        unvisitedNeighbours.Add(_cells[(current.Row - 1) * _columns + current.Column]);

    //    if (current.Column < (_columns - 1) && !visited[current.Row * _columns + (current.Column + 1)] )
    //        unvisitedNeighbours.Add(_cells[current.Row * _columns + (current.Column + 1)]);

    //    if (current.Column > 0 && !visited[current.Row * _columns + (current.Column - 1)])
    //        unvisitedNeighbours.Add(_cells[current.Row * _columns + (current.Column - 1)]);

    //    return unvisitedNeighbours;
    //}


    public static Vector3 ConvertAxiToCubeCoordinates(int x, int y)
    {
        float xo = x;
        float zo = y - (x - (x & 1)) / 2;
        float yo = -x - zo;
        return new Vector3(xo, yo, zo);
    }

    public static Vector2 ConvertCubeToAxiCoordinates(Vector3 pos)
    {
        float xo = pos.x;
        float zo = pos.z - (pos.x - ((int)pos.x & 1)) / 2;
        return new Vector2(xo, zo);
    }
}
