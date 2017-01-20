# MobilePay Invoice

### Overview

Billing your customers with MobilePay Invoice is easy using our MobilePay Invoice Api's

### Table of Contents

### Invoice

When the **Agreement** between **Merchant** and MobilePay **User** is established, use the `POST /api/merchants/me/paymentrequest` endpoint to en-queue **Payment Requests**. This service accepts a JSON array of individual **Payment Requests** to be processed asynchronously. Notice that the **Payment Request** payload does not contain a currency code - this will be fetched from the **Agreement** using the provided *agreement_id*.

#### Request parameters

|Parameter             |Type        |Required  |Description                                                      |Valid values|
|----------------------|------------|----------|-----------------------------------------------------------------|------------|
|**MerchantId**        |guid        | required |*MobilePay agreement identifying the unique Merchant in MobilePay||
|**ConsumerAlias**     |string      | required |*Mobile no. of the MobilePay user to be invoiced *||
|**ConsumerName**      |string      | required |*Full name of the MobilePay user *||
|**TotalAmount**       |number(0.00)| required |*The requested amount to be paid.*|>= 0.00, decimals separated with a dot.|
|**TotalVatAmount**    |number(0.00)| required |*VAT amount*|>= 0.00, decimals separated with a dot.|
|**CountryCode**       |string(2)   | required |*Country code*| eg. DK |
|**CurrencyCode**      |string(3)   | required |*Currency code*| eg. DKK |
|**ConsumerAddressLines**       |string      | required |*Address of consumer receiving the invoice*||
|**DeliveryAddressLines**       |string      | required |*Delivery address*||
|**InvoiceNumber**     |string      | required |*Invoice Number*||
|**IssueDate**         |date        | required |*Issue date of invoice*|ISO date format: yyyy-MM-dd|
|**DueDate**           |date        | required |*Payment due date. Must be between today and +400 days ahead, otherwise the Request will be declined.*|ISO date format: yyyy-MM-dd|
|**OrderDate**         |date        | required |*Order date of invoice*|ISO date format: yyyy-MM-dd|
|**Note**              |string      |          |*Free text of additional information to the consumer*||
|**PaymentReference**  |string(60)  | required |*Reference used on the payment to do reconsilitaion*||


##### HTTP 202 Response body example
```
```

#### Invoice screens

