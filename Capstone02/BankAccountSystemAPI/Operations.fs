namespace BankAccountSystemAPI

module Operations =
    let deposit ammount account =
        {
        Owner = account.Owner
        UniqueID = account.UniqueID
        CurrentBalance = account.CurrentBalance + ammount
        }
