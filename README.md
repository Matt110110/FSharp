# FSharp
Collection of all Capstone projects using F#. Each capstone project includes more and more F# only features.

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

## 2. Simple Bank account system
The objective is to write a simple API that then can be implemented by any F# or other Dot.Net projects.
1. The application should allow a customer to deposit and withdraw from an account that the customer owns, and maintain a running total of the balance in the account. (For now only in memory and gets flushed away when the program is terminated.)
2. If the customer tries to withdraw more money than is in the account, then the transaction is declined and an error message is shown to the customer.
3. The system should write out all transactions to a data store, and the datastore should be pluggable (filesystem, console and so on)
4. It should be possible to access the code API and implement it in a program. (Here a console application is used for that purpose.)
5. On startup, the customer details are entered and stays in memory till the termination of the program. Reading data from a database and updating that DB is out of the scope of this project.
### Scope for further development
* Opening multiple accounts
* Reading data from filesystem
* Warning the user if the user tries to overdraw the account

## 3. Adding more features to the Simple Bank account system
The objective of this capstone project is to extend the functionality of the Bank account system previously built in the Capstone 2 project. The changes to be made in this project are:
1. Updating the main command handling routine to eliminate mutable variables
2. Sorting a serialized transaction log to disk for each customer
3. Rehydrating historical transactions and building up-to-date account by using sequence operations