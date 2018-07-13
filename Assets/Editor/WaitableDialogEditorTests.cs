using System;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityAsyncAwaitUtil;
using Assert = NUnit.Framework.Assert;


public class WaitableDialogEditorTests
{
    [Test]
    public async Task _waitalble_dialog_test_()
    {
        Task<string> choice = null;
        Task.Run(() =>
        {
            choice = WaitableDialog.WaitChoice();
        });


        await DelayALittle(1.0, () =>
        {
            VmManager.Get<WaitableDialog>().Choose("1");
        });

        Assert.AreEqual(choice.Result, "1");
        
        return;
    }


    [Test]
    public async Task _task_test_()
    {
        bool executed = false;
        await DelayALittle(1, () => { executed = true; });

        Assert.AreEqual(executed, false);
    }

    private async Task DelayALittle(double delay, Action action)
    {
        await Task.Delay(TimeSpan.FromSeconds(delay));
        action?.Invoke();
        await Task.Delay(0);
    }
}