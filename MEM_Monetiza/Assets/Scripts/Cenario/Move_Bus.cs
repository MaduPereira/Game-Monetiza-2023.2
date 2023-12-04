using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_Bus : MonoBehaviour
{
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private Transform[] waypoints;

    private int currentCheckpointIndex = -1;
    private int currentWaypointIndex = 0;

    [SerializeField] private Rigidbody2D rb;

    private float distancia = 0.05f;
    private float velocidade = 5;
    private Vector2 direcao;

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            Movimento();
        }
    }

    private void Movimento()
    {
        if (currentCheckpointIndex == -1 || currentWaypointIndex >= waypoints.Length)
        {
            return; // Não há um destino definido ou já alcançou todos os waypoints
        }

        direcao = ((Vector2)waypoints[currentWaypointIndex].position - rb.position).normalized;
        rb.MovePosition(rb.position + direcao * velocidade * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= distancia)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                if (currentCheckpointIndex < checkpoints.Length - 1)
                {
                    currentCheckpointIndex++;
                    currentWaypointIndex = 0;
                }
                else
                {
                    currentCheckpointIndex = -1; // Chegou ao final de todos os waypoints
                }
            }
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                if (hit.collider != null)
                {
                    Transform objectClicked = hit.transform;
                    MoveToNearestWaypoint(objectClicked);
                }
            }
        }
    }

    private void MoveToNearestWaypoint(Transform clickedObject)
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (checkpoints[i] == clickedObject)
            {
                currentCheckpointIndex = i;
                currentWaypointIndex = 0;

                // Definir os waypoints correspondentes ao checkpoint clicado
                int startingWaypointIndex = i * waypoints.Length;
                int endingWaypointIndex = Mathf.Min(startingWaypointIndex + waypoints.Length, waypoints.Length);

                for (int j = startingWaypointIndex; j < endingWaypointIndex; j++)
                {
                    if (IsOnTheRightSide(clickedObject.position, waypoints[j].position))
                    {
                        currentWaypointIndex = j;
                        break;
                    }
                }
                return;
            }
        }
    }

    private bool IsOnTheRightSide(Vector2 clickedPos, Vector2 waypointPos)
    {
        // Verifica se o waypoint está no lado direito do objeto clicado
        return Vector2.Dot(clickedPos - (Vector2)transform.position, transform.up) > 0;
    }
}
