# animal-friends-tech-test

### Solution Contents

- Database project
- Api project
- Test projects

**How to run the solution**

publish the database, modify the connection string in the appsettings.json file to point to the database on the sql instance

Using postman or similar psot the following object, at least one out of email or dob is required to be submitted.

```json
{
        "firstName": "John",
        "surname": "Doey",
        "policyReferenceNumber": "DD-123456",
        "dateOfBirth": "1981-01-01",
        "email": "some@email@.com 
}
```
