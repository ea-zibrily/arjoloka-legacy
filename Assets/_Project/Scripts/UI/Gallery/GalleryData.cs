using UnityEngine;

namespace Arjoloka.UI
{
    [CreateAssetMenu( fileName = "GalleryData", menuName = "Arjoloka/GalleryData", order = 0)]
    public class GalleryData : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] private string galleryID;
        [SerializeField] private string galleryName;
        [SerializeField] [TextArea(10, 20)] private string galleryDescription;
        [SerializeField] private Sprite galleryImage;
        
        // Getters
        public string GalleryID => galleryID;
        public string GalleryName => galleryName;
        public string GalleryDescription => galleryDescription;
        public Sprite GalleryImage => galleryImage;
    }
}
