﻿using UnityEngine;
public partial class Health
{
    static class LayerMaskUtil
    {
       public static bool ContainsLayer(LayerMask layerMask, GameObject gameObject)
        {
            return (layerMask.value & 1 << gameObject.layer) > 0;
        }
    }
}
