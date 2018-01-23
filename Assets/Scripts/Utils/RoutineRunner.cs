using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutineWorker : MonoBehaviour
{

}

public class RoutineRunner : IRoutineRunner
{
    private readonly RoutineWorker _worker;

    public RoutineRunner()
    {
        var go = new GameObject("CoroutineWorker");

        _worker = go.AddComponent<RoutineWorker>();
    }

    #region IExecuter implementation

    public void Execute(IEnumerator coroutine)
    {
        _worker.StartCoroutine(coroutine);
    }

    #endregion
}