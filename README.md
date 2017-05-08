# MobilePay Invoice

### Overview

Billing your customers with MobilePay Invoice is easy using our MobilePay Invoice Api's. </br>
This document explains how to make a technical integration to the MobilePay Invoice product. The audience for this document is either technical integrators acting on behalf of merchants, or merchant creating their own integrations.

### Table of Contents
[Invoice API](#headers) 
<a name="headers"/>
## Invoice API

When the **Consent** between **Merchant** and the **Integrator** is established, use the `POST /api/merchants/me/paymentrequest` endpoint to en-queue **Invoice Requests**. This service accepts a JSON array of individual **Invoice Requests** to be processed asynchronously.

#### Request parameters

|Parameter             |Sub Parameter |Type        |Required  |Description                                       |Valid values|
|----------------------|--------------|------------|----------|--------------------------------------------------|------------|
|**InvoiceIssuer**  |              |guid        | required |*The ID of the invoicing department/branch of the merchant*||
|**ConsumerAlias**     |              |            | required |*Mobile alias of the MobilePay user to be invoiced*||
|    | **Alias**  |string      | required |*Alias value of the MobilePay user*||
|    | **AliasType**  |string      | required |*Alias type of the MobilePay user, allowed values are: Phone number*|Phone|
|**ConsumerName**      |              |string      | required |*Full name of the MobilePay user*||
|**TotalAmount**       |              |number(0.00)| required |*The requested amount to be paid.*|>= 0.00, decimals separated with a dot.|
|**TotalVatAmount**    |              |number(0.00)| required |*VAT amount*|>= 0.00, decimals separated with a dot.|
|**CountryCode**       |              |string(2)   | required |*Country code*| eg. DK |
|**CurrencyCode**      |              |string(3)   | required |*Currency code*| eg. DKK |
|**ConsumerAddressLines**|            |string      | required |*Address of consumer receiving the invoice*||
|**DeliveryAddressLines**|            |string      | required |*Delivery address*||
|**InvoiceNumber**     |              |string      | required |*Invoice Number*||
|**IssueDate**         |              |date        | required |*Issue date of invoice*|ISO date format: yyyy-MM-dd|
|**DueDate**           |              |date        | required |*Payment due date. Must be between today and +400 days ahead, otherwise the Request will be declined.*|ISO date format: yyyy-MM-dd|
|**OrderDate**         |              |date        | required |*Order date of invoice*|ISO date format: yyyy-MM-dd|
|**Comment**           |              |string      |          |*Free text of additional information to the consumer*||
|**MerchantContactName**|             |string      |          |*Contact name for the individual who issued the invoice*||
|**MerchantOrderNumber**|             |string      |          |*The ordernumber for the invoice used internally by the merchant*||
|**BuyerOrderNumber**|              |string      |          |*The ordernumber for the invoice used externally by the merchant*||
|**PaymentReference**  |              |string(60)  | required |*Reference used on the payment to do reconsilitaion*||
|**InvoiceLineItem[]** |              |            | required |*At least one invoice line is required*||
|    |**ArticleNumber**               |string      | required |*Article Number*||
|    |**ArticleDescription**          |string      | required |*Article Descrition*||
|    |**VATRate**                     |number(0.00)| required |*VAT Rate of article*|>= 0.00, decimals separated with a dot.|
|    |**TotalVATAmount**              |number(0.00)| required |*Total VAT amount of article*|>= 0.00, decimals separated with a dot.|
|    |**TotalPriceIncludingVat**      |number(0.00)| required |*Total price of article including VAT*|>= 0.00, decimals separated with a dot.|
|    |**Unit**                        |string      | required |*Unit*||
|    |**Quantity**                    |number(0.00)| required |*Quantity of article*|>= 0.00, decimals separated with a dot.|
|    |**PricePerUnit**                |number(0.00)|          |*Price per unit*|>= 0.00, decimals separated with a dot.|
|    |**PriceReduction**              |number(0.00)|          |*Price reduction*|>= 0.00, decimals separated with a dot.|
|    |**PriceDiscount**               |number(0.00)|          |*Price discount*|>= 0.00, decimals separated with a dot.|
|    |**Bonus**                       |number(0.00)|          |*Quantity of article*|>= 0.00, decimals separated with a dot.|


##### HTTP 202 Response body example
```
```

#### Invoice screens

    
