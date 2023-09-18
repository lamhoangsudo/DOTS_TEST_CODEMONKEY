using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct RamdomCompoment : IComponentData
{
    public Unity.Mathematics.Random random;
}
