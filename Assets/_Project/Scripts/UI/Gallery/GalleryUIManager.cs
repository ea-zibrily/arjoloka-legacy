using UnityEngine;
using UnityEngine.UI;

namespace Arjoloka.UI
{
    public class GalleryUIManager : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private GalleryView[] galleryViews;
        [SerializeField] private Button backButtonUI;
        [SerializeField] private MenuUIManager menuManager;

        // Methods
        private void Start()
        {
            backButtonUI.onClick.AddListener(OnClickBack);
        }

        // Core
        private void InitializeGallery()
        {
            
        }

        private void OnClickBack()
        {
            backButtonUI.interactable = false;
            menuManager.gameObject.SetActive(true);
            
            menuManager.AnimateMoveIn(() =>
            {
                backButtonUI.interactable = true;
                gameObject.SetActive(false);
            });
        }
    }
}
