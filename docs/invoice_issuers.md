---
layout: default
---

## Invoice issuers

### Get an invoice issuer

Invoice issuer represents merchant's company information. Before using *MobilePay Invoices* merchant must have at least one invoice issuer which can be created via [MobilePay Portal Denmark](https://admin.mobilepay.dk) or [Finland](https://admin.mobilepay.fi). Each invoice issuer contains its own address information, account data and logo.

```
GET /api/v1/merchants/{merchantId}/invoiceissuer
```

Response

```
HTTP 200 OK
```
```json
{
  "InvoiceIssuers": [
    {
      "Id": "6a33d969-fa86-44af-a23b-731da0e4d50d",
      "Name": "MyAwesomeStore",
      "AccountType": "Account"
    }
  ]
}
```

| Property | Type | Description |
|----------|------|-------------|
|`Id`| `guid` | Id of an invoice issuer associated with your `merchantId`.|
|`Name`| `string` | Your invoice issuer's name.|
|`AccountType`| `string` | The type of account associated with an invoice issuer. At the moment there's only one type `Account`.|

### Get your merchant id

`MerchantId` is a unique identifier of a merchant in our system. After you retrieve an access token from OpenID flow use the following endpoint to retrieve your `MerchantId`.

```
GET /api/v1/merchants/me
```
Response

```
HTTP 200 OK
```
```json
{
  "MerchantId": "e3465d75-8fd4-4ea4-8881-304c464f1d24"
}
```