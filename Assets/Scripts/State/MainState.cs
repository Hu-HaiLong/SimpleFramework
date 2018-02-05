using System.Collections;
using Yishimu;
using UnityEngine;

public class MainState : StateMachine
{
    private BaseState _state;

    public MainState(BaseState state)
    {
        _state = state;
        BaseState.Instance.StateId =  BaseState.stateId.main;
        Debug.Log("------------------------ in MainState~!");
    }

    public void Update()
    {

    }

    public void Enter()
    {

        //if (...)
        //{
        //    _state.SetState(new MissionState(_state));            
        //}
    }
}