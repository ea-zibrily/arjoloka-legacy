using UnityEngine;
using UnityEngine.UI;

namespace Arjoloka.UI
{
    public class ExitPopupUI : BasePopupUI
    {
        // Fields
        [SerializeField] private Button acceptButtonUI;

        // Methods
        protected override void InitOnStart()
        {
            base.InitOnStart();
            acceptButtonUI.onClick.AddListener(OnClickAccept);
        }

        private void OnClickAccept()
        {
            Application.Quit();
        }
    }
}
