# Coming soon

  <b> Redirect url for invoice link accepting and payment </b>
 
[Invoice link](https://mobilepaydev.github.io/MobilePay-Invoice/api_reference#link) will have new optional "RedirectUrl" property. You will be able to set it when creating single or multiple Invoice links. User will be redirected to your provided url after accepting invoice link payment for the future, or paying for it instantly. Redirect will happen with appropriate query parameters, i.e. if you have provided RedirectUrl value "https<span>://YourProvidedUrl.com/</span>" in case of accepted payment user will be redireted to "https<span>://YourProvidedUrl.com/?status=accepted</span>" and in case of instant payment user will be redirected "https<span>://YourProvidedUrl.com/?status=paid</span>". This feature will support both webUrls and deeplinks. Same query parameters would be added for both webUrls and deeplinks. If you don't provide RedirectUrl property everything will work as it does now.

####  Example

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

   "RedirectUrl" : "https://YourProvidedUrl.com/"
}
```

