using System.Collections.Generic;
using UnityEngine;

public class Brush_Bronze : MonoBehaviour
{
    [SerializeField] GameObject brushPrefab;
    [SerializeField] GameObject[] specificObject;

    Dictionary<int, GameObject> activeTouches = new Dictionary<int, GameObject>();

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    CheckAndCreateLine(touch);
                    break;

                case TouchPhase.Moved:
                    UpdateLines(touch);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    FinishLines(touch);
                    break;
            }
        }
    }

    void CheckAndCreateLine(Touch touch)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            if (IsInSpecificObjectList(hitObject))
            {
                activeTouches.Add(touch.fingerId, hitObject);
                ApplyColorToSpecificObject(hitObject);
            }
        }
    }

    bool IsInSpecificObjectList(GameObject obj)
    {
        foreach (GameObject specificObj in specificObject)
        {
            if (obj == specificObj)
            {
                return true;
            }
        }
        return false;
    }

    void UpdateLines(Touch touch)
    {
        if (activeTouches.ContainsKey(touch.fingerId))
        {
            GameObject hitObject = activeTouches[touch.fingerId];
            UpdateColorOnSpecificObject(hitObject, touch);
        }
    }

    void UpdateColorOnSpecificObject(GameObject obj, Touch touch)
    {
        Renderer objectRenderer = obj.GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            Renderer brushRenderer = brushPrefab.GetComponent<Renderer>();
            if (brushRenderer != null)
            {
                Material brushMaterial = brushRenderer.sharedMaterial;
                if (brushMaterial != null)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

                    if (hit.collider != null && hit.collider.gameObject == obj)
                    {
                        objectRenderer.material = brushMaterial; // Aplicar o material compartilhado do pincel ao objeto específico
                    }
                }
            }
        }
    }

    void FinishLines(Touch touch)
    {
        if (activeTouches.ContainsKey(touch.fingerId))
        {
            activeTouches.Remove(touch.fingerId);
        }
    }

    void ApplyColorToSpecificObject(GameObject obj)
    {
        Renderer objectRenderer = obj.GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            Renderer brushRenderer = brushPrefab.GetComponent<Renderer>();
            if (brushRenderer != null)
            {
                Material brushMaterial = brushRenderer.sharedMaterial;
                if (brushMaterial != null)
                {
                    objectRenderer.material = brushMaterial; // Aplicar o material compartilhado do pincel ao objeto específico
                }
            }
        }
    }

    Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 10f));
    }
}