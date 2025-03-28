# *The BulbProject Api*
## Overview
TheBulbProject Web API is a RESTful API designed to handle forms and field responses. It provides endpoints to create, retrieve, update, and delete forms and fields, as well as manage user authentication.

### Base url
```json
https://thebulbproject.onrender.com/
```
## Authentication Endpoints
### *Sign Up*
*Endpoint* : `Post` `https://thebulbproject.onrender.com/SiginUp`  
#### *Resquest Body*:
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": "1234567890",
  "role": "User",
  "email": "johndoe@example.com",
  "password": "password123",
  "confirmPassword": "password123"
}
```
*Response* :
```string
message : "User created successfully"
```
### *Login*
*Endpoint* : `Post` `https://thebulbproject.onrender.com/Login`  
#### *Resquest Body*:
```json
{
  "email": "johndoe@example.com",
  "password": "password123"
}
```
*Response* :
```string
message : "your-jwt-token"
```

## *Profile Enpoints*
### *Get profile by email*
*Endpoint* : `https://thebulbproject.onrender.com/{email}`
#### *Response Body*:
```json
{
  "id": 0,
  "userId": "string",
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "role": "string",
  "email": "string",
  "passwordHash": "string"
}
```
#### *Error Response*
- *Response Body*
```string
message : Profile does not exist
```

### *Update profile by email*
*Endpoint* : `https://thebulbproject.onrender.com/{email}`
```string
message : Profile updated successfully
```
### *Delete profile by email*
*Endpoint* : `https://thebulbproject.onrender.com/{email}`
```string
message : Profile updated successfully
```


## Forms Endpoints
### *Create Form*
*Endpoint* : `Post` `https://thebulbproject.onrender.com//form`
#### *Resquest Body*: 
```json
{
  "formType": "Survey",
  "formTitle": "Customer Satisfaction Survey"
}
```
#### *Response Body*:
```string
message : "Form created successfully"
```
### *Get Form By ID*
*Endpoint* : `https://thebulbproject.onrender.com/{id}` 
#### *Response Body*:
```json
{
  "formId": 1,
  "formType": "Survey",
  "formTitle": "Customer Satisfaction Survey"
}
```
#### *Error Response*
- *Response Body*
```string
message : Form id does not exist
```

### *Get Form By Title*
*Endpoint* : `https://thebulbproject.onrender.com/title/{id}` 
#### *Response Body*:
```json
{
  "formId": 1,
  "formType": "Survey",
  "formTitle": "Customer Satisfaction Survey"
}
```
#### *Error Response*
- *Response Body*
```string
message : Form title does not exist
```

### *Update Form*
*Endpoint* : `https://thebulbproject.onrender.com/form/{id}` 
#### *Resquest Body*:
```json
{
  "formId": 1,
  "formType": "Survey",
  "formTitle": "Customer Satisfaction Survey"
}
```
#### *Error Response*
- *Response Body*
```string
message : Form title does not exist
```

## Field Enpoints
### *Create Form*
*Endpoint* : `https://thebulbproject.onrender.com/api/field`
#### *Resquest Body*: 
```json
{
  "label": "string",
  "placeholder": "string",
  "options": [
    "string"
  ],
  "formID": 0
}
```

### *Get Field By ID*
*Endpoint* : `https://thebulbproject.onrender.com/field/{id}` 
#### *Response Body*:
```json
{
  "id": 0,
  "label": "string",
  "placeholder": "string",
  "options": [
    "string"
  ],
  "ratingValue": 0,
  "formID": 0
}
```
#### *Error Response*
- *Response Body*
```string
message : Field does not exist
```
### *Update Field*
*Endpoint* : `https://thebulbproject.onrender.com/field/{id}` 
#### *Resquest Body*:
```json
{
  "id": 0,
  "label": "string",
  "placeholder": "string",
  "options": [
    "string"
  ],
  "ratingValue": 0,
  "formID": 0
}
```
### *Delete Field*
*Endpoint* : `https://thebulbproject.onrender.com/field/{id}` 
```string
message : Field deleted successfully.
```
### *Get Field by FormId*
*Endpoint* : `https://thebulbproject.onrender.com/byformId/{id}` 
#### *Response Body*:
```json
[
  {
    "id": 0,
    "label": "string",
    "placeholder": "string",
    "options": [
      "string"
    ],
    "maxRating": 0,
    "formID": 0,
    "fieldResponses": [
      {
        "id": 0,
        "message": "string",
        "status": "string",
        "submisionID": "string",
        "ratingValue": 0,
        "fieldID": 0,
        "respondedAt": "string"
      }
    ]
  }
]
```


## Field-Response Enpoints
### *Create Form*
*Endpoint* : `https://thebulbproject.onrender.com/api/fieldresponse`
#### *Resquest Body*: 
```json
{
  "message": "string",
  "status": "string",
  "ratingValue": 0,
  "fieldID": 0
}
```
### *Get Field By ID*
*Endpoint* : `https://thebulbproject.onrender.com/api/fieldresponse/{fieldid}` 
#### *Response Body*:
```json
{
  "id": 0,
  "message": "string",
  "status": "string",
  "submisionID": "string",
  "ratingValue": 0,
  "fieldID": 0,
  "respondedAt": "string"
}
```

#### *Error Response*
- *Response Body*
```string
message : Field response does not exist
```
### *Get All field Response*
*Endpoint* : `https://thebulbproject.onrender.com/api/fieldresponse/all` 
#### *Response Body*:
```json
[
  {
    "id": 0,
    "message": "string",
    "status": "string",
    "submisionID": "string",
    "ratingValue": 0,
    "fieldID": 0,
    "respondedAt": "string"
  }
]
```

