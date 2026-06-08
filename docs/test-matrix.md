# Test Matrix

| Use Case                           | Test Type   | Covered |
| ---------------------------------- | ----------- | ------- |
| Create Account                     | Unit        | ✅      |
| Create Account with invalid number | Unit        | ✅      |
| Deposit money                      | Unit        | ✅      |
| Deposit negative amount            | Unit        | ✅      |
| Deposit zero amount                | Unit        | ✅      |
| Withdraw money                     | Unit        | ✅      |
| Withdraw more than balance         | Unit        | ✅      |
| Withdraw negative amount           | Unit        | ✅      |
| Transfer money                     | Unit        | ✅      |
| Transfer to same account           | Unit        | ✅      |
| Transfer with insufficient funds   | Unit        | ✅      |
| Get total balance                  | Unit        | ✅      |
| Get richest account                | Unit        | ✅      |
| Save accounts to JSON              | Integration | ✅      |
| Load accounts from JSON            | Integration | ✅      |
| Save and reload state              | Integration | ✅      |
| Load missing file                  | Integration | ✅      |
| Load corrupted JSON                | Integration | ✅      |
| Continue operations after reload   | Integration | ✅      |
| Multiple sequential operations     | Integration | ✅      |

---

## Coverage Areas

### Domain Layer

- Account creation
- Balance validation
- Deposit
- Withdraw
- Transactions

### Application Layer

- AccountService
- QueryService
- AccountFactory
- AccountPersistenceService

### Infrastructure Layer

- InMemoryBankAccountRepository
- JsonAccountDataStore

### Error Handling

- Invalid amounts
- Missing accounts
- Insufficient funds
- Missing file
- Corrupted JSON
