using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

namespace Arjoloka.UI
{
    public class ExitPopupUI : BasePopupUI
    {
        private enum ExitPopupType { ExitGame, BackToMenu }

        [Header("Exit Popup")]
        [SerializeField] private ExitPopupType exitPopupType;
        [SerializeField] private Button acceptButtonUI;

        [Foldout("Back To Menu")] [ShowIf("exitPopupType", ExitPopupType.BackToMenu)]
        [SerializeField] private GameObject ingamePanelUI;
        
        [Foldout("Back To Menu")] [ShowIf("exitPopupType", ExitPopupType.BackToMenu)]
        [SerializeField] private MenuUIManager menuManager;


        // Methods
        protected override void InitOnStart()
        {
            base.InitOnStart();
            acceptButtonUI.onClick.AddListener(OnClickAccept);
        }

        private void OnClickAccept()
        {
            switch (exitPopupType)
            {
                case ExitPopupType.ExitGame:
                    Application.Quit();
                    break;

                case ExitPopupType.BackToMenu:
                    menuManager.gameObject.SetActive(true);
                    menuManager.AnimateMoveIn(() =>
                    {
                        gameObject.SetActive(false);
                        ingamePanelUI.SetActive(false);
                    });
                    break;
            }
        }
    }
}
