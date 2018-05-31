---
layout: default
---

## Invoice

### <a name="direct"/> InvoiceDirect

#### Create invoice

```
POST api/v1/merchants/{merchantId}/invoices
```

Input

|Parameter             |Sub Parameter |Type        |Required  |Description                                       |Valid values|
|----------------------|--------------|------------|----------|--------------------------------------------------|------------|
|`InvoiceIssuer`  |              |guid        | required |*The ID of the invoicing department/branch of the merchant*|5e1210f9-4153-4fc3-83ec-2a8fc4843ea6|
|`ConsumerAlias`     |              |            | required |*Mobile alias of the MobilePay user to be invoiced*||
|    | `Alias`  |string      | required |*Alias value of the MobilePay user*|e.g. +4512345678 or +35812345678|
|    | `AliasType`  |string      | required |*Alias type of the MobilePay user*|Phone|
|`ConsumerName`      |              |string      | required |*Full name of the MobilePay user*|Free text, Contact Name|
|`TotalAmount`       |              |decimal     | required |*The requested amount to be paid.*|>= 0.00, decimals separated with a dot.|
|`TotalVatAmount`    |              |decimal     | required |*VAT amount*|>= 0.00, decimals separated with a dot.|
|`CountryCode`       |              |string(2)   | required |*Country code*| DK |
|`CurrencyCode`      |              |string(3)   | required |*Currency code*|DKK |
|`ConsumerAddressLines`|            |string      | required |*Address of consumer receiving the invoice*|Free text|
|`DeliveryAddressLines`|            |string      |          |*Delivery address*|Free text|
|`InvoiceNumber`     |              |string      | required |*Invoice Number*|Free text e.g. 123456798ABCD|
|`IssueDate`         |              |date        | required |*Issue date of invoice*|ISO date format: YYYY-MM-DD|
|`DueDate`           |              |date        | required |*Payment due date. Must be between today and +400 days ahead, otherwise the Request will be declined.*|ISO date format: YYYY-MM-DD|
|`OrderDate`         |              |date        | required |*Order date of invoice*|ISO date format: YYYY-MM-DD|
|`DeliveryDate`      |              |date        | required |*Delivery date of invoice*|ISO date format: YYYY-MM-DD|
|`Comment`           |              |string      |          |*Free text of additional information to the consumer*|Free text|
|`MerchantContactName`|             |string      |          |*Contact name for the individual who issued the invoice*|Free text, Name|
|`MerchantOrderNumber`|             |string      |          |*The merchant order number for the invoice used internally by the merchant*|Free text e.g. 123456798ABCD|
|`BuyerOrderNumber`|              |string      |          |*The buyer order number for the invoice used externally by the merchant*|Free text e.g. 123456798ABCD|
|`PaymentReference`  |              |string(60)  |          |*Reference used on the payment to do reconciliation. If not filled, invoice number will be used as reference*|Free text e.g. 123456798ABCD|
|`InvoiceArticles` |              |  list          | required |*At least one invoice article is required*||
|    |`ArticleNumber`               |string      |          |*Article Number*|e.g. 123456ABC|
|    |`ArticleDescription`          |string      |          |*Article Description*|Free text|
|    |`VATRate`                     |decimal     |          |*VAT Rate of article*|>= 0.00, decimals separated with a dot.|
|    |`TotalVATAmount`              |decimal     |          |*Total VAT amount of article*|>= 0.00, decimals separated with a dot.|
|    |`TotalPriceIncludingVat`      |decimal     |          |*Total price of article including VAT*|>= 0.00, decimals separated with a dot.|
|    |`Unit`                        |string      |          |*Unit*|e.g. Pcs, Coli|
|    |`Quantity`                    |decimal     |          |*Quantity of article*|>= 0.00, decimals separated with a dot.|
|    |`PricePerUnit`                |decimal     |          |*Price per unit*|>= 0.00, decimals separated with a dot.|
|    |`PriceReduction`              |decimal     |          |*Price reduction*|>= 0.00, decimals separated with a dot.|
|    |`PriceDiscount`               |decimal     |          |*Price discount*|>= 0.00, decimals separated with a dot.|
|    |`Bonus`                       |decimal     |          |*Bonus of article*|>= 0.00, decimals separated with a dot.|

Example

