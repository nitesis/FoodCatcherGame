// remember you can NOT have even numbers of height or width in this style of block maze
// to ensure we can get walls around all tunnels...  so use 21 x 13 , or 7 x 7 for examples.
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class MazeGenerator : MonoBehaviour
{

    public int width, height;
    public Material brick;
    public String MazeString;

    private int[,] Maze;
    private List<Vector3> pathMazes = new List<Vector3>();
    private Stack<Vector2> _tiletoTry = new Stack<Vector2>();
    private List<Vector2> offsets = new List<Vector2> { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0) };
    public GameObject spawnObject;
    public GameObject player;


    private System.Random rnd = new System.Random();

    private int _width, _height;
    private Vector2 _currentTile;


    public Vector2 CurrentTile
    {
        get { return _currentTile; }
        private set
        {
            if (value.x < 1 || value.x >= this.width - 1 || value.y < 1 || value.y >= this.height - 1)
            {
                throw new ArgumentException("Width and Height must be greater than 2 to make a maze");
            }
            _currentTile = value;
        }
    }

    private static MazeGenerator instance;

    public static MazeGenerator Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GenerateGame();
    }

    // end of main program

    // ============= subroutines ============

    void GenerateGame()
    {

        Maze = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Maze[x, y] = 1;
            }
        }
        CurrentTile = Vector2.one;
        _tiletoTry.Push(CurrentTile);
        Maze = CreateMaze();  // generate the maze in Maze Array.



        GameObject ptype = null;
        GameObject food = null;
        GameObject sphere = null;
        int count = 10;
        int indexPlace = 0;
        int cntfreePlaces = countFreePlaces(Maze);

        //Nummer 1 Blockzone
        // Nummer3 heisst player zone
        //Nummer 2 heisst foodZone
      
        Maze[1, 1] = 3;
        Maze[width - 2, height-2] = 3;


        Boolean[] rndmPlaces = FoodRandomPlaces(cntfreePlaces, count);

        for (int i = 0; i < rndmPlaces.Length; i++)
        {
            Debug.Log(rndmPlaces[i]);
        }

        System.Random random = new System.Random();

        float startX = -Maze.GetUpperBound(0) / 2;
        float startZ = -Maze.GetUpperBound(1) / 2;

        for (int i = 0; i <= Maze.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= Maze.GetUpperBound(1); j++)
            {
                if((i== width - 2 && j== height - 2)||(i==1 &&j==1))
                {
                    sphere = Instantiate(player) as GameObject;
                    sphere.transform.position = new Vector3(i * ptype.transform.localScale.x + startX, 0.5f, j * ptype.transform.localScale.z + startZ + 0.5f);
                }
                if (Maze[i, j] == 1)
                {
                   MazeString = MazeString + "X";  // added to create String
                    ptype = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    ptype.transform.position = new Vector3(i * ptype.transform.localScale.x + startX, 0.5f, j * ptype.transform.localScale.z + startZ + 0.5f);

                    if (brick != null)
                    {
                        ptype.GetComponent<Renderer>().material = brick;
                    }
                    ptype.transform.parent = transform;
                }
                else if (Maze[i, j] == 0)
                {
                    
                    MazeString = MazeString + "0"; // added to create String
                    pathMazes.Add(new Vector3(i, 0, j));
                                  
                    if (rndmPlaces[indexPlace] == true)
                    {   
                        food = Instantiate(spawnObject) as GameObject;
                        food.transform.position = new Vector3(i * ptype.transform.localScale.x + startX+0.5f , 0.5f, j * ptype.transform.localScale.z + startZ);
                        Maze[i, j] = 2;
                    }
                    indexPlace++;
                }

            }
            MazeString = MazeString + "\n";  // added to create String
        }
        print(MazeString);  // added to create String
    }

    //----------------------------------
    // liefert der Anzahl von freie Plätze im Maze, wo Foodobjekt plaziert werden können
    public int countFreePlaces(int[,] maze)
    {
        int count = 0;
        for (int i = 0; i <= Maze.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= Maze.GetUpperBound(1); j++)
            {
                if (Maze[i, j] == 0)
                {
                    count++;
                }
            }
        }

        return count;
    }

    //=============================================
    // liefert eine  eindinmentionale Array, Size vom array ist die Anzahl von mögliche Positionen
    // Das array wir mit true und false ausgefühlt=> beim "true" wird ein foodObjekt plaziert 
    public Boolean[] FoodRandomPlaces(int size, int countFood)
    {
        Boolean[] temp = new Boolean[size-1];
        for (int i = 1; i < size-1; i++)
        {
            temp[i] = false;
        }

        int n;
        System.Random random = new System.Random();
        int cnt = 0;
        while (cnt != countFood)
        {
            n = random.Next(0, size - 2);
            if (temp[n] == false )
            {
                temp[n] = true;
                cnt++;
            }

        }

        return temp;
    }


    // =======================================
    public int[,] CreateMaze()
    {

        //local variable to store neighbors to the current square as we work our way through the maze
        List<Vector2> neighbors;
        //as long as there are still tiles to try
        while (_tiletoTry.Count > 0)
        {
            //excavate the square we are on
            Maze[(int)CurrentTile.x, (int)CurrentTile.y] = 0;
            //get all valid neighbors for the new tile
            neighbors = GetValidNeighbors(CurrentTile);
            //if there are any interesting looking neighbors
            if (neighbors.Count > 0)
            {
                //remember this tile, by putting it on the stack
                _tiletoTry.Push(CurrentTile);
                //move on to a random of the neighboring tiles
                CurrentTile = neighbors[rnd.Next(neighbors.Count)];
            }
            else {
                //if there were no neighbors to try, we are at a dead-end toss this tile out
                //(thereby returning to a previous tile in the list to check).
                CurrentTile = _tiletoTry.Pop();
            }
        }
        print("Maze Generated ...");
        //Maze.SetValue (Color.green);
        return Maze;
    }

    // ================================================
    // Get all the prospective neighboring tiles "centerTile" The tile to test
    // All and any valid neighbors</returns>
    private List<Vector2> GetValidNeighbors(Vector2 centerTile)
    {
        List<Vector2> validNeighbors = new List<Vector2>();
        //Check all four directions around the tile
        foreach (var offset in offsets)
        {
            //find the neighbor's position
            Vector2 toCheck = new Vector2(centerTile.x + offset.x, centerTile.y + offset.y);
            //make sure the tile is not on both an even X-axis and an even Y-axis
            //to ensure we can get walls around all tunnels
            if (toCheck.x % 2 == 1 || toCheck.y % 2 == 1)
            {

                //if the potential neighbor is unexcavated (==1)
                //and still has three walls intact (new territory)
                if (Maze[(int)toCheck.x, (int)toCheck.y] == 1 && HasThreeWallsIntact(toCheck))
                {

                    //add the neighbor
                    validNeighbors.Add(toCheck);
                }
            }
        }
        return validNeighbors;
    }
    // ================================================
    // Counts the number of intact walls around a tile
    //"Vector2ToCheck">The coordinates of the tile to check
    //Whether there are three intact walls (the tile has not been dug into earlier.
    private bool HasThreeWallsIntact(Vector2 Vector2ToCheck)
    {

        int intactWallCounter = 0;
        //Check all four directions around the tile
        foreach (var offset in offsets)
        {

            //find the neighbor's position
            Vector2 neighborToCheck = new Vector2(Vector2ToCheck.x + offset.x, Vector2ToCheck.y + offset.y);
            //make sure it is inside the maze, and it hasn't been dug out yet
            if (IsInside(neighborToCheck) && Maze[(int)neighborToCheck.x, (int)neighborToCheck.y] == 1)
            {
                intactWallCounter++;
            }
        }
        //tell whether three walls are intact
        return intactWallCounter == 3;
    }

    // ================================================
    private bool IsInside(Vector2 p)
    {
        //return p.x >= 0  p.y >= 0  p.x < width  p.y < height;
        return p.x >= 0 && p.y >= 0 && p.x < width && p.y < height;
    }
}