using UnityEngine;
using System.Collections;
using DG.Tweening;
using Matcha.Lib;


public class GameInit : BaseBehaviour
{
    void Awake()
    {
        // initialize DOTween before first use.
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(2000, 300);

        // seed Random with current seconds;
        Random.seed = (int)System.DateTime.Now.Ticks;

        // DOTween.SetTweensCapacity(2000, 300);

        MLib.IgnoreLayerCollision2D("BodyCollider", "Platform", true);
        MLib.IgnoreLayerCollision2D("BodyCollider", "One-Way Platform", true);
        MLib.IgnoreLayerCollision2D("WeaponCollider", "Platform", true);
        MLib.IgnoreLayerCollision2D("WeaponCollider", "One-Way Platform", true);
    }
}
