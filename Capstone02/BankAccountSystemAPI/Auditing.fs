namespace BankAccountSystemAPI

open System
open System.IO

module Audit =
    
    // Function to generate a string in the format
    let getStr account message = 
        let str = sprintf "\nName : %s\nAccount no. : %s\nBalance : %f\nMessage : %s\n" (account.Owner.Firstname + " " + account.Owner.Lastname ) account.UniqueID account.CurrentBalance message
        str

    // Function to write the output to a file. For now .txt file but in real life application you have to use some other more secure formats.
    let fileSystemAudit account message =
        let path = "E:\\VCS\\FSharp\\Capstone02\\BankAccountSystemAPI\\audit.txt"
        File.WriteAllText(path, getStr account message)
    
    // Function to write the output to the console. 
    let consoleAudit (account:Account) (message:string) =
        Console.WriteLine(getStr account message)