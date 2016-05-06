using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodObjectController : MonoBehaviour
{
    public MazeGenerator mazeGenerator;
    public GameObject spawnPrefab;
    public int prefabCount;
    public bool rearrangeObjects;
    public float rearrangeDelay = 1;

    private GameObject[,] maze;
    private List<ObjectContainer> objects = new List<ObjectContainer>();
    private List<Position> emptyPositions;
    private System.Random random = new System.Random();
    private GameObject fleeObject1;
    private GameObject fleeObject2;
    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        maze = mazeGenerator.GetMaze();
        emptyPositions = currentEmptyTiles;
        player1 = mazeGenerator.GetFirstPlayer();
        player2 = mazeGenerator.GetsecondPlayer();
        // Create Fleeing Objects
        fleeObject1 =PlaceFleeObject(RandomPosFleeObject());
        fleeObject2=PlaceFleeObject(RandomPosFleeObject());
        // Create hiding and appearing Objects
        var maxObjects = System.Math.Min(emptyPositions.Count, prefabCount-2);
        for (int i = 0; i < maxObjects; i++)
            spawnRandom(spawnPrefab);
        if (rearrangeObjects)
            StartCoroutine(rearrange());
        
    }

    void Update()
    {
        if(fleeObject1!=null)
             moveFleeObject(fleeObject1);

        if (fleeObject1 != null)
            moveFleeObject(fleeObject2);
    }

    //==================================================================
    //Methods used for fleeing objects

    private void moveFleeObject(GameObject obj)
    {
        var distance = 2;
        
        if ((Vector3.Distance(player1.transform.position, obj.transform.position) < distance)
            || (Vector3.Distance(player2.transform.position, obj.transform.position) < distance))
        {
            Destroy(obj.gameObject);
        }
       

        
    }

    private List<Position> sensorZoneFleeObject(GameObject obj)
    {
        List<Position> positions = new List<Position>();
        Position posObj = new Position((int)obj.transform.position.x, (int)obj.transform.position.y);
        positions.Add(new Position(posObj.x + 1, posObj.y));
        positions.Add(new Position(posObj.x - 1, posObj.y));
        positions.Add(new Position(posObj.x , posObj.y+1));
        positions.Add(new Position(posObj.x, posObj.y-1));
        return positions;
    }


    private Position RandomPosFleeObject()
    {
        Position pos = null;
        if (emptyPositions != null)
        {
            bool posOK = false;
            int rndmIndex;   
            while (!posOK)
            {
                rndmIndex = random.Next(0, emptyPositions.Count-1);
                pos = emptyPositions[rndmIndex];
                if (pos.x > 2 && pos.y > 2)
                {
                    if (CountNullarraound(pos) >= 2)
                        posOK = true;
                }
            }  
        }
        return pos;
    }


    private int CountNullarraound(Position position)
    {
        int count = 0;
        if(maze[position.x-1,position.y]==null)
            count++;
        if (maze[position.x +1, position.y] == null)
            count++;
        if (maze[position.x, position.y-1] == null)
            count++;
        if (maze[position.x, position.y +1] == null)
            count++;
        return count;
    }

    private GameObject PlaceFleeObject(Position pos)
    {
        maze[pos.x, pos.y] = Instantiate(spawnPrefab) as GameObject;
        maze[pos.x, pos.y].transform.position = new Vector3(pos.x, 0.5f, pos.y);
        return maze[pos.x, pos.y];
    }

    private List<Position> currentEmptyTiles {
        get {
            var emptyTiles = new List<Position>();
            for (int i = 1; i < maze.GetLength(0) - 1; i++)
                for (int j = 1; j < maze.GetLength(1) - 1; j++)
                    if (maze[i, j] == null)
                        emptyTiles.Add(new Position(i, j));
            return emptyTiles;
        }
    }

    //===========================================================================================
    //Methods used for hiding and appearing objects

    public ObjectContainer spawnRandom(GameObject prefab)
    {
        return spawnObj(prefab, randomFreePosition);
    }
    
    public ObjectContainer spawnObject(GameObject prefab, Position position)
    {
        if (position.x < 1
            || position.x >= maze.GetLength(0) - 1
            || position.y < 1
            || position.y >= maze.GetLength(1) - 1
            || maze[position.x, position.y] != null)
            return null;
        return spawnObj(prefab, position);
    }

    private ObjectContainer spawnObj(GameObject prefab, Position position)
    {
        var obj = (GameObject) Instantiate(prefab, new Vector3(position.x, 0, position.y), Quaternion.identity);
        maze[position.x, position.y] = obj;
        emptyPositions.Remove(position);
        var objectContainer = new ObjectContainer(obj, position);
        objects.Add(objectContainer);
        return objectContainer;
    }

    private IEnumerator rearrange()
    {
        while (rearrangeObjects) {
            yield return new WaitForSeconds(rearrangeDelay);
            var objectContainer = randomObjectContainer;
            var newPosition = randomFreePosition;
            moveObjectContainer(objectContainer, newPosition);
        }
    }

    public void moveObjectContainer(ObjectContainer objectContainer, Position newPosition)
    {
        moveObject(objectContainer.obj.transform, newPosition);
        updateMaze(objectContainer.position, newPosition, objectContainer.obj);
        swapPositions(objectContainer.position, newPosition);
    }
    
    private ObjectContainer randomObjectContainer {
        get {
            return objects[random.Next(0, objects.Count)];
        }
    }

    private Position randomFreePosition {
        get {
            return emptyPositions[random.Next(0, emptyPositions.Count)];
        }
    }

    private void moveObject(Transform transform, Position newPosition)
    {
        var position = transform.position;
        position.x = newPosition.x;
        position.z = newPosition.y;
        transform.position = position;
    }

    private void updateMaze(Position oldPosition, Position newPosition, GameObject obj)
    {
        maze[oldPosition.x, oldPosition.y] = null;
        maze[newPosition.x, newPosition.y] = obj;
    }

    private void swapPositions(Position oldPosition, Position newPosition)
    {
        var x = newPosition.x;
        var y = newPosition.y;
        newPosition.x = oldPosition.x;
        newPosition.y = oldPosition.y;
        oldPosition.x = x;
        oldPosition.y = y;
    }

    //======================================================================================
    // inner classes 
    public class ObjectContainer
    {
        public GameObject obj;
        public Position position;

        public ObjectContainer(GameObject obj, Position position)
        {
            this.obj = obj;
            this.position = position;
        }
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