```json
{
  "InvoiceIssuer": "efd08c19-24cf-4833-a4a4-bfa7bd58fbb2",
  "ConsumerAlias": {
    "Alias": "+4577007700",
    "AliasType": "Phone"
  },
  "ConsumerName": "Consumer Name",
  "TotalAmount": 360,
  "TotalVATAmount": 72,
  "CountryCode": "DK",
  "CurrencyCode": "DKK",
  "ConsumerAddressLines": [
    "Paradisæblevej 13",
    "CC-1234 Andeby", 
    "WONDERLAND"
  ],
  "DeliveryAddressLines": [
    "Østerbrogade 120",
    "CC-1234 Andeby",
    "WONDERLAND"
  ],
  "InvoiceNumber": "301",
  "IssueDate": "2018-02-12",
  "DueDate": "2018-03-12",
  "OrderDate": "2018-02-05",
  "DeliveryDate": "2018-02-10",
  "Comment": "Any comment",
  "MerchantContactName": "Snowboard gear shop",
  "MerchantOrderNumber": "938",
  "BuyerOrderNumber": "631",
  "PaymentReference": "186",
  "InvoiceArticles": [
    {
      "ArticleNumber": "1-123",

"ArticleDescription": "Process Flying V Snowboard",
      "VATRate": 25,
      "TotalVATAmount": 72,
      "TotalPriceIncludingVat": 360,
      "Unit": "1",
      "Quantity": 1,
      "PricePerUnit": 288,
      "PriceReduction": 0,
      "PriceDiscount": 0,

"Bonus": 5
    }      
  ]
}
```

Response

```
HTTP 202 Accepted
```
```json
{
    "InvoiceId" : "63679ab7-cc49-4f75-80a7-86217fc105ea"
}
```

If not accepted, invoice will expire 30 days after due date.

#### Create multiple invoices
```
POST api/v1/merchants/{merchantId}/invoices/batch
```
Input (an array of objects used to create single invoice)
```json
[
  {
     // InvoiceDirect input
  },
  {
     // InvoiceDirect input
  },
  ...
]
```
Response
```
HTTP 202 Accepted
```
```json
{
  "Accepted": [
    {
      "InvoiceNumber": "<original invoice number sent by the merchant>",
      "InvoiceId": "66119129-aaf7-4ad0-a5b1-62382932b5c6"
    },
    {
      "InvoiceNumber": "<original invoice number sent by the merchant>",
      "InvoiceId": "5e3030a3-61ff-4143-a6bd-8457a09bcb0d"
    },
    ...
  ],
  "Rejected": [
    {
      "InvoiceNumber": "<original invoice number sent by the merchant>",
      "ErrorText": "<description of error>",
      "ErrorCode": 10504
    },
    ...
  ]
}
```

### <a name="link"/> InvoiceLink

#### Create invoice link

Merchant can create a link to invoice that is sent to customer, allowing them to pay using MobilePay.
Notice that request does not require a customer alias. It's because InvoiceLink can be paid by any MobilePay user.

```
POST api/v1/merchants/{merchantId}/invoices
```

Input

