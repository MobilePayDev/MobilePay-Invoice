# Coming soon

<div>
### <a name="response_code"></a> Redirect url for invoice link accepting and payment
[Invoice link creation](https://github.com/ReisEdgar/MobilePay-Invoice/blob/master/docs/api_reference.md#create-invoicelink) You will be able to add optional "RedirectUrl" property when creating single or multiple Invoice links. User will be redirected to your provided url after accepting invoice link payment for the future, or paying for it with appropriate flags, i.e. if you have provided RedirectUrl value "http://YourProvidedUrl.com" in case of accepted payment user will be redireted to "http://YourProvidedUrl.com/Accepted" and in case of instant payment user will be redirected "http://YourProvidedUrl.com/Paid". This feature will support both webUrls and deeplinks. Same "/Accepted" or "/Paid" flags would be added for both webUrls and deeplinks. If you don't provide RedirectuRl property everything will work as it does now.
    
    ##### Example

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
  
    ...

   "RedirectUrl" : "https://www.YourProvidedUrl.com"
}
```
</div>
