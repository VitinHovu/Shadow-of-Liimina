using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initValue;
    public Vector2 defaultValue;

    public void OnAfterDeserialize()
    {
        initValue = defaultValue;
    }

    public void OnBeforeSerialize() { }
}
