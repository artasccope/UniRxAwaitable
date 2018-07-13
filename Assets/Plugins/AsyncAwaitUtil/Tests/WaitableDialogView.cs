using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UnityAsyncAwaitUtil
{

    public class WaitableDialogView:MonoBehaviour
    {
        public List<Button> buttons;

        public WaitableDialog ViewModel { get; set; }

        private void Awake()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                var ii = i;
                buttons[i].onClick.AddListener(() =>
                {
                    ViewModel.Choose(ii.ToString());
                    Destroy(gameObject);
                });
            }
        }
    }
}