|Parameter              |Sub Parameter             |Type      |Required      |Description                                                 |Valid values|
|:----------------------|:------------------------ |:---------|:-------------|:-----------------------------------------------------------|:-----------|
|`InvoiceIssuer`        |                          | guid     | required     |*The ID of the invoicing department/branch of the merchant*|5e1210f9-4153-4fc3-83ec-2a8fc4843ea6|
|`ConsumerAlias`        |                          | object   |              |*Mobile alias of the MobilePay user to be invoiced*| |
|                       | `Alias`                  | string   | required     |*Alias value of the MobilePay user*| e.g. 004512345678, 12345678, +4512345678|
|                       | `AliasType`              | string   | required     |*Alias type of the MobilePay user*| Phone |
|`ConsumerName`         |                          | string   |              |*Full name of the MobilePay user*| Free text e.g. Contact Name|
|`TotalAmount`          |                          | decimal  | required     |*The requested amount to be paid.*|>= 0.00, decimals separated with a dot.|
|`TotalVATAmount`       |                          | decimal  | required     |*VAT amount*| >= 0.00, decimals separated with a dot. |
|`CountryCode`          |                          | string   | required     |*Country code*| DK, FI |
|`CurrencyCode`         |                          | string   | required     |*Currency code*| DKK, EUR |
|`ConsumerAddressLines` |                          | string[] | At least one |*Address of consumer receiving the invoice*| Free text |
|`DeliveryAddressLines` |                          | string[] |              |*Delivery address*| Free text |
|`InvoiceNumber`        |                          | string   | required     |*Invoice Number*| Free text e.g. 123456798ABCD |
|`IssueDate`            |                          | Date     | required     |*Issue date of invoice*| ISO date format: YYYY-MM-DD |
|`DueDate`              |                          | Date     | required     |*Invoice payment due date. Must be between today and +400 days ahead, otherwise the Request will be declined*| ISO date format: YYYY-MM-DD |
|`OrderDate`            |                          | Date     | required     |*Order date of invoice* | ISO date format: YYYY-MM-DD |
|`DeliveryDate`         |                          | Date     |              |*Delivery date of invoice* | ISO date format: YYYY-MM-DD |
|`Comment`              |                          | string   |              |*Free text of additional information to the consumer*| Free text |
|`MerchantContactName`  |                          | string   |              |*The merchant Contact name for the individual who issued the invoice*| Free text, Name |
|`MerchantOrderNumber`  |                          | string   |              |*The merchant order number for the invoice used internally by the merchant*| Free text e.g. 123456798ABCD |
|`BuyerOrderNumber`     |                          | string   |              |*The buyer order number for the invoice used externally by the merchant*| Free text e.g. 123456798ABCD |
|`PaymentReference`     |                          | string   |              |*Reference used on the payment to do reconciliation. If not filled, invoice number will be used as reference*| Free text e.g. 123456798ABCD |
|`InvoiceArticles`      |                          | list     | required     |*At least one invoice article is required*|  |
|                       |  `ArticleNumber`         | string   |              |*Article Number*| e.g. 123456ABC |
|                       | `ArticleDescription`     | string   |              |*Article description*| Free text |
|                       | `VATRate`                | decimal  |              |*VAT Rate of article*| >= 0.00, decimals separated with a dot. |
|                       | `TotalVATAmount`         | decimal  |              |*Total VAT amount of article*| >= 0.00, decimals separated with a dot. |
|                       | `TotalPriceIncludingVat` | decimal  |              |*Total price of article including VAT*| >= 0.00, decimals separated with a dot. |
|                       | `Unit`                   | string   |              |*Unit*| e.g. Pcs, Coli |
|                       | `Quantity`               | decimal  |              |*Quantity of article*| >= 0.00, decimals separated with a dot. |
|                       | `PricePerUnit`           | decimal  |              |*Price per unit*| >= 0.00, decimals separated with a dot. |
|                       | `PriceReduction`         | decimal  |              |*Price reduction*| >= 0.00, decimals separated with a dot. |
|                       | `PriceDiscount`          | decimal  |              |*Price discount*| >= 0.00, decimals separated with a dot. |
|                       |  `Bonus`                 | decimal  |              |*Bonus of article*| >= 0.00, decimals separated with a dot. |

Example

```json
{
  "InvoiceIssuer": "efd08c19-24cf-4833-a4a4-bfa7bd58fbb2",
  "ConsumerAlias": {
    "Alias": "+4577007700",
    "AliasType": "Phone"
  },
  "ConsumerName": "Consumer Name",
  "TotalAmount": 360,
  "TotalVATAmount": 72,
  "CountryCode": "DK",
  "CurrencyCode": "DKK",
  "ConsumerAddressLines": [
    "Paradisæblevej 13",
    "CC-1234 Andeby", 
    "WONDERLAND"
  ],
  "DeliveryAddressLines": [
    "Østerbrogade 120",
    "CC-1234 Andeby",
    "WONDERLAND"
  ],
  "InvoiceNumber": "301",
  "IssueDate": "2018-02-12",
  "DueDate": "2018-03-12",
  "OrderDate": "2018-02-05",
  "DeliveryDate": "2018-02-10",
  "Comment": "Any comment",
  "MerchantContactName": "Snowboard gear shop",
  "MerchantOrderNumber": "938",
  "BuyerOrderNumber": "631",
  "PaymentReference": "186",
  "InvoiceArticles": [
    {
      "ArticleNumber": "1-123",
      "ArticleDescription": "Process Flying V Snowboard",
      "VATRate": 25,
      "TotalVATAmount": 72,
      "TotalPriceIncludingVat": 360,
      "Unit": "1",
      "Quantity": 1,
      "PricePerUnit": 288,
      "PriceReduction": 0,
      "PriceDiscount": 0,
      "Bonus": 5
    }      
  ]
}
```

