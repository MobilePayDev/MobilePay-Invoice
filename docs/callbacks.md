---
layout: default
---

## Callbacks

#### How merchants and integrators should handle invoice callbacks 
It’s asynchronous messaging and we cannot ensure the right order of the events. That’s why we added a property  `Date`  to each status change, so that the merchant’s would know when particular events have happened 

Invoice callbacks are sent using batches. The job starts every 30 seconds. In the event that the callbacks are received in incorrect order according to your timestamp, please check the property  `Date`. We added property  `Date`  so you can compare the callbacks to the status and the timestamp.

Make sure to not rely on whitelisting MobilePay’s sending IP addresses, as these IP addresses are subject to change without notice. 

##### REST callback retries

In case the REST callback failed, 8 retries will be made

* 1st retry after 5 seconds
* 2nd retry 19 minutes after 1st failed retry
* 3rd retry 39 minutes after 2nd failed retry
* 4th retry 1 hour and 19 minutes after 3rd failed retry
* 5th retry 2 hours and 39 minutes after 4th failed retry
* 6th retry 5 hours and 19 minutes after 5th failed retry
* 7th retry 10 hours and 39 minutes after 6th failed retry
* 8th retry 21 hours and 19 minutes after 7th failed retry

 
* * *

 
#### REST callback authentication


In order to receive callbacks about status changes for an invoice a callback URL must be specified first. But before setting your callback URL you must choose prefered authentication method which we will use for authenticating our requests when calling your callback URL. Currently we support <code><a href="https://tools.ietf.org/html/rfc7617">Basic</a></code> and `ApiKey` authentication methods:  

##### Basic

Using `basic` All the REST callbacks will be sent to `CallbackUrl` and contain basic credentials in `Authorization`  HTTP header: 

`Authorization: Basic [Base64 encoded username:password]`

```
PUT /api/v1/merchants/{merchantId}/auth/basic
```

```json 
{
  "username": "Username",
  "password": "MySecretPswd",
  "callbackurl": "https://your.url/callbacks/invoice"
}
```

##### ApiKey
```
PUT /api/v1/merchants/{merchantId}/auth/apikey
```
```json
{
  "api_key": "SomeSecretApiKey123",
  "callbackurl": "https://your.url/callbacks/invoice"
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
