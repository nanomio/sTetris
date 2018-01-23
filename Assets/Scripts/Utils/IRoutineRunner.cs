using UnityEngine;
using System.Collections;

public interface IRoutineRunner
{
    void Execute(IEnumerator coroutine);
}
