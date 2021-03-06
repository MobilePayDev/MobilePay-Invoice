---
layout: default
---

## Invoice 1.5 Release Notes
### <a name="response_code"></a> 6 may 2021 - Added Sequence number to the callbacks
[Sequence](callbacks#sequence_note) number can be used to determine the real order of the invoice events.

### <a name="response_code"></a> 1 april 2021 - Invoice link is deleted after expiration
Invoice link data is deleted once it expires.

### <a name="response_code"></a> 26 january 2021 - Visual design of Invoice PDF changed.
More information in [Visual examples](https://mobilepaydev.github.io/MobilePay-Invoice/visual_examples)

### <a name="response_code"></a> 20 january 2021 - Grant/Reject consent endpoint in UserSimulation API
You can now test [InvoiceDirect user consent](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#direct-invoice-consent) functionality in [sandbox](https://sandbox-developer.mobilepay.dk/)

Endpoint was added that can be used to imitate user granting or rejecting consent.

### <a name="response_code"></a> 17 september 2020 - Sms notification time updates, for when future payment can't be processed
[Sms notification](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#validations) time is updated from 10:00 UTC to 07:00 UTC (09:00 DK time or 10:00 FI time)

### <a name="response_code"></a> 03 september 2020 - Sms notification sending updates, for when future payment can't be processed
[Sms notification](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#validations) to user is sent at 10:00, after two attempts to make payment. If user completes payment manually after second attempt, but before he gets the notification, sms is not sent. 

### <a name="response_code"></a> 10 august 2020 - User consent for InvoiceDirect released
New feature: User consent for InvoiceDirect. Read more about user consent for InvoiceDirect [here](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#direct-invoice-consent)

Goal of this functionality is for invoice issuer to ask users phone number and consent to receive Invoices directly to MobilePay (InvoiceDirect).

### <a name="response_code"></a> 10 august 2020 - Invoice 1.5 released