Response
```
HTTP 202 Accepted
```
```json
{
    "InvoiceId": "c5d4fde3-81e2-49de-8cfe-8c96f449e367",
    "Links": [
        {
            "Rel": "user-redirect",
            "Href":"https://api.sandbox.mobilepay.dk/invoice-restapi/api/v1/consumers/me/invoices/invoices/c5d4fde3-81e2-49de-8cfe-8c96f449e367/link"
        }
    ]
}
```

#### Create multiple invoice links

```
POST api/v1/merchants/{merchantId}/invoices/link/batch
```

Input (an array of objects used to create single invoice link)
```json
[
  {
    InvoiceLink input,
  },
  {
    InvoiceLink input,
  },
  ...
]
```

Response
```
HTTP 202 Accepted
```
```json
{
  "Accepted": [
    {
      "InvoiceNumber": "<original invoice number sent by the merchant>",
      "InvoiceId": "66119129-aaf7-4ad0-a5b1-62382932b5c6"
    },
    {
      "InvoiceNumber": "<original invoice number sent by the merchant>",
      "InvoiceId": "5e3030a3-61ff-4143-a6bd-8457a09bcb0d"
    },
    ...
  ],
  "Rejected": [
    {
      "InvoiceNumber": "<original invoice number sent by the merchant>",
      "ErrorText": "<description of error>",
      "ErrorCode": 10504
    },
    ...
  ]
}
```

The success response for InvoiceDirect is not much different from the regular, non-batch response, but you will notice, that InvoiceLink responses don't contain the link itself. This is because we are processing batches asynchronously and can't return an immediate result. The link URLs will be sent back to you via a callback, as soon as they're created.

### <a name="get-status"/> Get invoice status

```
GET api/v1/merchants/{merchantId}/invoices/{invoiceId}/status
```
Response

```
HTTP 200 OK
```
```json
{
    "InvoiceId" : "5e1210f9-4153-4fc3-83ec-2a8fc4843ea6",
    "Status" : "Created"
}
```

The table below shows all possible statuses.

|Status     | Explanation                                                 | Type         |
|-----------|-------------------------------------------------------------|--------------|
|Created    |_Merchant created the Invoice_                               | Intermediate |
|Invalid    |_Invoice validation failed_                                  | Intermediate |
|Accepted   |_User swiped to accept the Invoice_                          | Intermediate |
|Paid       |_Invoice was paid_                                           | Final        |
|Rejected   |_User tapped the reject button during the signup_            | Final        |
|Expired    |_User did not do anything during the invoice timeout period._| Final        |
|Credited   |_You credited this invoice._                                 | Final        |

Invoice status flow can be visualized by the following diagram.

[![](assets/images/invoice_flow.png)](assets/images/invoice_flow.png)

### <a name="crediting"/> Crediting an invoice

You can credit an invoice which has not yet been paid, rejected and has not expired.
```
PUT api/v1/merchants/{merchantId}/invoices/{invoiceId}/credit
```

Response
```
HTTP 204 No Content
```

### <a name="error-codes"/> Error Codes

Possible error responses contain these five properties:

* **correlation_id** - a unique id used for logging and debugging purposes.
* **error** - a string specifying error type. Possible values: `DomainError`, `InputError` & `ServerError`
* **error_code** - integer specifying error unique code.
* **error_description** - a string indetifying human friendlly error description.
* **error_context** - a string indetifying context in which error has occured.


1. `HTTP 400` , if request input is invalid
>
  ```json
  {
      "correlation_id": "54ccc98b-7d9f-40ea-8c1a-249d57126c39",
      "error": "InputError",
      "error_code": null,
      "error_description": "input.TotalAmount : Invalid input\r\n",
      "error_context": "Invoices"
  }
  ```

2. `HTTP 409` , request is not compatible with a current state
>
  ```json
  {
      "correlation_id": "8c153279-98f1-4e33-b053-3c6e3555adff",
      "error": "DomainError",
      "error_code": "10504",
      "error_description": "Invoice has already been paid",
      "error_context": "Invoices"
  }
  ```

