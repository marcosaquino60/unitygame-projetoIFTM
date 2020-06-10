using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Core;
using NavGame.Managers;

public class CoinController : CollectibleGameObject
{
    public string pickipSound;

    public override void Pickup()
    {
        base.Pickup();
        AudioManager.instance.Play(pickipSound, transform.position);
    }
}