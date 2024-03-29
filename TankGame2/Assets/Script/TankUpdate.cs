using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerup/UpdateTank")]
public class TankUpdate : PowerUpEffect
{

    public Sprite newTank;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<SpriteRenderer>().sprite = newTank;
    }
}
