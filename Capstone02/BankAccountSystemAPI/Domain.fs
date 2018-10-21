namespace BankAccountSystemAPI

open System

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
    
type Transaction =
    {
    Amount : decimal
    Operation : OperationType
    Time : DateTime
    Attempt : bool
    }
