namespace BankAccountSystemAPI

open System
open System.IO
open Operations
open Transactions

module Audit =

    let private getAttemt accN accO =
        if (accN.CurrentBalance = accO.CurrentBalance) then false
        else true
    // Function to generate a string in the format
    let getStr account message = 
        let str = sprintf "\nName : %s\nAccount no. : %s\nBalance : %f\nMessage : %s\n" (account.Owner.Firstname + " " + account.Owner.Lastname ) account.UniqueID account.CurrentBalance message
        str

    // Function to generate the path where the file is to be stored
    // Path format = *parent folder*\{customername}\{accountid}.txt 
    let getPath account = 
        let path = sprintf "E:\\VCS\\FSharp\\BankAccountSystemAPI\\%s\\%s_%s.txt" (account.Owner.Firstname + "_" + account.Owner.Lastname) (account.Owner.Firstname + "_" + account.Owner.Lastname) account.UniqueID
        path

    // Function to write the output to a file. For now .txt file but in real life application you have to use some other more secure formats.
    let fileSystemAudit account message = File.WriteAllText(getPath account, getStr account message)
    
    // Function to write the output to the console. 
    let consoleAudit account message = Console.WriteLine(getStr account message)

    // Function to write the output to a file. For now .txt file but in real life application you have to use some other more secure formats.
    let fileSystemAuditTr account transaction = File.WriteAllText(getPath account, serialize transaction)
    
    // Function to write the output to the console. 
    let consoleAuditTr _account transaction = Console.WriteLine(serialize transaction)

    (*
        opType : Enum OperationType; shows deposit or withdraw
        audit : The audit function needed, either console audit or file system audit
        operation : The operation that's needed. Either deposit or withdraw function
        amt : The ammount to use on the operation
        account : The Account to act upon

        It is possible to just perform the operation and return it in a single line, but in that case the print statement will be wrong, as it will show the previous account details.
    *)
    let auditAs opType operation audit amt account =
        let newAccount = operation amt account
        match opType with 
            | OperationType.Withdraw -> audit newAccount "Withdraw" 
            | OperationType.Deposit -> audit newAccount "Deposit"
            | _ -> failwith "Unknown operation performed."
        newAccount

    let auditAsTr opType operation audit amt account =
        let newAccount = operation amt account
        let transaction = 
            {
            Amount = amt
            Operation = opType
            Attempt = getAttemt newAccount account
            Time = DateTime.UtcNow
            }
        match opType with 
            | OperationType.Withdraw -> audit newAccount transaction 
            | OperationType.Deposit -> audit newAccount transaction
            | _ -> failwith "Unknown operation performed."
        newAccount

    // Predefined partially curried functions for simplicity
    let depositWithConsoleAudit = auditAs OperationType.Deposit deposit consoleAudit
    let withdrawWithConsoleAudit = auditAs OperationType.Withdraw withdraw consoleAudit
    let depositWithFileAudit = auditAs OperationType.Deposit deposit fileSystemAudit
    let withdrawWithFileAudit = auditAs OperationType.Withdraw withdraw fileSystemAudit

    let depositWithConsoleAuditTr = auditAsTr OperationType.Deposit deposit consoleAuditTr
    let withdrawWithConsoleAuditTr = auditAsTr OperationType.Withdraw withdraw consoleAuditTr
    let depositWithFileAuditTr = auditAsTr OperationType.Deposit deposit fileSystemAuditTr
    let withdrawWithFileAuditTr = auditAsTr OperationType.Withdraw withdraw fileSystemAuditTr