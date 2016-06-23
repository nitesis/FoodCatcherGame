using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodObjectController : MonoBehaviour
{
    public MazeGenerator mazeGenerator;
    public GameObject spawnPrefab;
    public bool rearrangeObjects;
    public float rearrangeDelay ;
    public string level;
    public GameObject player1;
    public GameObject player2;

    public string foodPictureName;


    private GameObject[,] maze;
    private List<ObjectContainer> objects = new List<ObjectContainer>();
    private List<Position> emptyPositions;
    private System.Random random = new System.Random();
    private GameObject fleeObject1;
    private Position posFleeObject1;
    private Position posFleeObject2;
    private GameObject fleeObject2;
  

    private ReciepController reciepController= new ReciepController();
    private List<string> reciepList=new List<string>();
    private int prefabCount;
    private int indexReciepList=0;

    void Start()
    {
        // Reciep initialization
        // reciepList = reciepController.reciepList;

        // Reciep initialization
        // reciepList = reciepController.reciepList;
        if (level == "easy")
        {
            reciepList.Add("cheese");
            reciepList.Add("garlic");
            reciepList.Add("wine");
            reciepList.Add("maizena");
            reciepList.Add("cheese");
        }

        if (level == "medium")
        {
            reciepList.Add("potato");
            reciepList.Add("onion");
            reciepList.Add("garlic");
            reciepList.Add("cream");
            reciepList.Add("pasta");
            reciepList.Add("cheese");
            reciepList.Add("ham");
            reciepList.Add("apple");
        }

        if (level == "hard")
        {
            reciepList.Add("egg");
            reciepList.Add("cream");
            reciepList.Add("ham");
            reciepList.Add("butter");
            reciepList.Add("cress");
            reciepList.Add("flour");
            reciepList.Add("salsiz");
            reciepList.Add("chard");
            reciepList.Add("onion");
        }

        //==========================================================

        prefabCount = reciepList.Count;
        Debug.Log("prefabCount"+prefabCount);

        maze = mazeGenerator.GetMaze();
        emptyPositions = currentEmptyTiles;

        // Create Fleeing Objects
        posFleeObject1 = RandomPosFleeObject();
        posFleeObject2 = RandomPosFleeObject();
        fleeObject1 =PlaceFleeObject(posFleeObject1);
        fleeObject2=PlaceFleeObject(posFleeObject2);

        // Create hiding and appearing Objects
        var maxObjects = System.Math.Min(emptyPositions.Count, prefabCount-2);
        for (int i = 0; i < maxObjects; i++)
            spawnRandom(spawnPrefab);
        if (rearrangeObjects)
            StartCoroutine(rearrange());

       

    }

    void Update()
    {

        if (Input.GetKey("up"))
        {
            if (rearrangeDelay > 0)
            {
                rearrangeDelay = rearrangeDelay - 0.1f;
            }
        }

        if (Input.GetKey("down"))
        {
                rearrangeDelay = rearrangeDelay +0.1f;
        }


        if (fleeObject1!=null)
            moveFleeObject(fleeObject1, posFleeObject1);

        if (fleeObject2 != null)
          moveFleeObject(fleeObject2, posFleeObject2);
    }

    //==================================================================
    //Methods used for fleeing objects

    private void moveFleeObject(GameObject obj, Position pos)
    {
        var distance = 1;
        
        if ((Vector3.Distance(player1.transform.position, obj.transform.position) < distance)
            || (Vector3.Distance(player2.transform.position, obj.transform.position) < distance))
        {
            Position tempPos = null;
            List<Position> positions = sensorZoneFleeObject(pos);
            bool allBusy = true;
            int listIndex=0;
            while(allBusy==true && listIndex <4 )
            {
                if (maze[positions[listIndex].x, positions[listIndex].y]==null)
                {
                    allBusy = false;
                    tempPos = positions[listIndex];

                }
                listIndex++;
            }

            if (!allBusy)
            {
               /* while (tempPos == null)
                {
                    int n = random.Next(0, 3);
                    if (maze[positions[n].x, positions[n].y] == null)
                    {
                        tempPos = positions[n];
                    }
                }*/

                // maze[tempPos.x, tempPos.y] = obj;
                //maze[pos.x, pos.y] = null;

                 obj.transform.position = new Vector3(tempPos.x, 0, tempPos.y);
                 maze[tempPos.x, tempPos.y] = obj;
                if (obj == fleeObject1)
                    posFleeObject1 = tempPos;
                else
                    posFleeObject2 = tempPos;
            }
        }

       

        
    }

    private List<Position> sensorZoneFleeObject(Position posObj)
    {
        List<Position> positions = new List<Position>();
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
        emptyPositions.Remove(pos);
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
        maze[pos.x, pos.y].transform.position = new Vector3(pos.x, 0f, pos.y);

        maze[pos.x, pos.y].GetComponentInChildren<Renderer>().material.mainTexture = Resources.Load(reciepList[indexReciepList]) as Texture;
        indexReciepList++;
        Shader.EnableKeyword("_ALPHATEST_ON");
        return maze[pos.x, pos.y];
    }

    private List<Position> currentEmptyTiles {
        get {
            var emptyTiles = new List<Position>();
            for (int i = 1; i < maze.GetLength(0) - 1; i++)
                for (int j = 1; j < maze.GetLength(1) - 1; j++)
                    if(!(i==1&&j==1) && !(i== mazeGenerator.width-2 && j== mazeGenerator.height-2))
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
        maze[position.x, position.y].GetComponentInChildren<Renderer>().material.mainTexture = Resources.Load(reciepList[indexReciepList]) as Texture;
        indexReciepList++;
        Shader.EnableKeyword("_ALPHATEST_ON");
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
