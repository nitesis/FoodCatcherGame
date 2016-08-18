﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FoodObjectController : MonoBehaviour
{
    public MazeGenerator mazeGenerator;
    public GameObject spawnPrefab;
    public float rearrangeDelay ;
    public string level;
    public GameObject player1;
    public GameObject player2;
    public ReciepCSVReader reciepCSVReader;
    public Text reciepText;


    private bool rearrangeObjects;
    private bool fleeObjectActive;
    private GameObject[,] maze;
    private List<ObjectContainer> objects = new List<ObjectContainer>();
    private List<Position> emptyPositions;
    private System.Random random = new System.Random();
    private GameObject fleeObject1;
    private Position posFleeObject1;
    private Position posFleeObject2;
    private GameObject fleeObject2;

	private int foodItemCount;
    private List<string> reciepList=new List<string>();
    private List<GameObject> foodObjectList= new List<GameObject>();
    private int prefabCount;
    private int indexReciepList=0;

	//some properties
	public int FoodItemCount
	{
        get { return foodItemCount; }
        set { foodItemCount = value; }
	}

    public int PrefabCount
    {
        get { return prefabCount; }
        set { prefabCount = value; }
    }

    public List<GameObject> FoodObjectList
    {
        get { return foodObjectList; }

    }


    void Start()
    {
        
        reciepText.GetComponent <Text>().text= PlayerPrefs.GetString("reciepDE");
        reciepList = reciepCSVReader.ReciepList;

        //==========================================================

        prefabCount = reciepList.Count;
        foodItemCount = reciepList.Count;
        maze = mazeGenerator.GetMaze();
        emptyPositions = currentEmptyTiles;

        // Create Fleeing Objects
        if (PlayerPrefs.GetFloat("gameOption") >= 1)
            fleeObjectActive = true;
        else
            fleeObjectActive = false;

        if (fleeObjectActive)
        {
            posFleeObject1 = RandomPosFleeObject();
            posFleeObject2 = RandomPosFleeObject();
            fleeObject1 = PlaceFleeObject(posFleeObject1);
            fleeObject2 = PlaceFleeObject(posFleeObject2);
        }
        else
        {
            fleeObject1 = null;
            fleeObject2 = null;
        }

        // Create hiding and appearing Objects

       
            if (PlayerPrefs.GetFloat("gameOption") >= 2)
            rearrangeObjects = true;
            else
            rearrangeObjects = false;

        int maxObjects;

        if (fleeObjectActive)
            maxObjects = System.Math.Min(emptyPositions.Count, prefabCount - 2);
        else
            maxObjects = System.Math.Min(emptyPositions.Count, prefabCount);


        for (int i = 0; i < maxObjects; i++) { 
            spawnRandom(spawnPrefab);
    }
            
        if (rearrangeObjects)
            StartCoroutine(rearrange());
    }

    void Update()
    {
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
            List<int> possibleIndexes = new List<int>();
            while(allBusy==true && listIndex <4 )
            {
                if (maze[positions[listIndex].x, positions[listIndex].y]==null)
                {
                    allBusy = false;
                    possibleIndexes.Add(listIndex);

                }
                listIndex++;
            }

            if (!allBusy)
            {
                tempPos = positions[possibleIndexes[random.Next(0, possibleIndexes.Count - 1)]];
                Vector3 tempVector = new Vector3(tempPos.x, 1, tempPos.y);
                obj.transform.position = new Vector3(tempPos.x, obj.transform.position.y, tempPos.y);
               

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
        GameObject obj= Instantiate(spawnPrefab) as GameObject;
        FoodObjectList.Add(obj);
        maze[pos.x, pos.y] = obj;
        maze[pos.x, pos.y].transform.position = new Vector3(pos.x, 1f, pos.y);

        maze[pos.x, pos.y].GetComponentInChildren<Renderer>().material.mainTexture = Resources.Load(reciepList[indexReciepList]) as Texture;
        maze[pos.x, pos.y].GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>(reciepList[indexReciepList]);

        indexReciepList++;
        Shader.EnableKeyword("_ALPHATEST_ON");
        return maze[pos.x, pos.y];
    }

    //===========================================================================================
    //Methods used for hiding and appearing objects

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
        var obj = (GameObject)Instantiate(prefab);
        foodObjectList.Add(obj);
        obj.transform.position = new Vector3(position.x, obj.transform.position.y, position.y);
        maze[position.x, position.y] = obj;
        maze[position.x, position.y].GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>(reciepList[indexReciepList]);
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
        if (objectContainer.obj != null)
        {
            moveObject(objectContainer.obj.transform, newPosition);
            updateMaze(objectContainer.position, newPosition, objectContainer.obj);
            swapPositions(objectContainer.position, newPosition);
        }
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
