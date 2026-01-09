using UnityEngine;
using System;

public class AssetBundleTest : MonoBehaviour
{
    [Serializable]
    public class TestClass
    {
        public string testString;
        public int intTest;
        public bool boolTest;
    }
    
    [SerializeField]
    public TestClass testSerializedField;
}
