using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurretSelection : MonoBehaviour
{
    public GameObject[] turretPrefabs;
    public Button[] turretButtons;

    private GameObject selectedTurret;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        for (int i = 0; i < turretButtons.Length; i++)
        {
            int turretIndex = i;
            turretButtons[i].onClick.AddListener(() => SelectTurret(turretIndex));
        }
    }

    private void Update()
    {
        if (selectedTurret != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 hitPoint = hit.point;
                hitPoint.y = Terrain.activeTerrain.SampleHeight(hitPoint);

                if (Input.GetMouseButtonDown(0)) 
                {
                    
                    selectedTurret.transform.position = hitPoint;
                    selectedTurret = null;
                }
                else
                {
                    selectedTurret.transform.position = hitPoint; 
                }
            }
        }
    }

    public void SelectTurret(int index)
    {
        if (selectedTurret != null)
        {
            Destroy(selectedTurret);
        }

        selectedTurret = Instantiate(turretPrefabs[index]);
    }
}