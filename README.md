# MobilePay Invoice

### Overview

Billing your customers with MobilePay Invoice is easy using our MobilePay Invoice Api's. </br>
This document explains how to make a technical integration to the MobilePay Invoice product. The audience for this document is either technical integrators acting on behalf of merchants, or merchant creating their own integrations.

### Table of Contents
* [Integration](#integration)     
    * [Merchant Onboarding](#merchantonboarding)     
    * [API Gateway](#apigateway)  
    * [OpenID Connect](#openidconnect)    
* [Invoice API](#invoiceapi)   

<a name="integration"/>  

## Integration     
Integrating to MobilePay invoice is technically a multistep process involving creating an application interacting with our systems via our API gateway, subscribing to the invoice product and calling the invoice RESTful API's.</br>
In the sections below, the following steps will be explained.
1. Merchant onboarding  
2. Subscribing to the Invoice product through the API gateway
3. Using OpenID Connect enabling integrators to call the invoice API on-behalf of merchants
4. How does the Invoice API look like and how is it called.

<a name="merchantonboarding"/>  

### Merchant Onboarding 
As a merchant wanting to send invoices via MobilePay, you enroll to the product via [MobilePay.dk](http://www.MobilePay.dk) or the MobilePay Business Administration portal. Here you will find information about our products as well as an easy way of enrolling. As an integrator or 3rd party service provider acting on behalf of a merchant, you need your customer to enroll to the product prior to doing the integration.</br>
During the first product enrollment, you, as a merchant, will be requested details about your company such as company size, type etc. You will also be asked to confirm the account(s) you wish to use. These informations are required in order for us to verify your company information to be able to transfer the money to you securely. </br>
During the enrollment you will also be given the option to define parameters such as name, logo, address, etc. for how your MobilePay Invoice Issuer should reflect your company in MobilePay.



<a name="apigateway"/>  

### API Gateway     
The first step needed in order to integrate to MobilePay invoice is obtaining access to the sandbox environment. The sandbox environment is a production like environment used in MobilePay to test technical integrations. The environment is located [here](https://sandbox-developer.mobilepay.dk/).</br>
Make sure that it is clear that the invoice product is wanted when requesting access. Once logged in, create an app representing your application. This will yield a client id and a secret -remember these as they are needed in every call. After this, navigate to the invoice product and subscribe with your newly created app. All facilities and information for testing connection will be available inside the sandbox environment when logged in.

<a name="openidconnect"/>  

### OpenID Connect   
When the merchant is onboarded, he has a user in MobilePay that is able to manage which products the merchant wishes to use. Not all merchants have the technical capabilities to make integrations to MobilePay, instead they may need to go through applications whith these capabilities. In order for this to work, the merchant must grant consent to an application with these capabilities. This consent is granted through mechanism in the [OpenID Connect](http://openid.net/connect/) protocol suite.</br>
The OpenID Connect protocol is a simple identity layer on top of the OAuth 2.0 protocol. Integrators are the same as clients in the OAuth 2.0 protocol. The first thing that must be done as a client is to go and register [here](). Once this is done the client must initiate the [hybrid flow](http://openid.net/specs/openid-connect-core-1_0.html#HybridFlowAuth) specified in OpenID connect. For invoices the client must request consent from the merchant using the 'invoice' scope. The authorization server in sandbox is located [here](https://api.sandbox.mobilepay.dk/merchant-authentication-openidconnect).</br>
If the merchant grants consent, an authorization code is returned which the client must exchange for an id token, an access token and a refresh token. The refresh token is used to refresh ended sessions without asking for merchant consent again. This means that if the client receives an answer from the api gateway saying that the access token is invalid, the refresh token is exchanged for a new access token and refresh token. </br> </br>
An example of how to use OpenID connect in C# can be found [here](https://github.com/DanskeBank/MobilePay-Invoice-Documentation/tree/master/ClientExamples).

<a name="invoiceapi"/>      

## Invoice API

When the **Consent** between **Merchant** and the **Integrator** is established, use the merchant api endpoint to en-queue **Invoice Requests**. The invoice API consists of the following endpoints: </br> 
1. Invoice POST request    
2. Invoice status GET request
3. InvoiceIssuers GET request (Not complete yet)

### Invoice POST request
This endpoint accepts a JSON array of individual **Invoice Requests** to be processed asynchronously.

#### Request parameters

|Parameter             |Sub Parameter |Type        |Required  |Description                                       |Valid values|
|----------------------|--------------|------------|----------|--------------------------------------------------|------------|
|**InvoiceIssuer**  |              |guid        | required |*The ID of the invoicing department/branch of the merchant*|5e1210f9-4153-4fc3-83ec-2a8fc4843ea6|
|**ConsumerAlias**     |              |            | required |*Mobile alias of the MobilePay user to be invoiced*||
|    | **Alias**  |string      | required |*Alias value of the MobilePay user*|e.g. 004512345678, 12345678, +4512345678|
|    | **AliasType**  |string      | required |*Alias type of the MobilePay user, allowed values are: Phone number*|Phone|
|**ConsumerName**      |              |string      | required |*Full name of the MobilePay user*|Free text, Contact Name|
|**TotalAmount**       |              |number(0.00)| required |*The requested amount to be paid.*|>= 0.00, decimals separated with a dot.|
|**TotalVatAmount**    |              |number(0.00)| required |*VAT amount*|>= 0.00, decimals separated with a dot.|
|**CountryCode**       |              |string(2)   | required |*Country code*| DK |
|**CurrencyCode**      |              |string(3)   | required |*Currency code*|DKK |
|**ConsumerAddressLines**|            |string      | required |*Address of consumer receiving the invoice*|Free text|
|**DeliveryAddressLines**|            |string      |          |*Delivery address*|Free text|
|**InvoiceNumber**     |              |string      | required |*Invoice Number*|Free text e.g. 123456798ABCD|
|**IssueDate**         |              |date        | required |*Issue date of invoice*|ISO date format: YYYY-MM-DD|
|**DueDate**           |              |date        | required |*Payment due date. Must be between today and +400 days ahead, otherwise the Request will be declined.*|ISO date format: YYYY-MM-DD|
|**OrderDate**         |              |date        | required |*Order date of invoice*|ISO date format: YYYY-MM-DD|
|**Comment**           |              |string      |          |*Free text of additional information to the consumer*|Free text|
|**MerchantContactName**|             |string      |          |*Contact name for the individual who issued the invoice*|Free text, Name|
|**MerchantOrderNumber**|             |string      |          |*The ordernumber for the invoice used internally by the merchant*|Free text e.g. 123456798ABCD|
|**BuyerOrderNumber**|              |string      |          |*The ordernumber for the invoice used externally by the merchant*|Free text e.g. 123456798ABCD|
|**PaymentReference**  |              |string(60)  |          |*Reference used on the payment to do reconsilitaion. If not filled, invoice number will be used as reference*|Free text e.g. 123456798ABCD|
|**InvoiceLineItem[]** |              |            | required |*At least one invoice line is required*||
|    |**ArticleNumber**               |string      |          |*Article Number*|e.g. 123456ABC|
|    |**ArticleDescription**          |string      |          |*Article Descrition*|Free text|
|    |**VATRate**                     |number(0.00)|          |*VAT Rate of article*|>= 0.00, decimals separated with a dot.|
|    |**TotalVATAmount**              |number(0.00)|          |*Total VAT amount of article*|>= 0.00, decimals separated with a dot.|
|    |**TotalPriceIncludingVat**      |number(0.00)|          |*Total price of article including VAT*|>= 0.00, decimals separated with a dot.|
|    |**Unit**                        |string      |          |*Unit*|e.g. Pcs, Coli|
|    |**Quantity**                    |number(0.00)|          |*Quantity of article*|>= 0.00, decimals separated with a dot.|
|    |**PricePerUnit**                |number(0.00)|          |*Price per unit*|>= 0.00, decimals separated with a dot.|
|    |**PriceReduction**              |number(0.00)|          |*Price reduction*|>= 0.00, decimals separated with a dot.|
|    |**PriceDiscount**               |number(0.00)|          |*Price discount*|>= 0.00, decimals separated with a dot.|
|    |**Bonus**                       |number(0.00)|          |*Quantity of article*|>= 0.00, decimals separated with a dot.|


##### HTTP 202 Response body example
InvoiceId: 5e1210f9-4153-4fc3-83ec-2a8fc4843ea6

### Invoice status GET request
This endpoint is used to request the status of individual invoices

#### Request parameters

There is no JSON input model in this endpoint, instead, format the request the in the following way: </br>
**{merchantid:guid}/invoices/{invoiceid:guid}/status**

##### HTTP 200 Response body example

|Parameter Name |Type |Description |Valid values |
|----------------------|--------------|------------|----------|
|**InvoiceId**  | guid        |*The ID of the invoice *|5e1210f9-4153-4fc3-83ec-2a8fc4843ea6 |
|**Status**  | string        |*Status of the invoice *| 1: Created </br> 2: Paid </br> 3: Rejected </br> 4: Expired |

### MerchantId GET request
This endpoint is used to get the merchant id associated with a merchant.

#### Request parameters

There is no JSON input model in this endpoint, instead, format the request the in the following way: </br>
**/api/v1/merchants/me**

##### HTTP 200 Response body example
MerchantId: 5e1210f9-4153-4fc3-83ec-2a8fc4843ea6

### InvoiceIssuers GET request
This endpoint is used to get the invoice issuers associated with a merchant.

#### Request parameters

There is no JSON input model in this endpoint, instead, format the request the in the following way: </br>
**/api/v1/merchants/{merchantid}/invoiceissuers**

##### HTTP 200 Response body example

|Parameter Name |Type |Description |Value |
|----------------------|--------------|------------|----------|
|**InvoiceIssuers**  | List        |*List of invoice issuers for a merchant*| { </br>&nbsp;&nbsp;&nbsp;&nbsp;"Id": "1f8288d9-4511-43ef-a1ce-667835470577", </br>&nbsp;&nbsp;&nbsp;&nbsp;"Name": "Test Fik Issuer"</br>},</br>{</br>&nbsp;&nbsp;&nbsp;&nbsp;"Id": "3d579d95-5cbe-4e45-b3e0-3b73d37e8b9c",</br>&nbsp;&nbsp;&nbsp;&nbsp;"Name": "TestName"</br>} |
