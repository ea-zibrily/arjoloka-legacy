using UnityEngine;
using UnityEngine.UI;
using Arjoloka.Data;

namespace Arjoloka.UI
{
    public class GalleryUIManager : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private GalleryView[] galleryViews;
        [SerializeField] private GameObject galleryPopupUI;
        [SerializeField] private Button backButtonUI;
        [SerializeField] private MenuUIManager menuManager;

        // Methods
        private void OnEnable()
        {
            InitializeGallery();
        }

        private void Start()
        {
            galleryPopupUI.SetActive(false);
            backButtonUI.onClick.AddListener(OnClickBack);
        }

        // Core
        private void InitializeGallery()
        {
            // Chaced
            var container = TempleDataContainer.Instance;
            foreach (var view in galleryViews)
            {
                var data = container.GetTempleDataWithID(view.ViewID);
                if (data == null)
                {
                    Debug.LogWarning($"GalleryView with ID {view.ViewID} not found in TempleDataContainer.");
                    continue;
                }
                view.ModifyItemLock(!data.IsUnlocked);
            }
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
