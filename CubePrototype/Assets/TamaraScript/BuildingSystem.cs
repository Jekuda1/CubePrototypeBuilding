using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;
    public GridLayout gridlayout;
    private Grid grid;
    [SerializeField] private Tilemap MainTilemap;
    [SerializeField] private TileBase whiteTile;

    public GameObject prefab1;
    public GameObject prefab2;

    private PlacableObject objectToPlace;
    #region Unity methods
    private void Awake()
    {
        current = this;
        grid = gridlayout.gameObject.GetComponent<Grid>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            InitializeWithObject(prefab1);
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            InitializeWithObject(prefab2);
        }
        if(!objectToPlace)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(CanBePlaced(objectToPlace))
            {
                objectToPlace.Place();
                Vector3Int start = gridlayout.WorldToCell(objectToPlace.GetStartPosition());
                TakeArea(start, objectToPlace.Size);
            }
            else
            {
                Destroy(objectToPlace.gameObject);
            }
           
        }

    }
     #endregion
      #region  Utils

      public static Vector3 GetMouseWorldPosition()
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
      }

      public Vector3 SnapCoordinateToGrid(Vector3 position)
      {
        Vector3Int cellPos = gridlayout.WorldToCell(position);
        position = grid.GetCellCenterWorld(cellPos);
        return position;
      }

      private static TileBase[] GetTileBlock(BoundsInt area, Tilemap tilemap)
      {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
      }
      #endregion

       #region Building Placement

       public void InitializeWithObject(GameObject prefab)
       {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlacableObject>();
        obj.AddComponent<ObjectDrag>();
       }

       private bool CanBePlaced(PlacableObject placableObject)
       {
        BoundsInt area = new BoundsInt();
        area.position = gridlayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = new Vector3Int(area.size.x + 1, area.size.y + 1, area.size.z);
        area.size = placableObject.Size;

        TileBase[] baseArray = GetTileBlock(area, MainTilemap);

        foreach (var tileBase in baseArray)
        {
            if(tileBase == whiteTile)
            {
                return false;
            }
        }
        return true;
       }

       public void TakeArea(Vector3Int start, Vector3Int size)
       {
        MainTilemap.BoxFill(start, whiteTile, start.x, start.y, start.x + size.x, start.y + size.y);
       }
        #endregion

   
}
