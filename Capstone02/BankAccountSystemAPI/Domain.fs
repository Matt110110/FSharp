namespace BankAccountSystemAPI

type Customer = 
    {
    Firstname : string
    Lastname : string
    Age : int
    }

type Account =
    {
    UniqueID : string
    CurrentBalance : decimal
    Owner : Customer
    }

type OperationType = 
    | Withdraw = 0
    | Deposit = 1
    | Exit = 2