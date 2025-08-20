using UniRx;

[System.Serializable]
internal class SerializableFloatReactiveProperty : FloatReactiveProperty
{
    public SerializableFloatReactiveProperty() : base() { }
    public SerializableFloatReactiveProperty(float initialValue) : base(initialValue) { }

    //public static implicit operator float(SerializableFloatReactiveProperty prop) => prop.Value;

    //// Преобразование ИЗ стороннего типа (float -> MyReactiveProperty)
    //public static implicit operator SerializableFloatReactiveProperty(float value) => 
    //    new SerializableFloatReactiveProperty(value);
}