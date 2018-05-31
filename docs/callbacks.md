---
layout: default
---

## Callbacks
In order to receive callbacks about status changes for an invoice a callback URL must be specified first. But before setting your callback URL you must choose prefered authentication method which we will use for authenticating our requests when calling your callback URL. Currently we support [`Basic`](https://tools.ietf.org/html/rfc7617) and `ApiKey` authentication methods:  

1) `PUT /api/v1/merchants/{merchantId}/auth/basic`
```json 
{
  "username": "Username",
  "password": "MySecretPswd",
  "callback_url": "https://your.url/callbacks/invoice"
}
```

2) `PUT /api/v1/merchants/{merchantId}/auth/apikey` 
```json
{
  "api_key": "SomeSecretApiKey123",
  "callback_url": "https://your.url/callbacks/invoice"
}
```
Using _ApiKey_ authentication method your provided ApiKey will be simply added to **_Authorization_** header.

Example of our callback body:

```json
[
  {
    "InvoiceId": "3c440dfb-b271-4d21-ad1c-f973f2c4f448",
    "Status": "Rejected",
    "Date":"2018-04-24T07:29:47.7500268+00:00"
  },
  {
    "InvoiceId": "3c440dfb-b271-4d21-ad1c-f973f2c4f449",
    "Status": "Invalid",
    "ErrorCode": 10106,
    "ErrorMessage": "<description of error>",
    "Date":"2018-04-24T07:29:47.7500268+00:00"
  },
  ...
]
```

---
**NOTE:** When status of an invoice is **invalid** two additional fields will be added: `ErrorCode` and `ErrorMessage`. All possible validation errors can be found in [Validation](#validation) section.

---

A callbacks about created **InvoiceLinks** which were created asynchronously using [batch endpoint](#batch-invoice-link) will contain additional field **_Links_** with **Rel="user-redirect"** and **Href** to the page where MobilePay users can accept an invoice, e.g.:
```json
[
  {
    "InvoiceId": "3c440dfb-b271-4d21-ad1c-f973f2c4f448",
    "Status": "Created",
    "Links": [
      {
        "Rel": "user-redirect",
        "Href": "<url-for-accepting-invoice>"
      }
    ],
    "Date":"2018-04-24T07:29:47.7500268+00:00"
  },
  ...
]
```