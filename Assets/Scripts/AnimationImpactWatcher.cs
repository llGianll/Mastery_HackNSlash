using System;
using UnityEngine;

public class AnimationImpactWatcher : MonoBehaviour
{
    public event Action OnImpact = delegate { };

    /// <summary>
    /// Called by Animation
    /// </summary>
    private void Impact()
    {
        OnImpact();
    }
}
