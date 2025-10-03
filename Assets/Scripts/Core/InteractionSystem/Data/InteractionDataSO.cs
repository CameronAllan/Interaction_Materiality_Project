using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDataSO : ScriptableObject
{
    //Should this just be a Prefab?

    public float MaxEffectTime;

    public List<EffectSlot> EffectSlotPrefabs;
    public List<Effect> EffectPrefabs;


}
