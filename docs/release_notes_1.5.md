---
layout: default
---

## Invoice 1.5 Release Notes

### <a name="response_code"></a> 21 October 2022 - Invoice article <code>Quantity</code> decimal digits change
Invoice article <code>Quantity</code> field will now support up to 10 decimal digits, for example "0.0012345678".

### <a name="response_code"></a> 08 August 2022 - Callback intervals

We reduced intervals between callback batches from 30 to 5 seconds.

### <a name="response_code"></a> 17 May 2022 - Redirect url for accepting and paying invoice link

[Invoice link](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#link) now has an optional "RedirectUrl" property. It can be set when creating single or multiple Invoice links. User will be redirected to provided url after accepting invoice link payment for the future, or paying for it instantly. Redirect will happen with appropriate query parameters, i.e. if provided RedirectUrl value is "https<span>://ProvidedUrl.com/</span>" in case of accepted payment user will be redirected to "https<span>://ProvidedUrl.com/?status=accepted</span>" and in case of instant payment user will be redirected to "https<span>://ProvidedUrl.com/?status=paid</span>". This feature supports both webUrls and deeplinks. If RedirectUrl property is not provided, everything will work as it did before.

### <a name="response_code"></a> 24 March 2022 - Quantity no longer required when creating invoice

Article quantity is not required when creating invoice direct or invoice link.

### <a name="response_code"></a> 08 March 2022 - Country code and Currency code are not required when creating invoice direct or invoice link

If these parameters are passed with requrest, they will be ignored. Right now we automatically assign merchant's country and currency codes to invoice or invoice link.

### <a name="response_code"></a> 05 January 2022 - Added PaymentReference field to GET invoice details response

[Invoice details](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#get-details) GET response now has PaymentReference field.

### <a name="response_code"></a> 16 December 2021 - Added GrantedOn field to Invoice Direct user consent GET response

[InvoiceDirect user consent](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#direct-invoice-consent) GET response now has GrantedOn field that shows exact time when the consent was granted.

### <a name="response_code"></a> 10 November 2021 - Invoicing has become more flexible. These fields are optional:

<ul>
<li><code>TotalVatAmount</code></li>
<li><code>InvoiceNumber</code></li>
<li><code>IsueDate</code></li>
<li><code>OrderDate</code></li>
<li><code>DeliveryDate</code></li>
<li><code>ArticleNumber</code></li>
<li><code>VATRate</code></li>
<li><code>TotalVatAmount</code></li>
<li><code>Unit</code></li>
<li><code>PricePerUnit</code></li>
<li><code>PriceReduction</code></li>
<li><code>PriceDiscount</code></li>
<li><code>Bonus</code></li>
</ul>

Also only either <code>InvoiceNumber</code> or <code>PaymentReference</code> must be filled, because it is used in transaction reporting and reconciliation. Other one is optional.

More information in [InvoiceDirect](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#direct) and [InvoiceLink](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#link).

### <a name="response_code"></a> 6 May 2021 - Added Sequence number to the callbacks

[Sequence](callbacks#sequence_note) number can be used to determine the real order of the invoice events.

### <a name="response_code"></a> 1 April 2021 - Invoice link is deleted after expiration

Invoice link data is deleted once it expires.

### <a name="response_code"></a> 26 January 2021 - Visual design of Invoice PDF changed.

More information in [Visual examples](https://mobilepaydev.github.io/MobilePay-Invoice/visual_examples)

### <a name="response_code"></a> 20 January 2021 - Grant/Reject consent endpoint in UserSimulation API

You can now test [InvoiceDirect user consent](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#direct-invoice-consent) functionality in [sandbox](https://sandbox-developer.mobilepay.dk/)

Endpoint was added that can be used to imitate user granting or rejecting consent.

### <a name="response_code"></a> 17 September 2020 - Sms notification time updates, for when future payment can't be processed

[Sms notification](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#validations) time is updated from 10:00 UTC to 07:00 UTC (09:00 DK time or 10:00 FI time)

### <a name="response_code"></a> 03 September 2020 - Sms notification sending updates, for when future payment can't be processed

[Sms notification](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#validations) to user is sent at 10:00, after two attempts to make payment. If user completes payment manually after second attempt, but before he gets the notification, sms is not sent.

### <a name="response_code"></a> 10 August 2020 - User consent for InvoiceDirect released

New feature: User consent for InvoiceDirect. Read more about user consent for InvoiceDirect [here](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#direct-invoice-consent)

Goal of this functionality is for invoice issuer to ask users phone number and consent to receive Invoices directly to MobilePay (InvoiceDirect).

### <a name="response_code"></a> 10 August 2020 - Invoice 1.5 released
