using Yishimu;

public class BaseState : SingleTon<BaseState>
{ 
    
    StateMachine _state;

    public enum stateId
    {
        init,
        startScene,
        main,
        mission,
        packge,
        store,
        pet
    }

    private stateId _stateId;

    public stateId StateId
    {
        get
        {
            return _stateId;
        }

        set
        {
            _stateId = value;
        }
    }

    public BaseState()
    {
       // _state = new StartState(this);
    }

    public void SetState(StateMachine newState)
    {
        _state = newState;
    }

    public void Enter()
    {

    }

    public void Update()
    {
        _state.Enter();
    }

}
