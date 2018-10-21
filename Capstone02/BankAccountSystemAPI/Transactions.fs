namespace BankAccountSystemAPI

open System

module Transactions =
    
    let private getOperation (part:string) =
        if part.Equals("Deposit") then OperationType.Deposit
        else OperationType.Withdraw

    let serialize transactions = sprintf "%O***%O***%M***%b" transactions.Time transactions.Operation transactions.Amount transactions.Attempt
    
    let deserialize (filecontents:string) =
        let parts = filecontents.Split([|"***"|], StringSplitOptions.None)
        {
        Time = parts.[0] |> DateTime.Parse
        Operation = getOperation parts.[1]
        Amount = parts.[2] |> decimal
        Attempt = Boolean.Parse parts.[3]
        }
