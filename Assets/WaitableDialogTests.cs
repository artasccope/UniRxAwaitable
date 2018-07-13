using System.Collections;
using System.Collections.Generic;
using UnityAsyncAwaitUtil;
using UnityEngine;

public class WaitableDialogTests : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartWait();
    }

    async void StartWait()
    {
        var waitableDialog = WaitableDialog.WaitChoice();
        await waitableDialog;
        
        
        Debug.Log(waitableDialog.Result);
    }
}