namespace NativeCode.Mobile.AppCompat.Renderers.Renderers
{
    using System;

    using Android.Util;

    using JavaObject = Java.Lang.Object;

    public class DynamicAttributeSet : JavaObject, IAttributeSet
    {
        public int AttributeCount { get; private set; }

        public string ClassAttribute { get; private set; }

        public string IdAttribute { get; private set; }

        public string PositionDescription { get; private set; }

        public int StyleAttribute { get; private set; }

        public bool GetAttributeBooleanValue(int index, bool defaultValue)
        {
            throw new NotImplementedException();
        }

        public bool GetAttributeBooleanValue(string @namespace, string attribute, bool defaultValue)
        {
            return defaultValue;
        }

        public float GetAttributeFloatValue(int index, float defaultValue)
        {
            return defaultValue;
        }

        public float GetAttributeFloatValue(string @namespace, string attribute, float defaultValue)
        {
            return defaultValue;
        }

        public int GetAttributeIntValue(int index, int defaultValue)
        {
            return defaultValue;
        }

        public int GetAttributeIntValue(string @namespace, string attribute, int defaultValue)
        {
            return defaultValue;
        }

        public int GetAttributeListValue(int index, string[] options, int defaultValue)
        {
            return defaultValue;
        }

        public int GetAttributeListValue(string @namespace, string attribute, string[] options, int defaultValue)
        {
            return defaultValue;
        }

        public string GetAttributeName(int index)
        {
            throw new NotImplementedException();
        }

        public int GetAttributeNameResource(int index)
        {
            throw new NotImplementedException();
        }

        public int GetAttributeResourceValue(int index, int defaultValue)
        {
            return defaultValue;
        }

        public int GetAttributeResourceValue(string @namespace, string attribute, int defaultValue)
        {
            return defaultValue;
        }

        public int GetAttributeUnsignedIntValue(int index, int defaultValue)
        {
            return defaultValue;
        }

        public int GetAttributeUnsignedIntValue(string @namespace, string attribute, int defaultValue)
        {
            return defaultValue;
        }

        public string GetAttributeValue(int index)
        {
            throw new NotImplementedException();
        }

        public string GetAttributeValue(string @namespace, string name)
        {
            throw new NotImplementedException();
        }

        public int GetIdAttributeResourceValue(int defaultValue)
        {
            throw new NotImplementedException();
        }
    }
}