using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;


    private GameInput _gameInput;
    private void Start()
    {
        _gameInput = GameInput.instance;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        UpdateLookAt();
    }
    private void UpdateLookAt()
    {
        Ray ray = _gameInput.GetMousePos();
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
    }
    private void MovePlayer()
    {
        Vector2 move = _gameInput.MoveInput;
        Vector3 movement = new Vector3(move.x, transform.position.y, move.y);
        agent.Move(movement * agent.speed * Time.fixedDeltaTime);
    }
}
