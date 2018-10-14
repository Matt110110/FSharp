# FSharp
Collection of all misc projects in F#.

## 1. Project FuelManagement
The objective is to write a simple application that can drive the car to various destinations without running out of petrol.
1. Your car starts with 100 units of petrol.
2. The user can drive to one of four destinations. Each destination will consume a different ammount of petrol:
    1. Home: 25 units
    2. Office: 50 units
    3. Stadium: 25 units
    4. Petrol station: 10 units
3. If the user tries to drive anywhere else, the system will reject the request.
4. If the user tries to drive somewhere and doesn't have enough petrol, the system will reject the request.
5. When the user travels to the petrol station, the ammount of petrol in the car should increase by 50 units.