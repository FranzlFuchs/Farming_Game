using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Tool : ITool
{
    public ToolSO ToolSO;

    private IState _currentState;
    public void ChangeState(IState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        newState.Enter();
    }


}