3. `HTTP 500` , server error
>
  ```json
  {
      "correlation_id": "56db684c-7845-4abf-9f19-5632a625a47b",
      "error": "ServerError",
      "error_code": null,
      "error_description": "The given key was not present in the dictionary.",
      "error_context": "Invoices"
  }
  ```

While creating **InvoiceDirect** or an **InvoiceLink** these **Error Codes** are possible

|   |Error Code | Description                                                                   |
|:--|:----------|:------------------------------------------------------------------------------|
|   |10001      |*Invoice Issuer required*                                                      |
|   |10002      |*Consumer Alias required*                                                      |
|   |10003      |*Invalid currency code*                                                        |
|   |10004      |*Invalid country code*                                                         |
|   |10005      |*AliasType is required. Allowed values are "Phone"*                            |
|   |10006      |*Invalid phone number*                                                         |
|   |10007      |*Consumer name is required*                                                    |
|   |10008      |*Total invoice amount required*                                                |
|   |10009      |*Total VAT amount required*                                                    |
|   |10010      |*Country code required*                                                        |
|   |10011      |*Currency code required*                                                       |
|   |10012      |*Consumer address lines required*                                              |
|   |10013      |*Unique invoice number required*                                               |
|   |10014      |*Issue Date require*                                                           |
|   |10015      |*Due Date required*                                                            |
|   |10016      |*Order Date required*                                                          |
|   |10017      |*At least one element is required*                                             |
|   |10101      |*MobilePay User not found*                                                     |
|   |10102      |*MobilePay user not available*                                                 |
|   |10103      |*MobilePay User not found*                                                     |
|   |10104      |*Invoice already exists*                                                       |
|   |10105      |*Technical error - please contact MobilePay*                                   |
|   |10201      |*Technical error - please contact MobilePay*                                   |
|   |10202      |*Invoice Issuer not found*                                                     |
|   |10203      |*Account validation error*                                                     |
|   |10204      |*Account validation error*                                                     |
|   |10205      |*Technical error - please contact MobilePay*                                   |
|   |10301      |*Invoice already exists*                                                       |
|   |10302      |*Merchant not found*                                                           |
|   |10303      |*Invoice Issuer not found*                                                     |
|   |10304      |*MobilePay User not found*                                                     |
|   |10305      |*MobilePay User not found*                                                     |
|   |10306      |*MobilePay User not found*                                                     |
|   |10310      |*DueDate must be no later than 400 days from today*                            |
|   |10311      |*DueDate must be today or later*                                               |
|   |10312      |*IssueDate must be no later than today*                                        |
|   |10313      |*Your daily limit has been reached*                                            |
|   |10314      |*Technical error - please contact MobilePay*                                   |

### <a name="validations"/> Validations

A set of business rules apply for an **Invoice** before it gets created. If any of following rules fail, an **Invoice** falls to `Not Created` state and an error response with Error Code and Description is returned

|Field            |Country          |Validation                                         |Error Code |Description                                                         |
|-----------------|-----------------|---------------------------------------------------|-----------|--------------------------------------------------------------------|
|**DueDate**      |DK/FI            |*CreatedDate < DueDate < CreatedDate + 400(days)*  |10310/10311|Due Date must be no more than 400 days in the future                |
|**IssueDate**    |DK/FI            |*IssueDate >= CreatedDate*                         |10312      |Issue Date can not be later than Invoice Creation date              | 
|**CountryCode**  |DK/FI            |*CountryCode == Consumer CountryCode*              |10106      |Country Code must match Consumer Country Code                       | 
|**CurrencyCode** |DK               |*CurrencyCode == DKK*                              |10107      |Only DKK is supported for DK Invoices                               |
|                 |FI               |*CurrencyCode == EUR*                              |10107      |Only EUR is supported for FI invoices                               |
|**TotalAmount**  |DK               |*TotalAmount <= 10000 DKK*                         |10201      |Total Amount is limited to 10000 DKK                                |
|                 |FI               |*TotalAmount <= 500 EUR*                           |10201      |Total Amount is limited to 500 EUR                                  |
|*Limits*         |DK/FI            |*Consumer Daily Invoice Count <= 3*                |10313      |No more then 3 Invoices can be created per Consumer from single Merchant|
|*Limits*         |DK/FI            |*Invoice Issuer Daily Invoice Count <= 5000*       |10314      |No more then 5000 Invoices can be created per Invoice Issuer per day|