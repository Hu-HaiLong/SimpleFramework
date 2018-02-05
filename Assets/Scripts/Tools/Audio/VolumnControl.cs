using UnityEngine;
using UnityEngine.UI;
public abstract class VolumnControl : MonoBehaviour{

    private void Update()
    {
        ChangeVolume();
    }

    public abstract void ChangeVolume();

}
