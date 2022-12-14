using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;
    public GridLayout gridlayout;
    private Grid grid;
   // [SerializeField] private Tilemap MainTilemap;
  //  [SerializeField] private TileBase whiteTile;

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
      #endregion

       #region Building Placement

       public void InitializeWithObject(GameObject prefab)
       {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlacableObject>();
        obj.AddComponent<ObjectDrag>();
       }
        #endregion

   
}
