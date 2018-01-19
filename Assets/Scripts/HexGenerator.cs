using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View.impl;

public class HexGenerator : MonoBehaviour {

    [SerializeField] public int _rows;

    [SerializeField] public int _columns;

    [SerializeField] private GameObject _prefab;

    [SerializeField] private Block[] _cells;

    //[SerializeField] public Block Start;
    //[SerializeField] public Block End;
    [SerializeField] public float _speed = 0.2f;

    public static HexGenerator Instance;


    private static Vector2[,] oddq_directions = new Vector2[,] {
        {
        new Vector2(+1, 0), new Vector2(+1, -1), new Vector2(0, -1),
        new Vector2(-1, -1), new Vector2(-1, 0), new Vector2(0, +1)
        },{
        new Vector2(+1, +1), new Vector2(+1, 0), new Vector2(0, -1),
        new Vector2(-1, 0), new Vector2(-1, +1), new Vector2(0, +1)
        }
    };

    public void Generate()
    {
        GameObject obj = new GameObject();
        _cells = new Block[_rows * _columns];
        for (int x = 0; x < _rows; x++)
        {
            for (int y = 0; y < _columns; y++)
            {
                _cells[x * _columns + y] = Instantiate(_prefab, new Vector3(x * 1.5f, 0, -(y * 2.0f + (x % 2 == 0 ? 0 : 1))), Quaternion.Euler(90, 90, 90)).GetComponent<Block>();
                _cells[x * _columns + y].transform.parent = obj.transform;
                _cells[x * _columns + y].pos = new Vector3(x, y);
            }
        }

        //Start = _cells[0];
        //End = _cells[_cells.Length - 1];
    }

    public Block[] FindPathGreedyBestFirstSearch( Block start, Block end)
    {
        Dictionary<Block, int> pathValues = new Dictionary<Block, int>();


        PriorityQueue<Block> queue = new PriorityQueue<Block>((left, right) =>
        {
            var distance1 = Mathf.Sqrt(Mathf.Pow(left.pos.x - end.pos.x, 2) + Mathf.Pow(left.pos.y - end.pos.y,2));
            var distance2 = Mathf.Sqrt(Mathf.Pow(right.pos.x - end.pos.x, 2) + Mathf.Pow(right.pos.y - end.pos.y, 2));

            return distance1.CompareTo(distance2);

            //return pathValues[left].CompareTo(pathValues[right]);

        }); //1. backstack

        Dictionary<Block, Block> parents = new Dictionary<Block, Block>();


        bool[] visited = new bool[_cells.Length];

        //Start van de start positie
        queue.Enqueue(start); //2b
        pathValues[start] = 0;

        bool found = false;
        while (queue.Count > 0 && !found) // 3 loop doorheen de stack
        {

            Block current = queue.Dequeue();

            var unvisitedNeighbours = FilterNeighbours(current, visited);
            foreach (Block neighbour in unvisitedNeighbours)
            {
                parents[neighbour] = current;
                
                pathValues[neighbour] = pathValues[current] + neighbour.Penalty;
                queue.Enqueue(neighbour);
                neighbour.Display = pathValues[neighbour];
            }
            
            visited[(int)current.pos.x * _columns + (int)current.pos.y] = true;

            if (current == end)
                found = true;

        }
        
        Block pathPart = end;
        List<Block> togo = new List<Block>();
        while (pathPart != start && parents.Count != 0)
        {
            togo.Add(pathPart);
            pathPart = parents[pathPart];
        }
        togo.Reverse();
        return togo.ToArray();
        
    }

    private List<Block> FilterNeighbours(Block current, bool[] visited)
    {
        // collect unvisited neighbours
        List<Block> unvisitedNeighbours = new List<Block>(6);
        

        for (int i = 0; i < 6; i++)
        {
            Vector2 pos = Neighbor(current.pos,i);
            if (pos.x >= 0 && pos.x < _rows && pos.y >= 0 && pos.y < _columns)
            {
                if (!visited[(int)pos.x * _columns + (int)pos.y] && !_cells[(int)pos.x * _columns + (int)pos.y].GetComponent<BlockView>().HasTower)
                {
                    unvisitedNeighbours.Add(_cells[(int)pos.x * _columns + (int)pos.y]);
                }
            }
        }

        return unvisitedNeighbours;
    }

    private Vector2 Neighbor(Vector2 hex, int direction) {
        int parity = ((int)hex.x) & 1;
        var dir = oddq_directions[parity, direction];
        return new Vector2(hex.x + dir.x, hex.y + dir.y);
    }

    public Vector3 ConvertAxiToCubeCoordinates(int x, int y)
    {
        float xo = x;
        float zo = y - (x - (x & 1)) / 2;
        float yo = -x - zo;
        return new Vector3(xo, yo, zo);
    }

    public Vector2 ConvertCubeToAxiCoordinates(Vector3 pos)
    {
        float xo = pos.x;
        float zo = pos.z - (pos.x - ((int)pos.x & 1)) / 2;
        return new Vector2(xo, zo);
    }
    
    public Block GetBlock(Vector3 pos)
    {
        return _cells[(int)(pos.x/1.5f) * _columns + (int)(pos.z/2)];
    }
    public Block[] GetBlocks()
    {
        return _cells;
    }
}
