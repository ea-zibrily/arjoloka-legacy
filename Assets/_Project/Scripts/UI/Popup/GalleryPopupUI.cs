using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arjoloka.UI
{
    public class GalleryPopupUI : BasePopupUI
    {
        [Header("Gallery")]
        [SerializeField] private GalleryData[] galleryDatas;
        [SerializeField] private TextMeshProUGUI tittleTextUI;
        [SerializeField] private TextMeshProUGUI descriptionTextUI;
        [SerializeField] private Image galleryImageUI;

        // Methods
        protected override void InitOnStart()
        {
            base.InitOnStart();

            // Null checker
            if (galleryDatas.Length == 0)
            {
                Debug.LogWarning("Gallery datas not assigned");
                return;
            }
        }

        public void SetPopupData(string galleryID)
        {
            var data = galleryDatas.FirstOrDefault(x => x.GalleryID == galleryID);
            if (data == null)
            {
                Debug.LogWarning($"Data with ID {galleryID} not found");
                return;
            }

            tittleTextUI.text = data.GalleryName;
            descriptionTextUI.text = data.GalleryDescription;
            galleryImageUI.sprite = data.GalleryImage;
        }
    }
}
