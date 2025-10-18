using UnityEngine;

namespace Arjoloka.Data
{
    [CreateAssetMenu( fileName = "TempleData", menuName = "Arjoloka/TempleData", order = 0)]
    public class TempleData : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] private string templeID;
        [SerializeField] private bool isUnlocked;
        [SerializeField] private string templeName;
        [SerializeField] [TextArea(5, 15)] private string templeDescription;
        [SerializeField] [TextArea(5, 15)] private string galleryDescription;
        [SerializeField] private Sprite templeImage;
        
        // Getters
        public string TempleID => templeID;
        public bool IsUnlocked => isUnlocked;
        public string TempleName => templeName;
        public string TempleDescription => templeDescription;
        public string GalleryDescription => galleryDescription;
        public Sprite TempleImage => templeImage;
    }
}
