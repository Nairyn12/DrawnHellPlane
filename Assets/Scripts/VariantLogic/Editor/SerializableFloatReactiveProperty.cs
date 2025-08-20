using UniRx;
using UnityEngine;

[System.Serializable]
public class SerializableFloatReactiveProperty : FloatReactiveProperty
{
    public SerializableFloatReactiveProperty() : base() { }
    public SerializableFloatReactiveProperty(float initialValue) : base(initialValue) { }
}

