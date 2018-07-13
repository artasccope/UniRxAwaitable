using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityAsyncAwaitUtil
{
    public class WaitableDialog
    {

        private WaitableDialogView View;
        
        public WaitableDialog()
        {
            View = MonoBehaviour.Instantiate(Resources.Load<WaitableDialogView>("waitableDialog"));
            View.ViewModel = this;
        }

        public string Result;
        
        public bool clicked = false;


        public void Choose(string choice)
        {
            this.Result = choice;
            this.clicked = true;
        }

        private IEnumerator<string> WaitChoiceIter()
        {
            while (!clicked)
            {
                yield return null;
            }

            yield return Result;
        }

        public static async Task<string> WaitChoice()
        {
            var dialog = new WaitableDialog();
            
            VmManager.Add<WaitableDialog>(dialog);
            
            return await dialog.WaitChoiceIter();
        }

    }
}