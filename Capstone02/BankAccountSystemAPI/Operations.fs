﻿namespace BankAccountSystemAPI

module Operations =
    let deposit ammount account = { account with CurrentBalance = account.CurrentBalance + ammount }

    let withdraw ammount account =
        if account.CurrentBalance >= ammount then { account with CurrentBalance = account.CurrentBalance - ammount }
        else failwith "Account balance is low."
