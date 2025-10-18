using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Arjoloka.Data;

namespace Arjoloka.UI
{
    public class GalleryPopupUI : BasePopupUI
    {
        [Header("Gallery")]
        [SerializeField] private TextMeshProUGUI tittleTextUI;
        [SerializeField] private TextMeshProUGUI descriptionTextUI;
        [SerializeField] private Image galleryImageUI;

        // Methods
        protected override void InitOnStart()
        {
            base.InitOnStart();

            // Null checker
            if (TempleDataContainer.Instance.IsTempleDatasNull())
            {
                Debug.LogWarning("Temple datas not assigned");
                return;
            }
        }

        public void SetPopupData(string galleryID)
        {
            var data = TempleDataContainer.Instance.GetTempleDataWithID(galleryID);
            if (data == null)
            {
                Debug.LogWarning($"Data with ID {galleryID} not found");
                return;
            }

            tittleTextUI.text = data.TempleName;
            descriptionTextUI.text = data.GalleryDescription;
            galleryImageUI.sprite = data.TempleImage;
        }
    }
}
