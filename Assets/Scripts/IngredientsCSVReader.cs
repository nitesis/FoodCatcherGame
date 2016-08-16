
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IngredientsCSVReader : MonoBehaviour
{
    public TextAsset file;
    private List<string> ingredientList = new List<string>();

    public List<string> IngredientList
    {
        get { return ingredientList; }
    }



    void Start()
    {
        Load(file);
    }
     
    public class Row
    {
        public string NameEn;
        public string NameDe;

    }

    List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.NameEn = grid[i][0];
            row.NameDe = grid[i][1];

            rowList.Add(row);
        }
        isLoaded = true;
    }

    public int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public Row Find_NameEn(string find)
    {
        return rowList.Find(x => x.NameEn == find);
    }
    public List<Row> FindAll_NameEn(string find)
    {
        return rowList.FindAll(x => x.NameEn == find);
    }
    public Row Find_NameDe(string find)
    {
        return rowList.Find(x => x.NameDe == find);
    }
    public List<Row> FindAll_NameDe(string find)
    {
        return rowList.FindAll(x => x.NameDe == find);
    }

}