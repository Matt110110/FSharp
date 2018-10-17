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
