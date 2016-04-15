using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MazeBlockController : MonoBehaviour {

    public MazeGenerator mazeGenerator;
    public float fallDelay = 1;
    public bool fallBlockActive;

    private GameObject[,] maze;
    private int[,] mazeLogic;
    private List<Position> fallPossibleBlocks;
    private GameObject appear;
    private System.Random random = new System.Random();

   

    void Start()
    {
        maze = mazeGenerator.GetMaze();
        mazeLogic = mazeGenerator.GetMazeLogik();
        fallPossibleBlocks = FallPossibleBlocks();
        if (fallBlockActive)
           StartCoroutine(doFall());
    

    }

    private List<Position> FallPossibleBlocks()
    {
        
            var possibleBlocks = new List<Position>();
            for (int i = 1; i < mazeLogic.GetLength(0) - 1; i++)
                for (int j = 1; j < mazeLogic.GetLength(1) - 1; j++)
                    if (mazeLogic[i, j]==1)
                        if (CheckPossibility(i,j))
                            possibleBlocks.Add(new Position(i, j));
            return possibleBlocks;
        
    }



    public bool CheckPossibility(int i, int j)
    {
        bool possibleRow = mazeLogic[i - 1, j]==1 && mazeLogic[i+1,j]==1;
        bool possibleColomn = mazeLogic[i, j+1] == 1 && mazeLogic[i, j-1] == 1;
        return possibleColomn ||possibleRow;
    }

    private IEnumerator doFall()
    {
        while (fallBlockActive)
        {
            yield return new WaitForSeconds(fallDelay);
            var position = randomBlockPosition();
            fallBlock(position);

        }
    }

    private IEnumerator doRise()
    {
        while (fallBlockActive)
        {
            yield return new WaitForSeconds(fallDelay);
            riseUp(appear);
        }
    }



    private void fallBlock(Position pos)
    {
        GameObject block = maze[pos.x, pos.y];
        block.transform.position = new Vector3(block.transform.position.x, -5.0f, block.transform.position.x);
        appear = block;
       // StartCoroutine(doRise());
    }

    private void riseUp(GameObject block)
    {
                block.transform.position = new Vector3(block.transform.position.x, 0.7f, block.transform.position.x);
    }

    private Position randomBlockPosition()
    {
        
            return fallPossibleBlocks[random.Next(0, fallPossibleBlocks.Count)];
        
    }

    // Update is called once per frame
    void Update () {
	
	}

    public class Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


}
