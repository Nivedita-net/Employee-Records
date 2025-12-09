# Employee-Records

A Web API project for managing employee data.  
The API stores employee data in a JSON file.

---

## Endpoints

### Add new employees

**POST** `/api/employees`

**Body Example:**

```json
{
  "firstName": "FirstName",
  "lastName": "LastName",
  "email": "mail@example.com",
  "department": "IT",
  "phoneNumber": "123456789"
}
```

### Fetch All Employees

**GET** `/api/employees`

Returns the list of all employees.
