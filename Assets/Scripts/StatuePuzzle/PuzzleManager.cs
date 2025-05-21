
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public bool IsSolved;

    [SerializeField] private UnityEvent _puzzleSolvedAction;
    [SerializeField] private UnityEvent _puzzleUnSolvedAction;

    [SerializeField] private List<PuzzlePiece> _puzzlePieces = new();

    [SerializeField]
    private GameObject table;

    public bool completed;

    [SerializeField]
    private Transform openPoint;
    [SerializeField]
    private int speed = 1;

    [SerializeField] private AudioSource puzzlefailedSound;
    [SerializeField] private AudioSource puzzlecompletedSound;

    private void Awake() {
        foreach (var goal in _puzzlePieces) {
            if (goal != null) {
                goal.CheckSolution += CheckIfSolved;
            }
        }
    }

    private void Update()
    {
        if (completed)
        {
            table.transform.position = Vector3.MoveTowards(table.transform.position, openPoint.position, speed * Time.deltaTime);
        }
    }

    private void CheckIfSolved() {
        IsSolved = true;
        foreach (var goal in _puzzlePieces) {
            if (goal != null && !goal.IsSolved) {
                IsSolved = false;
            }
        }

        if (IsSolved) {
            _puzzleSolvedAction?.Invoke();
            completed = true;
            puzzlecompletedSound.Play();
        } else {
            _puzzleUnSolvedAction?.Invoke();
        }
    }
}
