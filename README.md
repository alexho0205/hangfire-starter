# hangfire starter

## 說明
 - 建立 hangfire with sqlite 
 - 建立 job服務
    - DummyHandler.cs
      - EchoCurrentTime (每分鐘寫入目前時間)
      - ThrowException ( 拋出錯誤,retry 1次 )
 - 起用 dashboard
