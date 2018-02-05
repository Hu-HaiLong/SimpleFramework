using Yishimu;

public class BGMControl : SingleTon<BGMControl>
{

    public void BGMPlay()
    {
        try
        {
            if (BaseState.Instance.StateId == BaseState.stateId.mission)
            {
                AudioManager.Instance.BGMPlay(AUDIO_DEFINE.AUDIO_FIGHTBG);
            }
            else
            {
                AudioManager.Instance.BGMPlay(AUDIO_DEFINE.AUDIO_GAMEBG);
            }
        }
        catch
        {

        }
    }
}
