## 【技術脈絡】

這段內容出自 React 官方文件，主題是 **React Hooks 中 `useEffect` 的清理機制（Cleanup）**，屬於 React 元件生命週期與副作用（side effect）管理的核心觀念，閱讀時需要具備 `useEffect` 基本用法、元件重新渲染（re-render）流程，以及 React 18 開發模式（Strict Mode）下「刻意執行兩次」行為的背景知識。

## 【完整示例代碼】

```jsx
import { useEffect } from 'react';
import { createConnection } from './chat.js';

function ChatRoom({ roomId }) {
  useEffect(() => {
    const connection = createConnection(roomId);
    connection.connect();
    return () => {
      connection.disconnect();
    };
  }, [roomId]);
  // ...
}
```

## 【中文文件譯文】

### 清理 Effect（Cleaning up an Effect）

想像有一個 `ChatRoom` 元件，只要它顯示在畫面上，就需要連線到聊天伺服器。這裡提供了一組 API，讓你可以透過 `createConnection()` 物件來建立連線與中斷連線。每當這個元件重新渲染時，React 會先執行清理函式（cleanup function，如果你有提供的話），這個清理函式會使用「舊的」props 與 state；接著才會用「新的」props 與 state 執行你的 Effect。如果忘記寫清理函式，可能會導致你的應用程式在元件每次重新渲染時都開啟一個新連線，卻從來沒有關閉舊連線，長期下來就會造成 socket 與記憶體的洩漏。

```jsx
import { useEffect } from 'react';
import { createConnection } from './chat.js';

function ChatRoom({ roomId }) {
  useEffect(() => {
    const connection = createConnection(roomId);
    connection.connect();
    return () => {
      connection.disconnect();
    };
  }, [roomId]);
  // ...
}
```

在開發環境（development）中，React 會刻意多執行一次「執行 Effect、再清理 Effect」的流程，然後才真正執行 Effect。這是一種壓力測試（stress-test），用來驗證你的清理邏輯是否確實與建立邏輯互相對應。如果你觀察到 `connect()` 與 `disconnect()` 是成對呼叫，且呼叫次數符合預期，就代表你的邏輯是正確的。

## 【核心技術拆解】

- **Effect 的執行時機**：`useEffect` 的回呼函式（callback）會在元件渲染完成、畫面更新到 DOM 之後才非同步執行，而不是在渲染過程中同步執行。這是它跟直接寫在函式元件主體裡的程式碼最大的差異。

- **清理函式（cleanup function）的觸發規則**：`useEffect` 回呼函式如果 `return` 了一個函式，這個函式就是清理函式。React 會在以下兩個時機呼叫它：
  1. 元件因為依賴項（dependency，也就是 `[roomId]` 陣列裡的值）改變而重新執行 Effect 之前，先用「上一輪」的 `roomId` 呼叫清理函式。
  2. 元件真正從畫面上卸載（unmount）時。

- **「先清理、再建立」的順序**：文件特別強調順序是「先跑清理函式（用舊的 props/state），再跑新的 Effect（用新的 props/state）」。這代表每次 `roomId` 改變時，實際發生的順序是：`disconnect()`（舊連線）→ `createConnection(新roomId)` → `connect()`（新連線）。這個順序保證了同一時間點最多只有一條有效連線。

- **依賴陣列 `[roomId]` 的作用**：這個陣列告訴 React「只有當 `roomId` 的值改變時，才需要重新跑一次 Effect（含清理）」。如果 `roomId` 沒變，即使元件因為其他 state 改變而重新渲染，這個 Effect 也不會重新執行，避免不必要的重連。

- **開發模式下的「執行兩次」機制（Strict Mode 效應）**：在 React 18 的開發環境（且啟用 Strict Mode）下，React 會對每個 Effect 多做一輪「掛載 → 卸載」的模擬，藉此提前暴露「建立」與「清理」邏輯不對稱的 bug。實際發生的呼叫序列會是：
  `connect()`（第一次掛載）→ `disconnect()`（模擬卸載）→ `connect()`（真正掛載）
  這只發生在開發環境，正式環境（production build）不會有這個額外的模擬。

## 【最佳實踐與地雷提示】

- **忘記寫清理函式 = 連線洩漏**：如果 `useEffect` 沒有 `return` 清理函式，每次 `roomId` 改變都會呼叫一次 `createConnection().connect()`，但舊的連線永遠不會 `disconnect()`。長時間下來會累積大量未關閉的 socket，造成記憶體洩漏、伺服器端連線數暴增，甚至觸發後端的連線數上限錯誤。

- **依賴陣列一定要寫完整**：範例中 `[roomId]` 是依賴陣列，若你的 Effect 內部還用到其他外部變數（例如某個 callback 或物件），卻沒有放進依賴陣列，會導致 Effect 使用到過期的閉包值（stale closure），造成連線邏輯用的是舊的資料卻不會重新執行 Effect 去修正。建議搭配 ESLint 的 `react-hooks/exhaustive-deps` 規則來強制檢查。

- **不要把開發環境的「執行兩次」誤判為 bug**：很多初學者會看到 console 印出 `connect()` / `disconnect()` 各兩次而以為程式碼有問題，實際上這是 React 18 Strict Mode 刻意設計的行為，用來幫你提前抓出「清理邏輯沒有正確對應建立邏輯」的問題。正確的判斷方式是看呼叫是否「成對出現」，而不是看「只出現一次」。

- **`createConnection` 若是重量級資源要注意重建成本**：如果 `roomId` 頻繁變動（例如綁定在使用者輸入框上即時觸發），每次變動都會整個「斷線再連線」，可能造成不必要的效能開銷或使用者體感延遲。實務上可以考慮用 debounce 或 `useDeferredValue` 來降低 `roomId` 變動的頻率，避免頻繁重建連線。

- **清理函式中要處理非同步競態（race condition）**：本範例的 `connection.disconnect()` 是同步呼叫，風險較低；但如果 Effect 內部是非同步操作（例如 `fetch`），清理函式應該搭配一個「是否已取消」的旗標（flag）或 `AbortController`，避免舊的非同步請求在元件狀態已經改變後才回傳，寫入了過期的 state（stale state 更新)。
