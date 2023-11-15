using System.Collections.Generic;
using UnityEngine;

public class Brush_Bronze : MonoBehaviour
{
    [SerializeField] GameObject brushPrefab;
    [SerializeField] GameObject[] specificObject;

    List<LineRenderer> activeLines = new List<LineRenderer>();

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        CheckAndCreateLine(touch.position);
                        break;

                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        UpdateLines(touch.position);
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        FinishLines();
                        break;
                }
            }
        }
    }

    void CheckAndCreateLine(Vector2 touchPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPosition), Vector2.zero);
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            if (IsInSpecificObjectList(hitObject))
            {
                CreateNewLine(touchPosition);
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

    void CreateNewLine(Vector2 touchPosition)
    {
        GameObject brushInstance = Instantiate(brushPrefab, GetWorldPosition(touchPosition), Quaternion.identity);
        LineRenderer newLine = brushInstance.GetComponent<LineRenderer>();
        activeLines.Add(newLine);
        newLine.positionCount = 1;
        newLine.SetPosition(0, GetWorldPosition(touchPosition));
    }

    void UpdateLines(Vector2 touchPosition)
    {
        // Lógica de atualização das linhas existentes
    }

    void FinishLines()
    {
        // Lógica de finalização das linhas
    }

    Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 10f));
    }
}