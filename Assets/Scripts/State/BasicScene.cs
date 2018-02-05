
using UnityEngine;
using Yishimu;

public class BasicScene: SingleTonMono<BasicScene>
{
    private BaseState _state;


    public GameObject startScene;
    public GameObject main;
    public GameObject mission;
    public GameObject package;
    public GameObject store;
    public GameObject pet;
    public GameObject interlude;
    [HideInInspector]
    public bool isCanState = false;


    void Start()
    {
        if (isCanState)
        {
            _state = new BaseState();
            _state.StateId = BaseState.stateId.init;
        }
    }

    void Update()
    {
        if (isCanState)
        {
            _state.Update();
        }
    }
}