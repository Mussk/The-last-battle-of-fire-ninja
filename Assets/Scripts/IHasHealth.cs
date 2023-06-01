using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasHealth
{
    int CurrentHealth { get; }
    int CurrentMaxHealth { get; }

}
