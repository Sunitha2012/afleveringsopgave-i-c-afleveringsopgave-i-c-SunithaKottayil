                ┌────────────────────┐
                │      Program       │
                │  (Main method)     │
                └─────────┬──────────┘
                          ▼
                ┌────────────────────┐
                │       Game         │
                │   StartGame()      │
                └─────────┬──────────┘
                          ▼
                ┌────────────────────┐
                │      Word          │
                │  GetRandomWord()   │
                └─────────┬──────────┘
                          ▼
                ┌────────────────────┐
                │     Status         │
                │ DrawHangman()      │
                │ ShowProgress()     │
                └─────────┬──────────┘
                          ▼
                ┌────────────────────┐
                │   Game Loop        │
                │ - Ask letter       │
                │ - Check letter     │
                │ - Update progress  │
                │ - Update wrongs    │
                │ - Draw status      │
                └─────────┬──────────┘
                          ▼
                ┌────────────────────┐
                │ Win or Lose Check  │
                └─────────┬──────────┘
                          ▼
                ┌────────────────────┐
                │      End Game      │
                └────────────────────┘
