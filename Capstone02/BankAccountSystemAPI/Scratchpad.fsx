#load "Domain.fs"
#load "Operations.fs"
open BankAccountSystemAPI
open Operations

let customer1 = { Firstname = "Roger"; Lastname = "Kavery"; Age = 43 }
let acc1 = 
    {
    UniqueID = "511785250201000"
    Owner = customer1
    CurrentBalance = 8990.34M
    }

let depositTen = deposit 10M
let acc2 = depositTen acc2