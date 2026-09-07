
using Microsoft.VisualStudio.Threading;

// JoinableTaskContext 負責追蹤主執行緒(UI 執行緒)與背景執行緒的關係,
// JoinableTaskFactory 則用它來啟動、管理具備死結防護能力的非同步工作。
JoinableTaskFactory factory = new JoinableTaskFactory(new JoinableTaskContext());
JoinableTaskContext joinableTaskContext = new JoinableTaskContext();

// factory.Run 會同步阻塞呼叫端執行緒,直到 lambda 內的工作完全結束。
// 若在有 SynchronizationContext 的環境(如 WPF/WinForms UI 執行緒)執行,
// 它會啟動協同訊息幫浦(message pump),讓等待中的執行緒仍能處理排回來的
// continuation,藉此避免「阻塞等待 + await 需要切回原執行緒」造成的死結。
factory.Run(async () =>
{
    Console.WriteLine("Hello World!");
    await Task.Delay(1000);
    Console.WriteLine("Hello Again!");
}
);

// Task.Run 把 lambda 丟到 ThreadPool 執行,外層用 await 非同步等待完成,
// 不會阻塞呼叫端執行緒;但它不具備 JoinableTaskFactory 的死結防護機制。
await Task.Run(async () =>
{
    Console.WriteLine("Hello World!");
    await Task.Delay(1000);
    Console.WriteLine("Hello Again!");

});

// 本程式是 Console 應用程式,沒有 SynchronizationContext,
// 因此以上兩種寫法在此看不出死結風險的差異,效果上大致相同。
System.Console.WriteLine("process is done!");