open System
#load "Domain.fs"
#load "Auditing.fs"

open BankAccountSystemAPI
open Audit

let acc:Account = 
    {
    UniqueID = "1"
    CurrentBalance = 19920M
    Owner = 
        {
        Firstname = "Fag"
        Lastname = "Got"
        Age = 21
        }
    }

consoleAudit acc "Ban"