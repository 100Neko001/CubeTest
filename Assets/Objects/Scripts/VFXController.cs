using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    [SerializeField] private VisualEffect vfx;

    // VFXのOnPlayイベントを呼び出すメソッド
    public void PlayVFX()
    {
        if (vfx != null)
        {
            vfx.SendEvent("OnPlay");
        }
    }
}