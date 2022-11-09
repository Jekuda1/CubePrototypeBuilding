using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    private Building _placedBuilding = null;
     private Ray _ray;
    private RaycastHit _raycastHit;
    private Vector3 _lastPlacementPosition;

    void Start()
    {
        // for now, we'll automatically pick our first
        // building type as the type we want to build
        _PreparePlacedBuilding(0);
    }

    void Update()
    {
        if (_placedBuilding != null)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                _CancelPlacedBuilding();
                return;
            }

             _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(
                _ray,
                out _raycastHit,
                1000f,
                Globals.TERRAIN_LAYER_MASK
            ))
            {
                _placedBuilding.SetPosition(_raycastHit.point);
                if (_lastPlacementPosition != _raycastHit.point)
                {
                    _placedBuilding.CheckValidPlacement();
                }
                _lastPlacementPosition = _raycastHit.point;
            }
            if (_placedBuilding.HasValidPlacement && Input.GetMouseButtonDown(0))
            {
                // place building
            }
        }
    }

    void _PreparePlacedBuilding(int buildingDataIndex)
    {
        // destroy the previous "phantom" if there is one
       /* if (_placedBuilding != null)
        {
            Destroy(_placedBuilding.Transform.gameObject);
        }*/
        Building building = new Building(
            Globals.BUILDING_DATA[buildingDataIndex]
        );
        building.Transform.GetComponent<BuildingManagerr>().Initialize(building);
        _placedBuilding = building;
        _lastPlacementPosition = Vector3.zero;
    }

    void _CancelPlacedBuilding()
    {
        // destroy the "phantom" building
        Destroy(_placedBuilding.Transform.gameObject);
        _placedBuilding = null;
    }
}
