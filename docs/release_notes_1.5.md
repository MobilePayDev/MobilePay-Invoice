---
layout: default
---

## Invoice 1.5 Release Notes
### <a name="response_code"></a> 17 september 2020 - Sms notification time updates, for when future payment can't be processed
[Sms notification](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#validations) time is updated from 10:00 UTC to 07:00 UTC (09:00 DK time or 10:00 FI time)

### <a name="response_code"></a> 03 september 2020 - Sms notification sending updates, for when future payment can't be processed
[Sms notification](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#validations) to user is sent at 10:00, after two attempts to make payment. If user completes payment manually after second attempt, but before he gets the notification, sms is not sent. 

### <a name="response_code"></a> 10 august 2020 - User consent for InvoiceDirect released
New feature: User consent for InvoiceDirect. Read more about user consent for InvoiceDirect [here](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#direct-invoice-consent)

Goal of this functionality is for invoice issuer to ask users phone number and consent to receive Invoices directly to MobilePay (InvoiceDirect).

### <a name="response_code"></a> 10 august 2020 - Invoice 1.5 released
