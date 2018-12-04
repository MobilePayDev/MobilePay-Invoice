---
layout: default
---

## Callbacks

##### How merchants and integrators should handle invoice callbacks 
Invoice callbacks are sent using batches. The job starts every 30 seconds. In the event that the callbacks are received in incorrect order, please check the date property. There is a Date property in the callbacks, so you can compare the callbacks and execute, only if it is newer than last received.  

##### Set callback URL 

In order to receive callbacks about status changes for an invoice a callback URL must be specified first. But before setting your callback URL you must choose prefered authentication method which we will use for authenticating our requests when calling your callback URL. Currently we support <code><a href="https://tools.ietf.org/html/rfc7617">Basic</a></code> and `ApiKey` authentication methods:  

##### Basic
```
PUT /api/v1/merchants/{merchantId}/auth/basic
```

```json 
{
  "username": "Username",
  "password": "MySecretPswd",
  "callback_url": "https://your.url/callbacks/invoice"
}
```

##### ApiKey
```
PUT /api/v1/merchants/{merchantId}/auth/apikey
```
```json
{
  "api_key": "SomeSecretApiKey123",
  "callback_url": "https://your.url/callbacks/invoice"
}
```
Using `ApiKey` authentication method your provided API key will be simply added to `Authorization` header.

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

 All possible invoice statuses returned in callback body can be found in <a href="api_reference#get-status">Get invoice status</a> section.

<div class="note">
<strong>Note:</strong> When status of an invoice is <code>invalid</code> two additional fields will be added: <code>ErrorCode</code> and <code>ErrorMessage</code>. All possible validation errors can be found in <a href="api_reference#validations">validations</a> section.
</div>

Callbacks about created `InvoiceLinks` which were created asynchronously using [batch endpoint](api_reference#create_multiple_invoice_links) will contain additional field `Links` with `Rel="user-redirect"` and `Href` to the page where MobilePay users can accept an invoice, e.g.:
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
